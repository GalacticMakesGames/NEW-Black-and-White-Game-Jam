using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightDaySkyTransition : MonoBehaviour
{
    public Color targetColour = Color.white;
    SpriteRenderer nightSky;

    void Start()
    {
        nightSky = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(LerpColour(targetColour, 120)); // starts colour change process
    }

    IEnumerator LerpColour(Color endValue, float duration)
    {
        float time = 0;
        Color startValue = nightSky.color;

        // continue changing colour until the time reaches full duration length
        while (time < duration)
        {
            nightSky.color = Color.Lerp(startValue, endValue, time / duration); // interpolates the colour
            time += Time.deltaTime;
            yield return null; 
        }
        nightSky.color = endValue; // ensure the final colour matches the initial target declared
    }
}
