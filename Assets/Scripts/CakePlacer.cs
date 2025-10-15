using UnityEngine;

public class CakePlacer : TimedObjectPlacer
{
    public void Start()
    {
        minimumSecondsToWait = GameParameters.CakeMinimumSecondsToWait;
        maximumSecondsToWait = GameParameters.CakeMaximumSecondsToWait;
    }
}


