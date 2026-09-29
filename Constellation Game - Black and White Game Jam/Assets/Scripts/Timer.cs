using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float remainingTime;
    [SerializeField] float maxTime;

    private Image moonSunProgressBar;

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
        else if (remainingTime < 0)
        {
            remainingTime = 0;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
    }
}
