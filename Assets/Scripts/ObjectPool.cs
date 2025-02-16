using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectPrefab;
    public int poolSize = 10;

    public List<GameObject> poolObjects;

    void Awake()
    {
        poolObjects = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObject = Instantiate(objectPrefab);
            newObject.SetActive(false);

            poolObjects.Add(newObject);
        }
    }

    public GameObject GetAvailableObject()
    {
        for (int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                poolObjects[i].SetActive(true);
                return poolObjects[i];
            }
        }

        return null;
    }
}
