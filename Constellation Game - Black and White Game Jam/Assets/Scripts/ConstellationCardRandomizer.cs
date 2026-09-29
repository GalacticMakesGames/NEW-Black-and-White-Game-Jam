using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationCardRandomizer : MonoBehaviour
{
    [SerializeField] GameObject[] constellationCards; // constellationCards is where the array of objects found in awake will be stored
    private int currentActiveIndex = 0; // remembers which slot is currently being processed

    public ActiveConstellation activeConstellation;

    [SerializeField] string activeCardName;

    public GameOverManager gameOverManager;

    void Awake()
    {
        constellationCards = GameObject.FindGameObjectsWithTag("Constellation Card"); // finds all constellationCards in the scene
    }

    void Start()
    {
        DeactivateAllCards();
        ShuffleCards();
        ActivateCurrentCard();
    }

    // uses Fisher-Yates shuffle algorithm to swap elements in the array to random positions
    void ShuffleCards()
    {
        for (int positionOfArray = 0; positionOfArray < constellationCards.Length; positionOfArray++)
        {
            GameObject obj = constellationCards[positionOfArray];

            int randomizeArray = Random.Range(0, positionOfArray + 1);

            constellationCards[positionOfArray] = constellationCards[randomizeArray];
            constellationCards[randomizeArray] = obj;
        }
    }

    // turns on the first card in the randomized list
    void ActivateCurrentCard()
    {
        if (currentActiveIndex < constellationCards.Length)
        {
            constellationCards[currentActiveIndex].SetActive(true);

            Debug.Log(constellationCards[currentActiveIndex].name);
            activeCardName = constellationCards[currentActiveIndex].name;
            Debug.Log("Active Card Name:" + activeCardName);
            activeConstellation.FindCurrentConstellation(constellationCards[currentActiveIndex].name);

            Debug.Log($"Currently Active Card: {constellationCards[currentActiveIndex].name} at Array Index {currentActiveIndex}");
        }
        else
        {
            Debug.Log("All constellations have been completed! There are no more cards in the array.");
            gameOverManager.AllConstellationsFoundGameOver();
        }
    }

    // the game starts with all cards turned off so there's no overlap in what's the active goal for the player
    void DeactivateAllCards()
    {
        foreach (GameObject item in constellationCards)
        {
            item.SetActive(false);
        }
    }

    // when all the correct stars have been clicked and has been identified in the constellationstarsmanager, the current card is turned off and the next one in the randomized list is turned on
    public void OnConstellationCompleted()
    {
        if (currentActiveIndex < constellationCards.Length)
        {
            constellationCards[currentActiveIndex].SetActive(false);
        }

        currentActiveIndex++;
        ActivateCurrentCard();
    }
}
