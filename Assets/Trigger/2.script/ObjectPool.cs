using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    public static ObjectPool current;
    public GameObject pooledObject;
    public int poolAmount = 20;

    List<GameObject> pooledObjects;
    // Use this for initialization

    void Awake()
    {
        current = this;
    }

    void Start () {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++) {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(obj);
        }
	}

    public GameObject GetPooledObject() {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
