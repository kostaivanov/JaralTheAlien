using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteorites : MonoBehaviour
{

    private float nextSpawnTimeBig = 0f;
    private string[] meteoritesNames = new string[] { "BigMeteorite" , "MediumMeteorite", "SmallMeteorite" };
    private string[] laserNames = new string[] { "LaserItem", "LaserItemRed" };

    [SerializeField] internal float addToSpawnTime;
    internal float initialSpawnTime;
    public float chanceSpawnRare = 0.1f;

    private float InstantiationTimer;

    private GameObject inGame;
    // Start is called before the first frame update
    void Start()
    {
        initialSpawnTime = addToSpawnTime;
        //nextSpawnTimeBig = Time.time + addToSpawnTime;
        PermanentFunctions.instance.OnIncreaseSpeed += IncreaseRateOfSpawnMeteorites;

        //nextSpawnTimeMedium = Time.time + 3f;
        //nextSpawnTimeSmall = Time.time + 1f;
        InstantiationTimer = addToSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (inGame == null)
        {
            inGame = GameObject.FindGameObjectWithTag("InGame");
        }

        //Debug.Log("Time - " + Time.time);
        //Debug.Log("Next spawn - " + nextSpawnTimeBig);

        if (inGame != null && inGame.activeSelf == true)
        {
            InstantiationTimer -= Time.deltaTime;
            if (InstantiationTimer <= 0)
            {
                SpawnMeteorite(nextSpawnTimeBig);
                InstantiationTimer = addToSpawnTime;
                //Debug.Log("InstantiationTimer - " + InstantiationTimer);
            }
        }

        
    }

    private void SpawnMeteorite(float spawnTime)
    {
        //if (Time.time > spawnTime)
        //{
            string typeObject = string.Empty;

            if (Random.Range(0f, 0.8f) > chanceSpawnRare)
            {
                typeObject = meteoritesNames[Random.Range(0, meteoritesNames.Length)];
            }
            else
            {
                typeObject = laserNames[Random.Range(0, laserNames.Length)];
            }

            GameObject obj = ObjectPooler.current.GetPooledObject(typeObject);

            if (obj == null)
            {
                return;
            }
            obj.transform.position = this.transform.position;
            obj.transform.rotation = this.transform.rotation;
            obj.SetActive(true);

            //nextSpawnTimeBig += addToSpawnTime;
        //}
    }

    private void IncreaseRateOfSpawnMeteorites()
    {
        if (addToSpawnTime >= 0)
        {
            addToSpawnTime -= 0.2f;
        }

    }
}
