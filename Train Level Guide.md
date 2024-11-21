### Train Level Quick Start Guide

The TrainLevelBase class can be used to create train driving scenarios. To create a new scenario, declare a class derived from TrainLevelBase.

**Typical workflow:**

1. Identify the stations that the train will stop at, and the stations that the train will pass but the passing time is timetabled.
2. Fill in the position and rotation of StartLocation.
3. Fill in StartTimeSeconds. Time is stored as seconds from midnight.
4. Fill in the arrays ArrivalTimes, DepartureTimes, MinStopDurations, and StopPositions. Refer to the section below.
5. Other overrides and variables are available for changing. Check TrainLevelBase to find them.

**Notes on station definition arrays:**

1. ArrivalTimes is used to display stopping and passing times.
2. DepartureTimes is the earliest time when a train is allowed to leave a station.
3. MinStopDurations is the minimum duration that a train must be stopped before it is allowed to leave. If it is negative, the train may pass the station.
4. StopPositions is the position of the corresponding stop marker.
5. Index zero corresponds to the starting station. Index zero of ArrivalTimes, MinStopDurations, and StopPositions are unused.
6. ArrivalTimes and DepartureTimes can be set as negative. This will cause them to be displayed as "--:--:--".
