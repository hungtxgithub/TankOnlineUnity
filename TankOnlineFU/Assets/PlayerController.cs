using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private GameObject gameOverPanel;

	private void Start()
	{
		gameOverPanel = GameObject.FindGameObjectWithTag("GameOverPanel");
		gameOverPanel?.SetActive(false);
	}


	private void OnDestroy()
	{
		gameOverPanel?.SetActive(true);
	}
}
