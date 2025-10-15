using UnityEngine;

public class Cake : TimedObject
{
    public void Start()
    {
        secondsOnScreen = GameParameters.CakeSecondsOnScreen;
        base.Start();
    }
}
