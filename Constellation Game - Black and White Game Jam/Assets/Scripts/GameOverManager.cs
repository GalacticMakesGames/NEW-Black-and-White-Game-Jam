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

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        timerEndGameOverUI.SetActive(false);
        constellationsFoundGameOverUI.SetActive(false);
        telescopeFollowMouse.enabled = true;

        audioSource = GetComponent<AudioSource>();
    }

    public void TimerEndGameOver()
    {
        timerEndGameOverUI.SetActive(true);
        scoreResultsText.text = "You found " + scoreManager.score.ToString() + " Constellations!";
        telescopeFollowMouse.enabled = false;

        audioSource.Play();
    }

    public void AllConstellationsFoundGameOver()
    {
        constellationsFoundGameOverUI.SetActive(true);
        telescopeFollowMouse.enabled = false;
        Time.timeScale = 0f;

        audioSource.Play();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        audioSource.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }

    public void MainMenu()
    {
        audioSource.Stop();
        SceneManager.LoadScene("TitleScreen");
        Debug.Log("Main Menu");
    }
}
