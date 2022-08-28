using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    AudioManager audioManager;

    void Start() {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void ButtonSound() {
        audioManager.PlaySound("Button click");
    }

    public void MainMenuButton() {
        SceneManager.LoadScene("Menu");
    }
    
    public void ExistButton() {
        SceneManager.LoadScene("Game");
    }

    public void QuitButton() {
        Debug.Log("Quit button pressed");
        Application.Quit();
    }
}
