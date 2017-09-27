using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point6 : MonoBehaviour {

    public int position = 0;
    public bool detect = false;
    public GameObject point6nova;
    public GameObject point6;


    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "BULLET")
        {
            point6.SetActive(false);
            detect = true;
            Debug.Log("COLK!");
            Debug.Log("spawnscript detect6 : " + detect);
            position = 6;
            point6nova.SetActive(true);
            Invoke("activeF", 2f);
        }
    }
    public void activeF()
    {
        point6nova.SetActive(false);
        point6.SetActive(true);
    }
}
