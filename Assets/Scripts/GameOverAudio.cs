using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// play once when losing
/// </summary>
public class GameOverAudio : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playWhenLosing();
        //subscribe the AudioSource play method to gameover event 
        GameEvent.current.onGameOver += playWhenLosing;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playWhenLosing()
    {
        Debug.Log("ShouldPlay gameover audio");
        audioSource.Play();
    }
    private void OnDestroy()
    {
        GameEvent.current.onGameOver -= playWhenLosing;
    }


}
