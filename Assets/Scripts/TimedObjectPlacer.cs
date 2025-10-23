using System.Collections;
using UnityEngine;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject Prefab;

    private bool isOkToCreate = true;
    
    public float minimumSecondsToWait = 1f;
    public float maximumSecondsToWait = 3f;
    
    void Update()
    {
        if (isOkToCreate)
        {
            // place somewhere randomly on screen
            StartCoroutine(CountdownUntilCreation());
        }
    }

    IEnumerator CountdownUntilCreation()
    {
        isOkToCreate = false;
        
        float secondsToWait = Random.Range(minimumSecondsToWait,
            maximumSecondsToWait);
        yield return new WaitForSeconds(secondsToWait);
        Place();
        
        isOkToCreate = true;
    }

    public virtual void Place()
    {
        Instantiate(Prefab, 
            SpriteTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
}
