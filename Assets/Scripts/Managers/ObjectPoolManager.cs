using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;

    [SerializeField]
    PoolObjectData[] poolDataArray;

    Dictionary<PoolObjectType, List<GameObject>> objectPool;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        CreatePool();
    }

    private void CreatePool()
    {
        objectPool = new Dictionary<PoolObjectType, List<GameObject>>();
        foreach (PoolObjectData poolObjectData in poolDataArray)
        {
            List<GameObject> list = new List<GameObject>();
            for(int i = 0; i < poolObjectData.createCount; i++)
            {
                GameObject poolObject = Instantiate(poolObjectData.prefab, transform);
                poolObject.SetActive(false);
                list.Add(poolObject);
            }

            objectPool.Add(poolObjectData.objectType, list);
        }
    }

    private void AddObjectToPool(PoolObjectType objectType)
    {
        GameObject poolObject = Instantiate(poolDataArray.Where(x => x.objectType == objectType).First().prefab, transform);
        poolObject.SetActive(false);
        objectPool[objectType].Add(poolObject);
    }

    public GameObject GetObject(PoolObjectType objectType)
    {
        if (objectPool[objectType].Count < 1)
            AddObjectToPool(objectType);

        GameObject result = objectPool[objectType][0];
        objectPool[objectType].Remove(result);
        result.SetActive(true);
        return result;
    }

    public void ReturnObject(GameObject poolObject, PoolObjectType objectType)
    {
        poolObject.transform.parent = transform;
        poolObject.SetActive(false);
        objectPool[objectType].Add(poolObject);
    }
}

[Serializable]
public struct PoolObjectData
{
    public PoolObjectType objectType;
    public int createCount;
    public GameObject prefab;
}
