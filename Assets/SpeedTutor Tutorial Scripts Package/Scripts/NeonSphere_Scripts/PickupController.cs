using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    [SerializeField] private ScoreController scoreController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreController.UpdateScore();
            Debug.Log("PICKUP CONTROLLER TEST!");
            this.gameObject.SetActive(false);
        }
    }
}
