using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroLevel : TrainLevelBase
{
    public static readonly string Name = "NRW - Intro";
    public static readonly string LevelMap = "North Railway";
    public static readonly string LevelDescription =
@"Test scenario. Do not move the train when waiting for the signal to depart. The maximum stop position offset is 3 meters.

Local 1 car
Depart 13:10:00
[12] Hinoyama-Jinja to [10] Oozora

Duration: 8 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public IntroLevel()
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
                Position = new Vector3(31592.38f, 41f, 13204.75f),
                Rotation = new Vector3(0f, 276.45f, 0f),
                StartOnGround = true
            };
        }
    }

    protected override float StartTimeSeconds
    {
        get
        {
            return 47385;
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[] { 47160, 47550, 47790 };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[] { 47400, 47580, 47820 };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 20, 20, 20 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(31642.06f, 41.8f, 13199.13f),
                new Vector3(28938.42f, 20.8f, 13596.38f),
                new Vector3(24729.68f, 35.8f, 12834.56f)
            };
        }
    }
}
