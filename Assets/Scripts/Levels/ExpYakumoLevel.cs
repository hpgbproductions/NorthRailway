using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpYakumoLevel : TrainLevelBase
{
    public static readonly string Name = "NRW - Exp. Yakumo";
    public static readonly string LevelMap = "North Railway";
    public static readonly string LevelDescription =
@"Operate the new Hatsuharu Express service. It serves as a faster connection to a large city near the Hinoyama line, and was introduced to meet increasing winter tourist demand in the area.

Express 6 cars
Depart 11:10:00
[12] Hinoyama-Jinja to [3] Yakumo

Duration: 55 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public ExpYakumoLevel()
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
            return 40185;
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[] { 39600, 40410, 41520, 43455 };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[] { 40200, 40500, 41520, 43500 };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 0, 70, -1, 30 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(),
                new Vector3(28839.87f, 20.8f, 13613.35f),
                new Vector3(16064.2f, 35.3f, 7341.3f),
                new Vector3(-7785.834f, 111.8f, -174.3477f)
            };
        }
    }
}