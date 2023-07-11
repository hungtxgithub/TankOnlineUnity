using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    int playScene = 2;
    int shopScene = 3;

    public void Play()
    {
        Logger.Info("Play button clicked");
        SceneManager.LoadScene(playScene);
    }

    public void Shop()
    {
        Logger.Info("Shop button clicked");
        SceneManager.LoadScene(shopScene);
    }

    public void Exit()
    {
        Logger.Info("Exit button clicked");
        Application.Quit();
    }
}
