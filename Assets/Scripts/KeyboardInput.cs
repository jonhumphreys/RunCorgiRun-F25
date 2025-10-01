using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Corgi Corgi;
    
    void Update()
    {
        // remember: GetKey() returns true if the key is currently being pressed
        // but GetKeyDown() returns true only if the key was just pressed
        // (have to release it and press again to get it to return true again)
        
        // if we pressed W, move positive y (up)
        if (Input.GetKey(KeyCode.W))
        {
            Corgi.Move(new Vector2(0, 1));
        }
        
        // if we pressed S, move negative y (down)
        if (Input.GetKey(KeyCode.S))
        {
            Corgi.Move(new Vector2(0, -1));
        }
        
        // if we pressed A, move negative x (left)
        if (Input.GetKey(KeyCode.A))
        {
            Corgi.Move(new Vector2(-1, 0));
        }
        
        // if we pressed D, move positive x (right)
        if (Input.GetKey(KeyCode.D))
        {
            Corgi.Move(new Vector2(1, 0));
        }
        
    }
}
