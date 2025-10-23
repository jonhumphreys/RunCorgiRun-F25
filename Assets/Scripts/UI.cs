using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text ScoreText;
    
    public void SetScoreText(int score)
    {
        ScoreText.text = "Score: " + score;
    }
}
