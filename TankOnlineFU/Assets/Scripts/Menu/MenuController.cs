using Assets.Scripts.TopUpDiamond;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

	private void Start()
	{
        Time.timeScale = 1; // Make sure game is not pause
	}

	public void Play()
    {
        Logger.Info("Play button clicked");
        SceneManager.LoadScene(Scene.ListMapScene);
    }

    public void PlaySolo()
    {
        SceneManager.LoadScene(Scene.TwoPlayerScene);
    }

    public void PlayContruction()
    {
        Logger.Info("Play contruction mode");
        SceneManager.LoadScene(Scene.ContructionScene);

    }

    public void Exit()
    {
        Logger.Info("Exit button clicked");
        Application.Quit();
    }

    public void RefreshTopUp()
    {
        new RefreshTopUp();
    }

    public void ShowContentTopUp()
    {
        new ContentTopUp().ShowContentTopUp();
    }
}
