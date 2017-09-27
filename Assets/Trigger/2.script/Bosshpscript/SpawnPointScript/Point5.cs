using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point5 : MonoBehaviour {

    public int position = 0;
    public bool detect = false;
    public GameObject point5nova;
    public GameObject point5;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "BULLET")
        {
            point5.SetActive(false);
            detect = true;
            Debug.Log("COLK!");
            Debug.Log("spawnscript detect5 : " + detect);
            position = 5;
            point5nova.SetActive(true);
            Invoke("activeF", 2f);
        }
    }
    public void activeF()
    {
        point5nova.SetActive(false);
        point5.SetActive(true);
    }
}
