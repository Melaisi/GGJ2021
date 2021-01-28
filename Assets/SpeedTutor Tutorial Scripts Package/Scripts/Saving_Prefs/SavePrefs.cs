using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    [SerializeField] private int myLoadInt;

    private void Start()
    {
        PlayerPrefs.SetInt("Score", 20);

        PlayerPrefs.SetFloat("FloatScore", 27.3f);

        PlayerPrefs.SetString("MyString", "Help me!");
    }

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            LoadPrefs();
        }
    }

    private void LoadPrefs()
    {
        myLoadInt = PlayerPrefs.GetInt("Score");
    }
}
