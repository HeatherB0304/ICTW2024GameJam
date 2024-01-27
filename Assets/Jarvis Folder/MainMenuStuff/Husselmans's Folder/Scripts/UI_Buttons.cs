using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour {

    public GameObject PauseMenu;
    public GameObject optionsMenu;

    public void Start() {
        PauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            PauseOrResumeGame();
        }
    }
    public void ToMainMenu() {
        SceneManager.LoadScene("MainMenuJL");
    }

    public void PauseOrResumeGame() {
        if(Time.timeScale == 1f) {
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
        }
        else if(Time.timeScale == 0f) {
            Time.timeScale = 1f;
            PauseMenu.SetActive(false);
        }
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
    }

    public void OptionsMenuButton() {
        optionsMenu.SetActive(true);
    }
    public void ReturntoPaused() {
        optionsMenu.SetActive(false);
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
