using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalLevel6 : TrainLevelBase
{
    public static readonly string Name = "NRW - Local Section 6";
    public static readonly string LevelMap = "North Railway";
    public static readonly string LevelDescription =
@"Off-peak afternoon train service. The two-way run concludes at the end of this section, allowing for a driver swap.

Local 1 car
Depart 15:45:00
[8] Harumi to [12] Hinoyama-Jinja

Duration: 22 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public LocalLevel6()
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
                Position = new Vector3(16068.77f, 35.3f, 7360.771f),
                Rotation = new Vector3(0f, 13.2f, 0f),
                StartOnGround = true
            };
        }
    }

    protected override float StartTimeSeconds
    {
        get
        {
            return 56685;
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[] { 56670, 56910, 57630, 57840, 58020 };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[] { 56700, -1, -1, -1, 58200 };
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
                new Vector3(),
                new Vector3(17614.09f, 38.8f, 9772.788f),
                new Vector3(24745.86f, 35.8f, 12846.31f),
                new Vector3(28958.13f, 20.8f, 13592.99f),
                new Vector3(31642.06f, 41.8f, 13199.13f)
            };
        }
    }
}
