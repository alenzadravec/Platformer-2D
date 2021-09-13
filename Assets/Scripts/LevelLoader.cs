using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void SetRestartTrue() 
    {
        SceneManager.LoadScene("Main");
    }

    public void SetMainMenuTrue() 
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetWinTrue()
    {
        SceneManager.LoadScene("WinScreen");
    }

    public void SetLoseTrue()
    {
        SceneManager.LoadScene("LoseScreen");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
