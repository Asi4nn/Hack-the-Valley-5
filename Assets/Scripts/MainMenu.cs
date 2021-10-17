using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public GameObject StartMenu;
    public GameObject DifficultyMenu;

    void OnPreRender() {
        StartMenu.SetActive(true);
        DifficultyMenu.SetActive(false);
    }

    public void StartButton() {
        Debug.Log("start game");
        StartMenu.SetActive(false);
        DifficultyMenu.SetActive(true);
    }

    public void QuitButton() {
        Debug.Log("exit game");
        Application.Quit();
    }

    public void BackButton() {
        Debug.Log("return to main menu from difficulty selection");
        StartMenu.SetActive(true);
        DifficultyMenu.SetActive(false);
    }
}
