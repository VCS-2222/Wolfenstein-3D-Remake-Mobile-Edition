using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] listOfSpawns;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("difficulty") == 1 || PlayerPrefs.GetInt("difficulty") == 2)
        {
            listOfSpawns[0].SetActive(true);
        }

        if (PlayerPrefs.GetInt("difficulty") == 3)
        {
            listOfSpawns[1].SetActive(true);
        }

        if (PlayerPrefs.GetInt("difficulty") == 4)
        {
            listOfSpawns[2].SetActive(true);
        }
    }
}