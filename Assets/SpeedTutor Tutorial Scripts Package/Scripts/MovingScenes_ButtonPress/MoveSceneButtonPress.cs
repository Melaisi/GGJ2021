using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSceneButtonPress : MonoBehaviour
{
    void ButtonMoveScene(string level)
    {
        SceneManager.LoadScene(level);
    }
}
