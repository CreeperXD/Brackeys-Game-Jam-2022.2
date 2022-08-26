using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
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
