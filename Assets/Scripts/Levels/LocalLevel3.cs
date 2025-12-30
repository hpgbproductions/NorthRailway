using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalLevel3 : TrainLevelBase
{
    public static readonly string Name = "NRW - Local Section 3";
    public static readonly string LevelMap = "North Railway";
    public static readonly string LevelDescription =
@"Off-peak afternoon train service. This end of the line functions more like a branch.

Local 1 car
Depart 14:18:00
[3] Yakumo to [1] Ni-no-mae

Duration: 18 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public LocalLevel3()
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
                Position = new Vector3(-7725.417f, 111.8f, -94.663f),
                Rotation = new Vector3(0f, 217.17f, 0f),
                StartOnGround = true
            };
        }
    }

    protected override float StartTimeSeconds
    {
        get
        {
            return 51465;
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[] { 51450, 52020, 52560 };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[] { 51480, 52050,  52800};
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 15, 15, 15 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(),
                new Vector3(-11158.17f, 37.9f, -5219.95f),
                new Vector3(-14088.6f, 85.9f, -11778.49f)
            };
        }
    }
}
