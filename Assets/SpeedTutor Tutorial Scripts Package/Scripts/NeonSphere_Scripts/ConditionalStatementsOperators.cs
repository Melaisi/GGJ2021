using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalStatementsOperators : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int stamina;
    [SerializeField] private int hunger;
    [SerializeField] private int thirst;

    private void Update()
    {
        if (health >= 1)
        {
            Debug.Log("You are alive!");
        }

        else if (health <= 1)
        {
            Debug.Log("You are dead!");
        }

        else
        {
            Debug.Log("You are superhuman");
        }



        if (stamina >= 1 && health >= 1)
        {
            Debug.Log("stamina and health are ok");
        }

        if (stamina >= 1 || health >= 1)
        {
            Debug.Log("If either are true");
        }
    }
}
