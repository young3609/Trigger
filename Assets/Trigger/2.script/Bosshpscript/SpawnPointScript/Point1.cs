using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point1 : MonoBehaviour {

    public int position = 0;
    public bool detect = false;
    public GameObject point1nova;
    public GameObject point1;

    // Update is called once per frame

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "BULLET")
        {
            point1.SetActive(false);
            detect = true;
            Debug.Log("COLK!");
            Debug.Log("spawnscript detect1 : " + detect);
            position = 1;
            point1nova.SetActive(true);
            Invoke("activeF", 2f);
        }
    }

    public void activeF() {
        point1nova.SetActive(false);
        point1.SetActive(true);
    }
}
