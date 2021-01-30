using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class GameEvent : MonoBehaviour
{
    public static GameEvent current;

    private void Awake()
    {
        current = this;
    }

    public event Action onCorrectClick;
    public event Action onMissClick;
    public event Action onGameOver;
    public event Action onGamePasue;
    public event Action onGameResume;
    public event Action onGamePlaying; 


    public void invokeCorrectClick()
    {
        if(onCorrectClick != null)
        {
            onCorrectClick();
        }
    }

    public void invokeMissClick()
    {
        if (onMissClick != null)
        {
            onMissClick();
        }
    }

    public void invokeGameStatusChange(GameManager.GameStatus status)
    {
        switch (status)
        {
            case GameManager.GameStatus.Playing:
                if(onGamePlaying != null)
                {
                    onGamePlaying(); // start new timer new score count relocate mouse click  and stuff 
                }
                break;
            case GameManager.GameStatus.Pause:
                if (onGamePasue != null)
                {
                    onGamePasue();// Stop timer and score count relocate mouse click and stuff 
                }
                break;
            case GameManager.GameStatus.Resume:
                if (onGameResume != null)
                {
                    onGameResume(); // continue timer and scoreount relocate mouse click and stuff
                }

                break;
            case GameManager.GameStatus.GameOver:
                if (onGameOver != null)
                {
                    Debug.Log("Gameover event is invoke");
                    onGameOver(); // 
                }

                break;
            default:
                Debug.Log("Undefined Status!");
                break;
        }
    }
    
}
