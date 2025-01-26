using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sMainMenuScript : MonoBehaviour
{
    public GameObject metalhog;
    public GameObject mainMenu;

    public GameObject credits;

    public GameObject TheActualGame;

    private void Start()
    {
        Cursor.visible = true;
        Invoke("startOfTheGame", 3f);
        mainMenu.SetActive(false);
        TheActualGame.SetActive(false);

    }

    private void startOfTheGame()
    {
        metalhog.SetActive(false);
        mainMenu.SetActive(true);
        Cursor.visible = true;
    }
    public void StartGameButtonPress()
    {
        Cursor.visible = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        mainMenu.SetActive(false);
        TheActualGame.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT button was pressed!!!!!!!");
        Application.Quit();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("fullScreen button was pressed!!!!!!!" + isFullscreen.ToString());


    }

    public void ShotCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);

    }
    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }
}
