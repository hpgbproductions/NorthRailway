using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalLevel2 : TrainLevelBase
{
    public static readonly string Name = "NRW - Local Section 2";
    public static readonly string LevelMap = "North Railway";
    public static readonly string LevelDescription =
@"Off-peak afternoon train service. This section is fairly tight on timing.

Local 1 car
Depart 13:38:00
[8] Harumi to [3] Yakumo

Duration: 40 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public LocalLevel2()
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
                Position = new Vector3(16068.77f, 35.3f, 7360.77f),
                Rotation = new Vector3(0f, 193.2f, 0f),
                StartOnGround = true
            };
        }
    }

    protected override float StartTimeSeconds
    {
        get
        {
            return 49065;
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[] { 48900, 49500, 49890, 50400, 50880, 51450 };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[] { 49080, -1, -1, -1, -1, 51480 };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 20, 15, 15, 15, 20, 20 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(),
                new Vector3(17715.95f, 134.8f, 2858.317f),
                new Vector3(12190.83f, 167.8f, 2036.138f),
                new Vector3(5520f, 141.5f, 2958.297f),
                new Vector3(-1048.988f, 40f, 3210.585f),
                new Vector3(-7725.417f, 111.8f, -94.663f)
            };
        }
    }
}
