using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDistory : MonoBehaviour {

    // void Start()
    //{
    //    Destroy(gameObject, 2f);
    //}

    void OnEnable()
    {
        Invoke("Destroy", 1.0f);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
