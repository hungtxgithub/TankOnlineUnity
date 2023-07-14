using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuController : MonoBehaviour
{
    [SerializeField]
    GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
    }

    public void ExitToMenu()
    {
        Logger.Info("Exit to menu");
        SceneManager.LoadScene(Scene.MenuScene);
    }

    public void Continue()
    {
        Logger.Info("Continue game after pause");
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void Pause()
    {
        Logger.Info("Pause game");
        Time.timeScale = 0;
        panel.SetActive(true);
    }
}
