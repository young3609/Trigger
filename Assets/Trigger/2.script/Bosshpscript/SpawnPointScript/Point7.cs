using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point7 : MonoBehaviour {

    public int position = 0;
    public bool detect = false;
    public GameObject point7nova;
    public GameObject point7;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("detect : "+ detect);
    }


    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "BULLET")
        {
            point7.SetActive(false);
            detect = true;
            Debug.Log("COLK!");
            Debug.Log("spawnscript detect7 : " + detect);
            position = 7;
            point7nova.SetActive(true);
            Invoke("activeF", 2f);
        }
    }
    public void activeF()
    {
        point7nova.SetActive(false);
        point7.SetActive(true);
    }
}
