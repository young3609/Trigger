using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point4 : MonoBehaviour {

    public int position = 0;
    public bool detect = false;
    public GameObject point4nova;
    public GameObject point4;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "BULLET")
        {
            point4.SetActive(false);
            detect = true;
            Debug.Log("COLK!");
            Debug.Log("spawnscript detect4 : " + detect);
            position = 4;
            point4nova.SetActive(true);
            Invoke("activeF", 2f);
        }
    }
    public void activeF()
    {
        point4nova.SetActive(false);
        point4.SetActive(true);
    }
}
