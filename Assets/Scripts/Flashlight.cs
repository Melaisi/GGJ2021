﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Vector3 vectOffset;
    private GameObject goFollow;
    [SerializeField] private float speed = 8.0f;

     void Start()
    {
        goFollow = Camera.main.gameObject;
        vectOffset = transform.position - goFollow.transform.position;
    }

     void Update()
    {
        transform.position = goFollow.transform.position + vectOffset;
        transform.position = Quaternion.Slerp(transform.rotation, goFollow.transform.rotation, speed * Time.deltaTime);
    }
}
