using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalLevel1 : TrainLevelBase
{
    public static readonly string Name = "NRW - Local Section 1";
    public static readonly string LevelMap = "North Railway";
    public static readonly string LevelDescription =
@"Off-peak afternoon train service. There is plenty of time for driving.

Local 1 car
Depart 13:10:00
[12] Hinoyama-Jinja to [8] Harumi

Duration: 25 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public LocalLevel1()
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
            return new[] { 47160, 47550, 47850, 48600, 48900 };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[] { 47400, 47580, -1, -1, 49080 };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 20, 20, 20, 20, 20 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(31642.06f, 41.8f, 13199.13f),
                new Vector3(28938.42f, 20.8f, 13596.38f),
                new Vector3(24729.68f, 35.8f, 12834.56f),
                new Vector3(17598.29f, 38.8f, 9760.52f),
                new Vector3(16068.77f, 35.3f, 7360.77f)
            };
        }
    }
}
