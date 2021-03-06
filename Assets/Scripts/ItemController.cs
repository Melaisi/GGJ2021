﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Place item randomly within a pre-determined range 
/// Set timer for the item to relecote if player didn't click on it 
/// Relocate item 
/// Disable if gameover 
/// Invoke action if missclicked or correctclick 
/// </summary>
public class ItemController : MonoBehaviour
{
    [SerializeField] Transform lowerSpawnRangeTransform;
    [SerializeField] Transform upperSpawnRangeTransform;
    Vector3 lowerSpawnRange;
    Vector3 upperSpawnRange;
    [SerializeField] float relocateTimer=1f; //in Seconds  

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to GameEvent Action 
        GameEvent.current.onCorrectClick += onCorrectClick;
        GameEvent.current.onGameOver += onGameOver;
        GameEvent.current.onGamePasue += pauseRelocating;
        GameEvent.current.onGameResume += resumeRelocating;


        // For easier setup for the lower and upper range utlize two child gameobejcts
        lowerSpawnRange = lowerSpawnRangeTransform.position;
        upperSpawnRange = upperSpawnRangeTransform.position;
        //set initial random location 
        //setRandomLocation();
        InvokeRepeating("setRandomLocation", 1f, relocateTimer); // relocate object location every 30 seconds 
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            setRandomLocation();
        }*/

    }

    /// <summary>
    /// Helper function to return random spawn location 
    /// </summary>
    /// <returns></returns>
    Vector3 getRandomLocation()
    {
        float x = Random.Range(lowerSpawnRange.x, upperSpawnRange.x);
        float y = Random.Range(lowerSpawnRange.y, upperSpawnRange.y);
        float z = Random.Range(lowerSpawnRange.z, upperSpawnRange.z);
        return new Vector3(x, y, z);
    }
    
    /// <summary>
    /// set object in a random location within the range
    /// </summary>
    void setRandomLocation()
    {
        transform.position = getRandomLocation();
    }

    void onCorrectClick()
    {
        Debug.Log("Correct click relocate gameobject!");
        setRandomLocation();
    }

    void onGameOver()
    {
        // stop invokeRepeat and disaple game object 
        CancelInvoke("setRandomLocation");
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameEvent.current.onCorrectClick += onCorrectClick;
        GameEvent.current.onGameOver += onGameOver;
    }

    void pauseRelocating() {
        gameObject.SetActive(false);
    }
    void resumeRelocating()
    {
        gameObject.SetActive(true  );
    }
}
