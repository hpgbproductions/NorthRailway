using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalLevel5 : TrainLevelBase
{
    public static readonly string Name = "NRW - Local Section 5";
    public static readonly string LevelMap = "North Railway";
    public static readonly string LevelDescription =
@"Off-peak afternoon train service. There is not much extra time for running through the mountainous section in the middle.

Local 1 car
Depart 15:05:00
[3] Yakumo to [8] Harumi

Duration: 40 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public LocalLevel5()
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
                Position = new Vector3(-7713.333f, 111.8f, -78.72614f),
                Rotation = new Vector3(0f, 37.17f, 0f),
                StartOnGround = true
            };
        }
    }

    protected override float StartTimeSeconds
    {
        get
        {
            return 54285;
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[] { 54180, 54870, 55260, 55800, 56220, 56670 };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[] { 54300, -1, -1, -1, -1, 56700 };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 15, 20, 15, 15, 15, 20 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(),
                new Vector3(-1046.347f, 40f, 3190.76f),
                new Vector3(5540f, 141.5f, 2958.297f),
                new Vector3(12206f, 167.8f, 2023.096f),
                new Vector3(17730.6f, 134.8f, 2871.934f),
                new Vector3(16073.33f, 35.3f, 7380.243f)
            };
        }
    }
}
