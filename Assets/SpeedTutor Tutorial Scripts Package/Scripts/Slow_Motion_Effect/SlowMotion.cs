using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class SlowMotion : MonoBehaviour
{
    private float slowMo = 0.1f;
    private float normTime = 1.0f;
    private bool doSlowMo = false;

    //[SerializeField] private FirstPersonController player;
    [SerializeField] private Text textUI;

    /*void Update()
    {
        if (player.m_CharacterController.velocity.magnitude > 0)
        {
            if (doSlowMo)
            {
                Time.timeScale = normTime;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                textUI.text = Time.timeScale.ToString("0");
                doSlowMo = false;
            }
        }
        else
        {
            if (!doSlowMo)
            {
                Time.timeScale = slowMo;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                textUI.text = Time.timeScale.ToString("0");
                doSlowMo = true;
            }
        }
    }*/
}
