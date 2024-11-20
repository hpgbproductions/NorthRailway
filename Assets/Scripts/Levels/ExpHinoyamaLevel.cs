using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpHinoyamaLevel : TrainLevelBase
{
    public static readonly string Name = "NRW - Exp. Hinoyama";
    public static readonly string LevelMap = "North Railway";
    public static readonly string LevelDescription =
@"Operate the new Hatsuharu Express service. This is a direct service to Hinoyama Shrine, which has gained in popularity after its appearance in a popular TV show.

Express 6 cars
Depart 10:05:00
[3] Yakumo to [12] Hinoyama-Jinja

Duration: 55 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public ExpHinoyamaLevel()
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
                Position = new Vector3(-7737.5f, 111.8f, -110.6f),
                Rotation = new Vector3(0f, 37.17f, 0f),
                StartOnGround = true
            };
        }
    }

    protected override float StartTimeSeconds
    {
        get
        {
            return 36285;
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[] { 36255, 38280, 39330, 39600 };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[] { 36300, 38280, 39420, 40200 };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 0, -1, 70, 30 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(),
                new Vector3(16064.2f, 35.3f, 7341.3f),
                new Vector3(28958.13f, 20.8f, 13592.99f),
                new Vector3(31647.03f, 41.8f, 13198.57f)
            };
        }
    }
}
