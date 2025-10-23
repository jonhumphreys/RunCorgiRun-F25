using UnityEngine;

public class MoonshinePlacer : TimedObjectPlacer
{
    public void Start()
    {
        minimumSecondsToWait = GameParameters.MoonshineMinimumSecondsToWait;
        maximumSecondsToWait = GameParameters.MoonshineMaximumSecondsToWait;
    }
    
    public override void Place()
    {
        Instantiate(Prefab, 
            SpriteTools.RandomTopOfScreenLocationWorldSpace(), 
            Quaternion.identity);
    }
}
