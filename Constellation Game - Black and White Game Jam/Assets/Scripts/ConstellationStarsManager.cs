using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationStarsManager : MonoBehaviour
{
    public int totalStars = 0;
    private static int clickedStars = 0;

    public GameObject constellationOverlay;
    public GameObject constellationStars;

    public ConstellationCardRandomizer constellationCardRandomizer;
    public ActiveConstellation activeConstellation;

    private static int wrongStar = 0;

    // Start is called before the first frame update
    void Start()
    {
        constellationOverlay.SetActive(false);
        constellationStars.SetActive(true);
    }

    public void ReportStarClicked(GameObject clickedStarParent)
    {
        Debug.Log("ReportStarClicked: " + clickedStarParent);
        Debug.Log("constellationInSearch when clicked: " + activeConstellation.constellationInSearch.name);
        if (gameObject == clickedStarParent && clickedStarParent.name == activeConstellation.constellationInSearch.name)
        
        //if (gameObject == clickedStarParent)
        {
            clickedStars++;
            Debug.Log("A star in " + gameObject.name + " has been clicked!");
        }
        else
        {
            wrongStar++;
            Debug.Log("A star in a different constellation (" +  clickedStarParent.name + ") was clicked.");
        }

        CheckConstellationCompletion();
    }

    public void ReportStarUnclicked(GameObject clickedStarParent)
    {
        if (gameObject == clickedStarParent && clickedStarParent.name == activeConstellation.constellationInSearch.name)

        //if (gameObject == clickedStarParent)
        {
            clickedStars--;
        }
        else
        {
            wrongStar--;
        }

        CheckConstellationCompletion();
    }

    private void CheckConstellationCompletion()
    {
        totalStars = activeConstellation.constellationInSearch.transform.childCount;

        Debug.Log("Number of wrongStars:" + wrongStar);
        Debug.Log("Number of clickedStars:" + clickedStars);
        Debug.Log("Number of totalStars:" + totalStars);

        if (clickedStars == totalStars && wrongStar == 0)
        {
            Debug.Log("All stars in " + gameObject.name + " have been clicked correctly!");
            ConstellationIdentified();
        }
        else if (clickedStars == totalStars && wrongStar > 0)
        {
            Debug.Log("One or more stars outside of" + gameObject.name + " have been selected, try again.");
        }
    }

    public void ConstellationIdentified()
    {
        constellationOverlay.SetActive(true);
        constellationStars.SetActive(false);

        ScoreManager.instance.AddPoint();

        wrongStar = 0;
        clickedStars = 0;

        constellationCardRandomizer.OnConstellationCompleted();
    }
}
