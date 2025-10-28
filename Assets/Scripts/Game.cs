using UnityEngine;

public class Game : MonoBehaviour
{
    public UI UI;
    public GameTimer GameTimer;
    
    void Start()
    {
        UI.ShowStartScreen();
    }

    public void Update()
    {
        UI.ShowTime();
    }

    public void OnStartButtonClicked()
    {
        UI.HideStartScreen();
        GameTimer.StartTimer(10, OnTimerFinished);
    }
    
    public void OnTimerFinished()
    {
        UI.ShowGameOverScreen();
    }

}
