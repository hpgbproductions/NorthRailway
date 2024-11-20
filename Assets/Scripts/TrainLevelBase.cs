using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Jundroo.SimplePlanes.ModTools;
using Jundroo.SimplePlanes.ModTools.AI;

public abstract class TrainLevelBase : Level
{
    private string LevelGameObjectName;
    private Transform StopTargetTransform;
    private Text ClockDisplay;

    private GameObject FrontPart;

    private float CurrentTimeSeconds = 0f;

    private float StopTimer = 0f;
    private int CurrentStop = 0;
    private int NextStop = 0;
    private bool IsStopped = true;



    public TrainLevelBase(string levelName, string levelMap, string levelDescription, string levelGameObjectName)
        : base(levelName, levelMap, levelDescription)
    {
        LevelGameObjectName = levelGameObjectName;
    }

    protected float AllowedStopDeviation = 3f;
    protected float CountStopDuration = 1f;
    protected float CountStopSpeed = 0.05f;
    protected float CancelStopSpeed = 0.2f;
    protected float CountPassDistance = 10f;

    protected float NextRepeatedMessageTimer = 1f;
    protected float RepeatedMessageInterval = 1f;
    protected string RepeatedMessage = "";

    protected bool Initialized = false;
    protected bool LevelCompleted = false;

    protected virtual string TrainDamagedMessage
    {
        get
        {
            return "Your train was damaged.";
        }
    }

    protected virtual string StartedWhileDoorsOpenMessage
    {
        get
        {
            return "The train moved off while passengers were boarding or alighting.";
        }
    }

    protected virtual string SuccessMessage
    {
        get
        {
            return "Job completed!";
        }
    }

    protected virtual float StartTimeSeconds
    {
        get
        {
            return 43200f;
        }
    }

    // Departure time of day in seconds for each station (index 0 for starting station).
    protected virtual int[] DepartureTimes
    {
        get
        {
            return null;
        }
    }

    // Arrival time shown on the display (index 0 for starting station).
    // Passed stations shall also use the arrival time.
    protected virtual int[] ArrivalTimes
    {
        get
        {
            return null;
        }
    }

    // Minimum time that the train must remain stopped even if it arrives late (index 0 for starting station, value unused).
    // If the value is negative, the station may be passed without stopping.
    protected virtual int[] MinStopDurations
    {
        get
        {
            return null;
        }
    }

    // Position where the front of the train must align with (index 0 for starting station)
    protected virtual Vector3[] StopPositions
    {
        get
        {
            return null;
        }
    }

    protected virtual WeatherPreset Weather
    {
        get
        {
            return WeatherPreset.Clear;
        }
    }

    protected virtual string StartRepeatedMessage
    {
        get
        {
            return "Wait for the signal to depart.";
        }
    }

    protected virtual string OnArrivedRepeatedMessage
    {
        get
        {
            return "The train arrived at the station. Wait for the signal to depart.";
        }
    }

    protected virtual string DepartSignalMessage
    {
        get
        {
            return "Ready to depart.";
        }
    }

    protected virtual string IncorrectStopPositionRepeatedMessage
    {
        get
        {
            return "Move the train to the stop position.";
        }
    }

    protected virtual string StoppedAtPassingStationMessage
    {
        get
        {
            return "Do not stop at this station.";
        }
    }

    private string FormatTime(float TimeOfDaySeconds)
    {
        int t = Mathf.RoundToInt(TimeOfDaySeconds);
        if (t >= 0)
        {
            return $"{t / 3600 % 24:00}:{t / 60 % 60:00}:{t % 60:00}";
        }
        else
        {
            return "--:--:--";
        }
    }

    protected override void Start()
    {
        base.Start();

        GameObject obj = ServiceProvider.Instance.ResourceLoader.LoadGameObject(LevelGameObjectName);
        StopTargetTransform = obj.transform.GetChild(0);
        StopTargetTransform.localPosition = StopPositions[0];

        ClockDisplay = obj.GetComponentInChildren<Text>();

        ServiceProvider.Instance.EnvironmentManager.LengthOfDay = 1440;
        ServiceProvider.Instance.EnvironmentManager.TimeOfDay = StartTimeSeconds / 3600f;
        ServiceProvider.Instance.EnvironmentManager.UpdateWeather(Weather, 0f, true);

        float LargestZPosition = float.MinValue;
        List<GameObject> AllParts = ServiceProvider.Instance.PlayerAircraft.Parts;
        foreach (GameObject g in AllParts)
        {
            float PartZPosition = g.transform.localPosition.z;
            if (PartZPosition > LargestZPosition)
            {
                LargestZPosition = PartZPosition;
                FrontPart = g;
            }
        }

        RepeatedMessage = StartRepeatedMessage;
    }

    protected override void OnLevelComplete()
    {
        base.OnLevelComplete();
        LevelCompleted = true;
    }

    protected override void Update()
    {
        base.Update();

        if (!LevelCompleted)
        {
            CurrentTimeSeconds = StartTimeSeconds + Time.timeSinceLevelLoad;
        }

        NextRepeatedMessageTimer -= Time.deltaTime;
        if (NextRepeatedMessageTimer <= 0)
        {
            NextRepeatedMessageTimer = RepeatedMessageInterval;

            if (!string.IsNullOrEmpty(RepeatedMessage))
            {
                ServiceProvider.Instance.GameWorld.ShowStatusMessage(RepeatedMessage, 0f);
            }
        }

        if (IsStopped)
        {
            StopTimer -= Time.deltaTime;

            // On departure allowed
            if (StopTimer <= 0 && CurrentTimeSeconds >= DepartureTimes[CurrentStop])
            {
                IsStopped = false;
                StopTimer = CountStopDuration;

                NextStop++;
                if (NextStop <= StopPositions.Length)
                {
                    StopTargetTransform.localPosition = StopPositions[NextStop];
                }

                RepeatedMessage = "";
                ServiceProvider.Instance.GameWorld.ShowStatusMessage(DepartSignalMessage, 5f);
            }

            if (ServiceProvider.Instance.PlayerAircraft.CriticallyDamaged)
            {
                EndLevel(false, TrainDamagedMessage, 0f);
            }

            if (Time.timeSinceLevelLoad > 5f && ServiceProvider.Instance.PlayerAircraft.Velocity.magnitude > CancelStopSpeed)
            {
                EndLevel(false, StartedWhileDoorsOpenMessage, 0f);
            }

            if (CurrentStop <= DepartureTimes.Length)
            {
                ClockDisplay.text = $"Now {FormatTime(CurrentTimeSeconds)}\nDep. {FormatTime(DepartureTimes[CurrentStop])}";
            }
            else
            {
                ClockDisplay.text = $"Now {FormatTime(CurrentTimeSeconds)}\nDep. --:--:--";
            }
        }
        else
        {
            Vector3 TrainFrontPosition = FrontPart.transform.position;
            Vector3 StopPosition = StopTargetTransform.position;
            TrainFrontPosition.y = StopPosition.y;
            float StopPositionDistance = Vector3.Distance(TrainFrontPosition, StopPosition);

            if (ServiceProvider.Instance.PlayerAircraft.Velocity.magnitude < CountStopSpeed)
            {
                if (StopPositionDistance < AllowedStopDeviation)
                {
                    StopTimer -= Time.deltaTime;
                }
                else if (StopPositionDistance < 100f)
                {
                    if (MinStopDurations[CurrentStop + 1] >= 0)
                    {
                        RepeatedMessage = IncorrectStopPositionRepeatedMessage;
                    }
                    else
                    {
                        ServiceProvider.Instance.GameWorld.ShowStatusMessage(StoppedAtPassingStationMessage, 5f);
                    }
                }
            }

            // On passing the station, when the service does not stop
            if (MinStopDurations[CurrentStop + 1] < 0 && StopPositionDistance < CountPassDistance)
            {
                StopTimer = CountStopDuration;

                CurrentStop++;
                NextStop++;
                if (NextStop <= StopPositions.Length)
                {
                    StopTargetTransform.localPosition = StopPositions[NextStop];
                }

                RepeatedMessage = "";
            }

            // On stop counted
            if (StopTimer <= 0 && MinStopDurations[CurrentStop + 1] >= 0)
            {
                IsStopped = true;

                CurrentStop++;
                StopTimer = MinStopDurations[CurrentStop];

                if (CurrentStop == StopPositions.Length - 1)
                {
                    EndLevel(true, SuccessMessage, 0f);
                }

                RepeatedMessage = OnArrivedRepeatedMessage;
            }

            if (NextStop < ArrivalTimes.Length)
            {
                ClockDisplay.text = $"Now {FormatTime(CurrentTimeSeconds)}\n{(MinStopDurations[CurrentStop + 1] >= 0 ? "Arr." : "Pass")} {FormatTime(ArrivalTimes[NextStop])}";
            }
            else
            {
                ClockDisplay.text = $"Now {FormatTime(CurrentTimeSeconds)}\nArr. --:--:--";
            }
        }
    }
}
