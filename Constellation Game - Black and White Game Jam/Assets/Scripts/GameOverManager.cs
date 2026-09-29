using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject timerEndGameOverUI;
    public GameObject constellationsFoundGameOverUI;

    public ScoreManager scoreManager;
    public TextMeshProUGUI scoreResultsText;

    public TelescopeFollowMouse telescopeFollowMouse;

    // Start is called before the first frame update
    void Start()
    {
        timerEndGameOverUI.SetActive(false);
        constellationsFoundGameOverUI.SetActive(false);
        telescopeFollowMouse.enabled = true;
    }

    public void TimerEndGameOver()
    {
        timerEndGameOverUI.SetActive(true);
        scoreResultsText.text = "You found " + scoreManager.score.ToString() + " Constellations!";
        telescopeFollowMouse.enabled = false;
    }

    public void AllConstellationsFoundGameOver()
    {
        constellationsFoundGameOverUI.SetActive(true);
        telescopeFollowMouse.enabled = false;
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
        Debug.Log("Main Menu");
    }
}
