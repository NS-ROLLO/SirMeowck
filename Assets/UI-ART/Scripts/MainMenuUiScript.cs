using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuUiScript : MonoBehaviour
{
    public void StartGameButtonPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void QuitGame()
    {
        Debug.Log("QUIT button was pressed!!!!!!!");
        Application.Quit();
    }
}
