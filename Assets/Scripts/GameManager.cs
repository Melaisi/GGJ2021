using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    /// <summary>
    /// Keep track of score and gamestatus ( GameOver ) 
    /// </summary>
    /// 

    [SerializeField] Text scoreText;
    float score = 0;
    public float pointForCoreectFind = 1;

    // Start is called before the first frame update
    void Start()
    {
        // subscribe to GameEvent 
        GameEvent.current.onCorrectClick += updateScore;
        GameEvent.current.onGameOver += gameOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateScore()
    {
        score += pointForCoreectFind;
        scoreText.text = score.ToString() ;
    }

    void gameOver()
    {
        Debug.Log("Game Over");
    }

    private void OnDestroy()
    {
        GameEvent.current.onCorrectClick -= updateScore;
        GameEvent.current.onGameOver -= gameOver;
    }
}
