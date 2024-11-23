using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalLevel4 : TrainLevelBase
{
    public static readonly string Name = "NRW - Local Section 4";
    public static readonly string LevelMap = "North Railway";
    public static readonly string LevelDescription =
@"Off-peak afternoon train service. Return to the interchange at Yakumo.

Local 1 car
Depart 14:45:00
[1] Ni-no-mae to [3] Yakumo

Duration: 18 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public LocalLevel4()
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
            return 53085;
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[] { 52650, 53610, 54180 };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[] { 53100, -1, 54300 };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 15, 15, 20 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(),
                new Vector3(-11142.45f, 37.9f, -5206.976f),
                new Vector3(-7713.333f, 111.8f, -78.72614f)
            };
        }
    }
}
