using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 30;
    public float increaseValue = 5; // value that added to counter when item is correctly clicked 
    public float decreseValue = 5; // value that subtracted from counter when item is miss clicked 

    bool isTimerRunning = true;

    bool isGameOver = false; // keep track of gamestatus if gameover then donot run the update code as it invoke the gameover event repeatdly :: better to disable the code; 

    [SerializeField] Text countdownText;
    void Start()
    {
        // subscribe to event 
        GameEvent.current.onCorrectClick += increaseTimer;
        GameEvent.current.onMissClick += decreseTimer;
        GameEvent.current.onGamePasue += pauseTimer;
        GameEvent.current.onGameResume += resumeTimer;
        GameEvent.current.onGameOver += overTimer;
        currentTime = startingTime;

    }
    void Update()
    {
        // this code should only work if the game is not over 
        if (!isGameOver)
        {
            if (isTimerRunning)
            {
                currentTime -= 1 * Time.deltaTime;
                countdownText.text = currentTime.ToString("0");

                if (currentTime <= 0)
                {
                    currentTime = 0;
                    // gameover 
                    GameEvent.current.invokeGameStatusChange(GameManager.GameStatus.GameOver);
                }
                if (currentTime <= 10)
                {
                    countdownText.color = Color.red;
                    // countdownText.fontSize = 
                }
                if (currentTime >= 10)
                {
                    countdownText.color = Color.white;
                }
            }

        }
        else
        {
            Debug.Log("Game is over in timer");
        }
    }

    void increaseTimer()
    {
        currentTime += increaseValue;
    }
    void decreseTimer()
    {
        currentTime -= increaseValue;
    }

    

    void pauseTimer()
    {
        Debug.Log("Pause Timer");

        isTimerRunning = false;
    }
    void resumeTimer()
    {
        Debug.Log("Resume Timer");
        isTimerRunning = true;
    }

    void overTimer()
    {
        Debug.Log("Game is obver");
        isGameOver = true;
        
    }

    private void OnDestroy()
    {
        GameEvent.current.onCorrectClick -= increaseTimer;
        GameEvent.current.onMissClick -= decreseTimer;
        GameEvent.current.onGamePasue -= pauseTimer;
        GameEvent.current.onGameResume -= resumeTimer;
    }

}
