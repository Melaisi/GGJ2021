using System.Collections;
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
    [SerializeField] Vector3 lowerSpawnRange;
    [SerializeField] Vector3 upperSpawnRange;
    [SerializeField] float relocateTimer=30f; //in Seconds  

    // Start is called before the first frame update
    void Start()
    {
        //set initial random location 
        //setRandomLocation();
        InvokeRepeating("setRandomLocation", 1f, relocateTimer); // relocate object location every 30 seconds 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            setRandomLocation();
        }

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


}
