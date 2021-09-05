using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] bool winScreen;
    [SerializeField] bool loseScreen;
    [SerializeField] bool mainMenuScreen;
    [SerializeField] bool restartLevel;

    // Start is called before the first frame update
    void Start()
    {
        winScreen = false;
        loseScreen = false;
        mainMenuScreen = false;
        restartLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (restartLevel) 
        {
            SceneManager.LoadScene("Main");
        }

        if (loseScreen)
        {
            SceneManager.LoadScene("LoseScreen");
        }

        if (mainMenuScreen)
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (winScreen)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    public void SetRestartTrue() 
    {
        restartLevel = true;
    }

    public void SetMainMenuTrue() 
    {
        mainMenuScreen = true;
    }

    public void SetWinTrue()
    {
        winScreen = true;
    }

    public void SetLoseTrue()
    {
        loseScreen = true;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
