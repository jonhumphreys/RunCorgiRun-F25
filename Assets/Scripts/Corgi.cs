using System;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    public SpriteRenderer CorgiSpriteRenderer;

    public void OnTriggerEnter2D(Collider2D other)
    {
        // if collided with beer
            // do the drunk
        // if collided with bone
            // give me points
    }
    

    public void Move(Vector2 direction)
    {
        FaceCorrectDirection(direction);
        
        // set the amount to move in x (left/right) and y (up/down)
        // direction.x will be positive 1 or -1
        // direction.y will be positive 1 or -1
        // Time.deltaTime is the time since the last frame and makes 
        // the movement be the same amount no matter your monitor refresh rate
        float xAmount = direction.x * 5f * Time.deltaTime;
        float yAmount = direction.y * 5f * Time.deltaTime;
        
        // Translate() moves the sprite by xAmount and yAmount
        // we don't want to move the sprite on the z axis so we set it to 0
        CorgiSpriteRenderer.transform.Translate(xAmount, yAmount, 0f);

        CorgiSpriteRenderer.transform.position = 
            SpriteTools.ConstrainToScreen(CorgiSpriteRenderer);
    }
    
    private void FaceCorrectDirection(Vector2 direction)
    {
        // if the direction x is positive (moving right), don't flip the sprite
        if (direction.x > 0)
        {
            CorgiSpriteRenderer.flipX = false;
        }
        // if the direction x is negative (moving left), flip the sprite
        else if (direction.x < 0)
        {
            CorgiSpriteRenderer.flipX = true;
        }
    }
}
