using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void ResetScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}