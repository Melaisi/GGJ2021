using System.Collections;
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

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd*10, Color.green);
        layerMaskInteract = LayerMask.GetMask("target");


        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract))
        {
            Debug.Log(" ray intersects with a Collider");
            if (hit.collider.CompareTag("Object"))
            {
                raycastedObj = hit.collider.gameObject;
                CrosshairActive();

                if (Input.GetKeyDown("e"))
                {
                    Debug.Log("I HAVE INTERACTED WITH AN OBJECT!");
                    raycastedObj.SetActive(false);
                }
            }
        }
        else
        {
            CrosshairNormal();
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
}
