using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastTrainLevel : TrainLevelBase
{
    public static readonly string Name = "NRW - Last Train";
    public static readonly string LevelMap = "North Railway";
    public static readonly string LevelDescription =
@"This is the last train of the day. Additional time can be provided to account for the low visibility, as there are no other trains waiting.

Local 2 cars
Depart 21:45:00
[1] Ni-no-mae to [12] Hinoyama-Jinja

Duration: 1 hour 25 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public LastTrainLevel()
        : base(Name, LevelMap, LevelDescription, LevelGameObjectName)
    {
    }

    protected override LevelStartLocation StartLocation
    {
        get
        {
            return new LevelStartLocation
            {
                InitialSpeed = 0f,
                InitialThrottle = 0f,
                Position = new Vector3(-14088.6f, 85.9f, -11778.49f),
                Rotation = new Vector3(0f, -5.17f, 0f),
                StartOnGround = true
            };
        }
    }

    protected override float StartTimeSeconds
    {
        get
        {
            return 78285;
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[] { 81600, -1, 79440, 80070, -1, -1, -1, 81870, -1, -1, -1, 83400 };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[] { 78300, -1, 79500, 80100, -1, -1, -1, 81900, -1, -1, -1, -1 };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 15, 15, 30, 25, 15, 15, 15, 25, 20, 25, 40, 20 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(),
                new Vector3(-11127.73f, 37.9f, -5194f),
                new Vector3(-7713.333f, 111.8f, -78.726f),
                new Vector3(-1046.347f, 40f, 3190.76f),
                new Vector3(5540f, 141.5f, 2958.297f),
                new Vector3(12206f, 167.8f, 2023.096f),
                new Vector3(17730.6f, 134.8f, 2871.934f),
                new Vector3(16073.33f, 35.3f, 7380.243f),
                new Vector3(17614.09f, 38.8f, 9772.788f),
                new Vector3(24745.86f, 35.8f, 12846.31f),
                new Vector3(28958.13f, 20.8f, 13592.99f),
                new Vector3(31642.06f, 41.8f, 13199.13f)
            };
        }
    }
}
