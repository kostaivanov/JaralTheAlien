﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    internal static ObjectPooler current;
    [SerializeField] internal List<GameObject> pooledObjectsArray;
    [SerializeField] internal GameObject pooledLaserObject, pooledBigBlastObject;
    [SerializeField] private int pooledAmount;
    [SerializeField] private int pooledAmountLasers, pooledAmountBigBlasts;
    [SerializeField] private bool willGrow, willLaserObjectsGrow, willBigBlastsGrow;

    internal List<GameObject> pooledObjects, pooledLasers, pooledBigBlasts;
    // Start is called before the first frame update
    [SerializeField] internal GameObject firePositionObject, parentInstantiateObject;
    private void Awake()
    {
        current = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        pooledLasers = new List<GameObject>();
        pooledBigBlasts = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            //GameObject obj = Instantiate(pooledObjectsArray[Random.Range(0, pooledObjectsArray.Count)]);
            GameObject obj_1 = Instantiate(pooledObjectsArray[0]);
            obj_1.transform.parent = parentInstantiateObject.transform;
            GameObject obj_2 = Instantiate(pooledObjectsArray[1]);
            obj_2.transform.parent = parentInstantiateObject.transform;
            GameObject obj_3 = Instantiate(pooledObjectsArray[2]);
            obj_3.transform.parent = parentInstantiateObject.transform;
            GameObject obj_4 = Instantiate(pooledObjectsArray[3]);
            obj_4.transform.parent = parentInstantiateObject.transform;
            GameObject obj_5 = Instantiate(pooledObjectsArray[4]);
            obj_5.transform.parent = parentInstantiateObject.transform;
            obj_1.SetActive(false);
            obj_2.SetActive(false);
            obj_3.SetActive(false);
            obj_4.SetActive(false);
            obj_5.SetActive(false);

            pooledObjects.Add(obj_1);
            pooledObjects.Add(obj_2);
            pooledObjects.Add(obj_3);
            pooledObjects.Add(obj_4);
            pooledObjects.Add(obj_5);
        }

        for (int i = 0; i < pooledAmountLasers; i++)
        {
            GameObject laserObj = Instantiate(pooledLaserObject);
            laserObj.transform.parent = parentInstantiateObject.transform;
            laserObj.SetActive(false);
            pooledLasers.Add(laserObj);
        }

        for (int i = 0; i < pooledAmountBigBlasts; i++)
        {
            GameObject bigBlastObj = Instantiate(pooledBigBlastObject);
            bigBlastObj.transform.parent = parentInstantiateObject.transform;
            bigBlastObj.SetActive(false);
            pooledBigBlasts.Add(bigBlastObj);
        }
    }

    internal GameObject GetPooledObject(string typeObject)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            string[] prefabsFullName = pooledObjects[i].name.Split(new char[] { '(', ')' }, System.StringSplitOptions.RemoveEmptyEntries);
            string name = prefabsFullName[0];

            if (name == typeObject && !pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }      

        if (willGrow == true)
        {
            //GameObject obj = Instantiate(pooledObjectsArray[Random.Range(0, pooledObjectsArray.Count)]);
            for (int i = 0; i < pooledObjectsArray.Count; i++)
            {
                if (typeObject == pooledObjectsArray[i].name)
                {
                    GameObject obj = Instantiate(pooledObjectsArray[i]);
                    obj.transform.parent = parentInstantiateObject.transform;
                    pooledObjects.Add(obj);
                    return obj;
                }               
            }
        }

        return null;
    }

    internal GameObject GetPooledLaserObject()
    {
        for (int i = 0; i < pooledLasers.Count; i++)
        {
            if (!pooledLasers[i].activeInHierarchy)
            {
                return pooledLasers[i];
            }
        }

        if (willLaserObjectsGrow == true)
        {
            GameObject laserObj = Instantiate(pooledLaserObject);
            laserObj.transform.parent = parentInstantiateObject.transform;
            pooledLasers.Add(laserObj);
            return laserObj;
        }

        return null;
    }


    internal GameObject GetPooledBigBlastObject()
    {
        for (int i = 0; i < pooledBigBlasts.Count; i++)
        {
            if (!pooledBigBlasts[i].activeInHierarchy)
            {
                return pooledBigBlasts[i];
            }
        }

        if (willBigBlastsGrow == true)
        {
            GameObject bigBlastObj = Instantiate(pooledBigBlastObject);
            bigBlastObj.transform.parent = parentInstantiateObject.transform;
            pooledBigBlasts.Add(bigBlastObj);
            return bigBlastObj;
        }

        return null;
    }
}
