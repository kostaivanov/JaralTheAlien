using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSpawn : MonoBehaviour
{
    [SerializeField] List<SpawnMeteorites> objetsSpawnPlaces;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject menuScreen;

    private bool valuesAreReset;

    // Start is called before the first frame update
    void Start()
    {
        valuesAreReset = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverScreen.activeSelf == true || menuScreen.activeSelf == true)
        {
            if (valuesAreReset == false)
            {
                Debug.Log("kolko pyti se resetvat spawnovete");
                valuesAreReset = true;
                foreach (SpawnMeteorites spawnPlace in objetsSpawnPlaces)
                {
                    spawnPlace.addToSpawnTime = spawnPlace.initialSpawnTime;
                }
            }
        }
        else
        {
            if (valuesAreReset == true)
            {
                valuesAreReset = false;
                Debug.Log("kolko pyti se resetva boola");
            }
        }
    }
}
