using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveConstellation : MonoBehaviour
{
    [SerializeField] GameObject[] currentConstellation; // constellation is where the array of objects found in awake will be stored

    public GameObject constellationInSearch; // constellation being searched that corresponds to the active card

    void Awake()
    {
        currentConstellation = GameObject.FindGameObjectsWithTag("Constellation"); // finds all constellations in the scene
    }

    // find constellation that corresponds to the currently active constellation card
    public void FindCurrentConstellation(string constellationName)
    {
        for (int i = 0; i < currentConstellation.Length; i++)
        { //currentConstellation[i] != null && 
            if (currentConstellation[i].name == constellationName)
            {
                constellationInSearch = currentConstellation[i];
                Debug.Log("constellationInSearch: " +  constellationInSearch.name);
                break;
            }
        }
    }
}
