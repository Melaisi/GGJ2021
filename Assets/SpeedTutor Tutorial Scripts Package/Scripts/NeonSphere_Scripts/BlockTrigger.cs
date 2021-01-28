using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTrigger : MonoBehaviour
{
    [SerializeField] private HealthController myHealthController;
    [SerializeField] private PlayerController myPlayerController;
    [SerializeField] private int damage;
    [SerializeField] private int heal;

    [SerializeField] private bool damageBool;
    [SerializeField] private bool healBool;
    [SerializeField] private bool speedBoost;
    [SerializeField] private bool jumpBoost;

    [SerializeField] private int boostedSpeed;
    [SerializeField] private int boostedJump;

    [SerializeField] private int delay;

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && damageBool)
        {
            myHealthController.playerHealth = myHealthController.playerHealth - damage;
            myHealthController.UpdateHealth();
        }

        else if (other.CompareTag("Player") && healBool)
        {
            myHealthController.playerHealth = myHealthController.playerHealth + heal;
            myHealthController.UpdateHealth();
        }

        else if (other.CompareTag("Player") && speedBoost)
        {
            myPlayerController.speed = boostedSpeed;
            yield return new WaitForSeconds(delay);
            myPlayerController.speed = myPlayerController.normSpeed;
            this.gameObject.SetActive(false);
        }

        else if (other.CompareTag("Player") && jumpBoost)
        {
            myPlayerController.jumpForce = boostedJump;
            yield return new WaitForSeconds(delay);
            myPlayerController.jumpForce = myPlayerController.normJumpForce;
            this.gameObject.SetActive(false);
        }
    }
}


















/*    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && damageBool)
        {
            myHealthController.playerHealth = myHealthController.playerHealth - damage;
        }

        else if (other.CompareTag("Player") && healBool)
        {
            myHealthController.playerHealth = myHealthController.playerHealth + heal;
        }
    }*/
               