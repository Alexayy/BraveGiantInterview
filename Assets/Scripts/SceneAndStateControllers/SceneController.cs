using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void ResetScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
