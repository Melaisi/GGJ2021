using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private float numberFloat;

    [SerializeField] private GameObject player;

    [SerializeField] private bool trueOrFalse;

    void Start()
    {
        Debug.Log("Hello World");
        HelloWorldMethod();
    }

    private void Update()
    {
        Debug.Log("I AM HERE!");
    }

    private void HelloWorldMethod()
    {
        Debug.Log("MY CUSTOM METHOD");
    }
}
