using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject aboutTheGameScreen;

    private bool aboutTheGameScreenActive = false;

    void Start()
    {
        aboutTheGameScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && aboutTheGameScreenActive == true)
        {
            aboutTheGameScreen.SetActive(false);
            aboutTheGameScreenActive = false;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Start Game");
    }

    public void AboutTheGame()
    {
        aboutTheGameScreen.SetActive(true);
        aboutTheGameScreenActive = true;
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
