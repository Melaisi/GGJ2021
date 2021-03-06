﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FPSRaycasts : MonoBehaviour
{
    private GameObject raycastedObj;

    [SerializeField] private int rayLength = 10;
    [SerializeField] private LayerMask layerMaskInteract;

    [SerializeField] private Image crosshairUI;

    [SerializeField] bool isPlaying = true;

    private void Start()
    {
        // subscribe to event manager 
        GameEvent.current.onGameOver += pauseMode;
        GameEvent.current.onGamePasue += pauseMode;
        GameEvent.current.onGamePlaying += playingMode;
        GameEvent.current.onGameResume += playingMode;



    }

    void Update()
    {
        if (isPlaying) // execute code only if in playing mode
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            Debug.DrawRay(transform.position, fwd * 10, Color.green);
            layerMaskInteract = LayerMask.GetMask("target");


            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract))
            {
                //Debug.Log(" ray intersects with a Collider");
                if (hit.collider.CompareTag("Object"))
                {
                    raycastedObj = hit.collider.gameObject;
                    CrosshairActive();

                    itemFound();

                    /*if (Input.GetKeyDown("e"))
                    {
                        Debug.Log("I HAVE INTERACTED WITH AN OBJECT!");
                        raycastedObj.SetActive(false);
                    }*/
                }
            }
            else
            {
                CrosshairNormal();
                missClicked();
            }
        }
    }

    void CrosshairActive()
    {
        crosshairUI.color = Color.red;
    }

    void CrosshairNormal()
    {
        crosshairUI.color = Color.white;
    }

    /// <summary>
    /// Method to set what to do when item is found... 
    /// </summary>
    void itemFound()
    {
        
        // invoke correct click event if mouse is clicked 
        if (Input.GetMouseButtonDown(0))
        {
            GameEvent.current.invokeCorrectClick();
        }
        else
        {
            // count down three seconds if the person didn't click the item 
            // then invoke miss clicked event 

        }
    }
    /// <summary>
    /// Method to set what to do when player missclick... 
    /// </summary>
    void missClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameEvent.current.invokeMissClick();
        }
        
    }

    void playingMode()
    {
        isPlaying = true;
    }
    void pauseMode() {
        Debug.Log("is paused and the clicking should stop!");
        isPlaying = false;
    }

    private void OnDestroy()
    {
        GameEvent.current.onGameOver -= pauseMode;
        GameEvent.current.onGamePasue -= pauseMode;
        GameEvent.current.onGamePlaying -= playingMode;
        GameEvent.current.onGameResume -= playingMode;

    }
}
