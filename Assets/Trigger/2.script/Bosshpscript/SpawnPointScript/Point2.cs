using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point2 : MonoBehaviour {

    public int position = 0;
    public bool detect = false;
    public GameObject point2nova;
    public GameObject point2;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "BULLET")
        {
            point2.SetActive(false);
            detect = true;
            Debug.Log("COLK!");
            Debug.Log("spawnscript detect2 : " + detect);
            position = 2;
            point2nova.SetActive(true);
            Invoke("activeF", 2f);
        }
    }
    public void activeF()
    {
        point2nova.SetActive(false);
        point2.SetActive(true);
    }
}
