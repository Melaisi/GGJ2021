using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  //public float RotationSpeed = 100f;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public float upLimit;
    public float downLimit;
    public float leftLimit;
    public float rightLimit;

    [SerializeField] Camera cam;

    bool isPlaying = true;

    //Rotation Sensitivity
    //float RotationSensitivity = 500.0f; // help controll how far you can see
    //float minAngle = -180.0f;
    //float maxAngle = 180.0f;

    //Rotation Value
    //float yRotate = 0.0f;
    //float xRotate = 0.0f;

    //float verticalAxis;
    //float horizontalAxis; 

    void Start()
    {
        //subscribe to gameevent 

        GameEvent.current.onGameOver += pauseMovment;
        GameEvent.current.onGamePasue += pauseMovment;
        GameEvent.current.onGamePlaying += resumeMovment;
        GameEvent.current.onGameResume += resumeMovment;

        //cam.transform.Rotate(5, 235, 0);
        //cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
    }

    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.left * RotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * RotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
        }*/

        //   verticalAxis = Input.GetAxis("Vertical");
        //    horizontalAxis = Input.GetAxis("Horizontal");

        //   transform.Rotate(Vector3.right * horizontalAxis * RotationSpeed * Time.deltaTime);
        if (isPlaying)
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");
            yaw = Mathf.Clamp(yaw, -leftLimit, rightLimit);
            pitch = Mathf.Clamp(pitch, -upLimit, downLimit);
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
        

        // Testing a solution to rotate camera based on : https://answers.unity.com/questions/762475/limit-range-camera-rotation.html 
        //Rotate Y view
        
        //yRotate += Input.GetAxis("Mouse Y") * RotationSensitivity * Time.deltaTime;
        //xRotate += Input.GetAxis("Mouse X") * RotationSensitivity * Time.deltaTime;

        //yRotate = Mathf.Clamp(yRotate, minAngle, maxAngle);
        //xRotate = Mathf.Clamp(xRotate, minAngle, maxAngle);

        //transform.eulerAngles = new Vector3(yRotate, xRotate, 0.0f);

    }

    void pauseMovment()
    {
        isPlaying = false;  
    }
    void resumeMovment()
    {
        isPlaying = true;
    }

    private void OnDestroy()
    {
        GameEvent.current.onGameOver -= pauseMovment;
        GameEvent.current.onGamePasue -= pauseMovment;
        GameEvent.current.onGamePlaying -= resumeMovment;
        GameEvent.current.onGameResume -= resumeMovment;

    }
}
