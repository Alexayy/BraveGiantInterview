using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void QueScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}