using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoopPlacer : MonoBehaviour
{
    public Game Game;
    
    // Instantiate can only create prefabs
    // Prefabs are of type GameObject
    public GameObject PoopPrefab;
    
    public void Place(Vector3 corgiPosition)
    {
        if (!Game.IsPlaying)
            return;
        
        // make a poop prefab at the corgi's position
        Instantiate(PoopPrefab, corgiPosition, Quaternion.identity);
    }
    
    public void CleanUpPlacedObjects()
    {
        List<GameObject> placedObjects =
            GameObject.FindGameObjectsWithTag(PoopPrefab.tag).ToList();

        for (int i = 0; i < placedObjects.Count; i++)
        {
            Destroy(placedObjects[i]);
        }
    }
}
