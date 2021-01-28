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

    public void invokeGameOver()
    {
        if (onGameOver != null)
        {
            onGameOver();
        }
    }
}
