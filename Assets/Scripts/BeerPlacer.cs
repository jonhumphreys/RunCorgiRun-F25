using UnityEngine;

public class BeerPlacer : MonoBehaviour
{
    public GameObject BeerPrefab;
    
    // Update is called once per frame
    void Update()
    {
        // place a beer somewhere randomly on screen
        PlaceNewBeer();
    }

    private void PlaceNewBeer()
    {
        Instantiate(BeerPrefab, 
            SpriteTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
}
