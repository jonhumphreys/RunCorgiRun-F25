using System.Collections;
using UnityEngine;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject Prefab;

    private bool isOkToCreate = true;
    
    public float minimumSecondsToWait = 1f;
    public float maximumSecondsToWait = 3f;
    
    // Update is called once per frame
    void Update()
    {
        if (isOkToCreate)
        {
            // place a beer somewhere randomly on screen
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

    private void Place()
    {
        Instantiate(Prefab, 
            SpriteTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
}
