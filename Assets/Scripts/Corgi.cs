using System;
using System.Collections;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    public SpriteRenderer CorgiSpriteRenderer;
    public Sprite DrunkSprite;
    public Sprite SoberSprite;
    public UI UI;
    public Game Game;

    private bool isDrunk = false;
    private bool isPlastered = false;

    private int randomMoveCounter = 0;
    private int lastRandomDirection = 0;
    
    public void Update()
    {
        if (isPlastered)
        {
            MoveRandomly();
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Beer")
        {
            GetDrunk();
        }
        
        if (other.gameObject.tag == "Pill")
        {
            SoberUp();
        }
        
        if (other.gameObject.tag == "Bone")
        {
            ScoreKeeper.AddPoint();
            UI.SetScoreText(ScoreKeeper.GetScore());
        }
        
        Destroy(other.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Moonshine")
        {
            GetPlastered();
        }
    }

    private void GetPlastered()
    {
        isPlastered = true;
        Inebriate();
    }

    private void Inebriate()
    {
        ChangeToDrunkSprite();
        StartSoberingUp();
    }

    private void GetDrunk()
    {
        if (isPlastered)
            return;
        
        isDrunk = true;
        Inebriate();
    }

    private void ChangeToDrunkSprite()
    {
        CorgiSpriteRenderer.sprite = DrunkSprite;
    }

    private void StartSoberingUp()
    {
        StartCoroutine(CountdownUntilSober());
    }

    IEnumerator CountdownUntilSober()
    {
        yield return new WaitForSeconds(GameParameters.CorgiDrunkSeconds);
        SoberUp();
    }

    private void SoberUp()
    {
        isDrunk = false;
        isPlastered = false;
        ChangeToSoberSprite();
    }

    private void ChangeToSoberSprite()
    {
        CorgiSpriteRenderer.sprite = SoberSprite;
    }

    private void MoveRandomly()
    {
        int direction = lastRandomDirection;

        if (randomMoveCounter == 0)
        {
            direction = UnityEngine.Random.Range(0, 4);
            randomMoveCounter = UnityEngine.Random.Range(20, 40);
            lastRandomDirection = direction;
        }
        
        switch (direction)
        {
            case 0:
                Move(new Vector2(1, 0));
                break;
            case 1:
                Move(new Vector2(-1, 0));
                break;
            case 2:
                Move(new Vector2(0, 1));
                break;
            case 3:
                Move(new Vector2(0, -1));
                break;
        }
        
        randomMoveCounter--;
    }

    public void MoveManually(Vector2 direction)
    {
        if (!Game.IsPlaying)
            return;
        
        if (isPlastered)
            return;
        
        Move(direction);
    }

    public void Move(Vector2 direction)
    {
        direction = ApplyDrunkenness(direction);
        
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

    private Vector2 ApplyDrunkenness(Vector2 direction)
    {
        if (isDrunk)
        {
            direction.x = direction.x * -1;
            direction.y = direction.y * -1;
        }
        
        return direction;
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

    public void Reset()
    {
        CorgiSpriteRenderer.transform.position =
            new Vector3(0, 0, 0);
        CorgiSpriteRenderer.flipX = false;
        CorgiSpriteRenderer.sprite = SoberSprite;
        isDrunk = false;
        isPlastered = false;
    }
}
