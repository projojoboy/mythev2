﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour {

    [Header("Main Menu")]
    [SerializeField] private GameObject quitConfirmationScreen;
    [SerializeField] private GameObject mainMenu;
    //[Header("Death Screen")]

    //Main Menu
    public void ExitGame()
    {
        quitConfirmationScreen.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void LoadScene(int SceneIndexNumber)
    {
        SceneManager.LoadScene(SceneIndexNumber);
    }

    public void ConfirmQuit(bool quit)
    {
        if (quit)
            Application.Quit();
        else if (!quit)
        {
            quitConfirmationScreen.SetActive(false);
            mainMenu.SetActive(true);
        }
    }

    public void Restart()
    {
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }
}
