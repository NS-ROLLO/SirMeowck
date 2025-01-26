using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscToPause : MonoBehaviour
{
    public GameObject pauseMenu;

    public GameObject mainMenu;

    public GameObject credits;

    public GameObject TheActualGame;

    public GameObject metalhog;
    public void AplicationQuit()
    {
        Application.Quit();
    }

    public void SetSceneToMenuScene()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Cursor.visible = true;
        TheActualGame.SetActive(false);
        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void setPauseMenuToFalse()
    {

       pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
                Cursor.visible = false;
            }
            else
            {
                pauseMenu.SetActive(true);
                Cursor.visible = true;
            }
        }
    }
}
