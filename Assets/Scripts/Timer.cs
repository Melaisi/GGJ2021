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


    [SerializeField] Text countdownText;
    void Start()
    {
        // subscribe to event 
        GameEvent.current.onCorrectClick += increaseTimer;
        GameEvent.current.onMissClick += decreseTimer;
        currentTime = startingTime;
    }
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            // gameover 
            GameEvent.current.invokeGameOver();
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

    void increaseTimer()
    {
        currentTime += increaseValue;
    }
    void decreseTimer()
    {
        currentTime -= increaseValue;
    }

    private void OnDestroy()
    {
        GameEvent.current.onCorrectClick -= increaseTimer;
        GameEvent.current.onMissClick -= decreseTimer;
    }
}
