using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommuterLevel : TrainLevelBase
{
    public static readonly string Name = "NRW - Morning Commuter";
    public static readonly string LevelMap = "North Railway";
    public static readonly string LevelDescription =
@"This train connects commuters to Yakumo, where they can board the 8:22 train to the city. If you are late, the next connecting train will only arrive 40 minutes later, so it is critical to arrive on time.

Local 2 cars
Depart 07:20:00
[12] Hinoyama-Jinja to [1] Ni-no-mae

Duration: 1 hour 20 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public CommuterLevel()
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
                Position = new Vector3(31642.06f, 41.8f, 13199.13f),
                Rotation = new Vector3(0f, -83.55f, 0f),
                StartOnGround = true
            };
        }
    }

    protected override float StartTimeSeconds
    {
        get
        {
            return 26385;
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[] { 0, -1, -1, -1, 27780, -1, -1, -1, 29490, 30060, -1, 31200 };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[] { 26400, -1, -1, -1, 27900, -1, -1, -1, 29520, 30120, -1, 31500 };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 20, 35, 25, 25, 25, 15, 15, 15, 25, 50, 15, 15 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(),
                new Vector3(28918.71f, 20.8f, 13599.78f),
                new Vector3(24713.5f, 35.8f, 12822.8f),
                new Vector3(17582.5f, 38.8f, 9748.25f),
                new Vector3(16064.2f, 35.3f, 7341.3f),
                new Vector3(17701.3f, 134.8f, 2844.7f),
                new Vector3(12175.67f, 167.8f, 2049.18f),
                new Vector3(5500f, 141.5f, 2958.297f),
                new Vector3(-1046.347f, 40f, 3230.31f),
                new Vector3(-7737.5f, 111.8f, -110.6f),
                new Vector3(-11158.17f, 37.9f, -5219.951f),
                new Vector3(-14086.8f, 85.9f, -11798.41f)
            };
        }
    }
}
