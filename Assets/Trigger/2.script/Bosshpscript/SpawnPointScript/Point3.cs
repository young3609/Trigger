using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point3 : MonoBehaviour {

    public int position = 0;
    public bool detect = false;
    public GameObject point3nova;
    public GameObject point3;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "BULLET")
        {
            point3.SetActive(false);
            detect = true;
            Debug.Log("COLK!");
            Debug.Log("spawnscript detect3 : " + detect);
            position = 3;
            point3nova.SetActive(true);
            Invoke("activeF", 2f);
        }
    }
    public void activeF()
    {
        point3nova.SetActive(false);
        point3.SetActive(true);
    }
}
