using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public GameObject GameOverUI;
    public GameObject InGameScreen;
    public enum GameStatus { Playing, Pause,  Resume , GameOver};
    public static GameStatus gameStatus;
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
        GameOverUI.SetActive(true);
        InGameScreen.SetActive(false);
        Debug.Log("Game Over");
    }


    private void OnDestroy()
    {
        GameEvent.current.onCorrectClick -= updateScore;
        GameEvent.current.onGameOver -= gameOver;
    }
}
