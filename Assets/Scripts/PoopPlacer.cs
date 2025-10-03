using UnityEngine;

public class PoopPlacer : MonoBehaviour
{
    // Instantiate can only create prefabs
    // Prefabs are of type GameObject
    public GameObject PoopPrefab;
    
    public void Place(Vector3 corgiPosition)
    {
        // make a poop prefab at the corgi's position
        Instantiate(PoopPrefab, corgiPosition, Quaternion.identity);
    }
}
