using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	public static bool gameEnded;
	public GameObject gameOverUI;

	void Start() {
		Setup();
	}
	void Setup() {
		gameEnded = false;
	}

	void Update () {
		if(GameManager.gameOver == true) {
			if(gameEnded == false) {
				gameEnded = true;
				OpenUI();
			}
		}
	}

	void OpenUI() {
		gameOverUI.SetActive(true);
		Time.timeScale = 0f;
		gameEnded = true;
	}

	public void LoadMenu() {
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu");
		gameEnded = false;
	}

	public void QuitGame() {
		Application.Quit();
	}
}
