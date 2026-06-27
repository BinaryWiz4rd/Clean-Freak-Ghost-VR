using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadGameScene()
    {
        SceneManager.LoadScene("EscapeRoom");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}