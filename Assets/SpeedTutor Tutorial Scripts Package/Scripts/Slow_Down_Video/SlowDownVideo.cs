using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SlowDownVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer myVideo;
    [SerializeField] private float videoSpeed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(videoSpeed >= 1)
            {
               myVideo.playbackSpeed = videoSpeed;
            }
            
        }
    }
}
