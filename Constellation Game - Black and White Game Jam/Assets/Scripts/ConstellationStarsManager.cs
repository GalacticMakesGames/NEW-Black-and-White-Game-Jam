using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationStarsManager : MonoBehaviour
{
    private int totalStars = 0;
    private int clickedStars = 0;

    public GameObject constellationOverlay;
    public GameObject constellationStars;

    // Start is called before the first frame update
    void Start()
    {
        totalStars = transform.childCount;
        constellationOverlay.SetActive(false);
        constellationStars.SetActive(true);
    }

    public void ReportStarClicked()
    {
        clickedStars++;

        if (clickedStars == totalStars)
        {
            Debug.Log("All stars in " + gameObject.name + " have been clicked!");
            ConstellationIdentified();
        }
    }

    public void ReportStarUnclicked()
    {
        clickedStars--;

        if (clickedStars == totalStars)
        {
            Debug.Log("All stars in " + gameObject.name + " have been clicked!");
            ConstellationIdentified();
        }
    }

    public void ConstellationIdentified()
    {
        constellationOverlay.SetActive(true);
        constellationStars.SetActive(false);
    }
}
