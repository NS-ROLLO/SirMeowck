using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartGameScript : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public GameObject Canvas;
    public GameObject[] TextBoxes;
    private int currentTextBoxIndex = 0;

    void Start()
    {
        vcam.m_Lens.OrthographicSize = 2.5f;
        Cursor.visible = false; // Disable mouse pointer
        startStory();
    }

    void Update()
    {
        if (Canvas.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextTextBox();
        }
    }

    void startStory()
    {
        Canvas.SetActive(true);
        ShowNextTextBox();
    }

    void ShowNextTextBox()
    {
        if (currentTextBoxIndex < TextBoxes.Length)
        {
            if (currentTextBoxIndex > 0)
            {
                TextBoxes[currentTextBoxIndex - 1].SetActive(false);
            }
            TextBoxes[currentTextBoxIndex].SetActive(true);
            currentTextBoxIndex++;
        }
        else
        {
            Canvas.SetActive(false);
            vcam.m_Lens.OrthographicSize = 7f;
        }
    }
}
