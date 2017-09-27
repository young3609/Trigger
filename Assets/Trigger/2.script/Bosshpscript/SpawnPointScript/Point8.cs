using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point8 : MonoBehaviour {

    public int position = 0;
    public bool detect = false;
    public GameObject point8nova;
    public GameObject point8;



    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "BULLET")
        {
            point8.SetActive(false);
            detect = true;
            Debug.Log("COLK!");
            Debug.Log("spawnscript detect8 : " + detect);
            position = 8;
            point8nova.SetActive(true);
            Invoke("activeF", 2f);
        }
    }
    public void activeF()
    {
        point8nova.SetActive(false);
        point8.SetActive(true);
    }
}
