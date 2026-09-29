using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float remainingTime;
    [SerializeField] float maxTime;

    private Image moonSunProgressBar;

    public GameOverManager gameOverManager;

    private bool isTimerEnd = false;

    private void Awake()
    {
        moonSunProgressBar = GetComponent<Image>();
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            moonSunProgressBar.fillAmount = (remainingTime / maxTime);
        }
        else if (remainingTime < 0 && !isTimerEnd)
        {
            isTimerEnd = true;
            remainingTime = 0;
            gameOverManager.TimerEndGameOver();
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
    }
}
