using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private int score;

    [SerializeField] private Text scoreText;

    private void Start()
    {
        score = 0;
    }

    public void UpdateScore()
    {
        Debug.Log("UPDATING SCORE");

        score++;
        scoreText.text = score.ToString("0");
    }
}
