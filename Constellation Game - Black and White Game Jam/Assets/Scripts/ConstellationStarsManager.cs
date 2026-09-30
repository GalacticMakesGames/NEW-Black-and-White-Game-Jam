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

    public AudioSource starSelectedSound;
    public AudioSource starUnselectedSound;
    //public AudioSource constellationFoundSound;

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

        starUnselectedSound.Stop();
        //constellationFoundSound.Stop();
        starSelectedSound.Play();

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

        starSelectedSound.Stop();
        //constellationFoundSound.Stop();
        starUnselectedSound.Play();

        CheckConstellationCompletion();
    }

    private void CheckConstellationCompletion()
    {
        totalStars = activeConstellation.constellationInSearch.transform.childCount;

        Debug.Log("Number of wrongStars:" + wrongStar);
        Debug.Log("Number of clickedStars:" + clickedStars);
        Debug.Log("Number of totalStars:" + totalStars);
        Debug.Log("Just clicked star belongs to" + gameObject.name);

        if (clickedStars == totalStars && wrongStar == 0)
        {
            //starSelectedSound.Stop();
            //starUnselectedSound.Stop();
            //constellationFoundSound.Play();

            Debug.Log("All stars in " + activeConstellation.constellationInSearch.name + " have been clicked correctly!");
            ConstellationIdentified();
        }
        else if (clickedStars == totalStars && wrongStar > 0)
        {
            Debug.Log("One or more stars outside of" + activeConstellation.constellationInSearch.name + " have been selected, try again.");
        }
    }

    public void ConstellationIdentified()
    {
        GameObject activeObj = activeConstellation.constellationInSearch;
        ConstellationStarsManager activeManager = activeObj.GetComponent<ConstellationStarsManager>();
        
        Debug.Log("activeConstellation:" + activeConstellation.constellationInSearch.name);
        activeManager.constellationOverlay.SetActive(true);
        activeManager.constellationStars.SetActive(false);

        ScoreManager.instance.AddPoint();

        wrongStar = 0;
        clickedStars = 0;

        constellationCardRandomizer.OnConstellationCompleted();
    }
}
