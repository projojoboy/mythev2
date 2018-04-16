using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour {

    [SerializeField] private GameObject quitConfirmationScreen;
    [SerializeField] private GameObject mainMenu;

    public void ExitGame()
    {
        quitConfirmationScreen.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void StartGame()
    {
        //Load scene(moet nog scene hebben)
        //SceneManager.LoadScene();
        Debug.Log("StartGame!");
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
}
