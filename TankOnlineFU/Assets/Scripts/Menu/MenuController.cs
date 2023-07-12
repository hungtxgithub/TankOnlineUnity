using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    int playScene = 2;

    public void Play()
    {
        Logger.Info("Play button clicked");
        Time.timeScale = 1; // Make sure game is not pause
        SceneManager.LoadScene(playScene);
    }

    public void Shop()
    {
        Logger.Info("Shop button clicked");
    }

    public void Exit()
    {
        Logger.Info("Exit button clicked");
        Application.Quit();
    }
}
