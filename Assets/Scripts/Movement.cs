using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float RotationSpeed = 100f;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    //Rotation Sensitivity
    //float RotationSensitivity = 500.0f; // help controll how far you can see
    //float minAngle = -180.0f;
    //float maxAngle = 180.0f;

    //Rotation Value
    //float yRotate = 0.0f;
    //float xRotate = 0.0f;

    float verticalAxis;
    float horizontalAxis; 

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

        verticalAxis = Input.GetAxis("Vertical");
        horizontalAxis = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.right * horizontalAxis * RotationSpeed * Time.deltaTime);

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        // Testing a solution to rotate camera based on : https://answers.unity.com/questions/762475/limit-range-camera-rotation.html 
        //Rotate Y view
        
        //yRotate += Input.GetAxis("Mouse Y") * RotationSensitivity * Time.deltaTime;
        //xRotate += Input.GetAxis("Mouse X") * RotationSensitivity * Time.deltaTime;

        //yRotate = Mathf.Clamp(yRotate, minAngle, maxAngle);
        //xRotate = Mathf.Clamp(xRotate, minAngle, maxAngle);

        //transform.eulerAngles = new Vector3(yRotate, xRotate, 0.0f);

    }
}
