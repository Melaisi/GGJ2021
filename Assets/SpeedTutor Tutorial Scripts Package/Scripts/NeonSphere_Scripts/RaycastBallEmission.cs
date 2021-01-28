using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBallEmission : MonoBehaviour
{
    GameObject player;
    RaycastHit hit;
    Ray ray;
    Vector3 mousePos, smoothpoint;
    public float radius, softness, smoothSpeed, scaleFactor;

    private void Update()
    {
       /* if (Input.GetKey(KeyCode.UpArrow))
        {
            radius += scaleFactor * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            radius -= scaleFactor * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            softness += scaleFactor * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            softness -= scaleFactor * Time.deltaTime;
        }
        Mathf.Clamp(radius, 0, 100);
        Mathf.Clamp(softness, 0, 100);*/

        //mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        //ray = player.ScreenPointToRay(mousePos);

        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            smoothpoint = Vector3.MoveTowards(smoothpoint, hit.point, smoothSpeed * Time.deltaTime);
            Vector4 pos = new Vector4(smoothpoint.x, smoothpoint.y, smoothpoint.z, 0);
            Shader.SetGlobalVector("GLOBALmask_Position", pos);
        }

        Shader.SetGlobalFloat("GLOBALmask_Radius", radius);
        Shader.SetGlobalFloat("GLOBALmask_Softness", softness);
    }
}
