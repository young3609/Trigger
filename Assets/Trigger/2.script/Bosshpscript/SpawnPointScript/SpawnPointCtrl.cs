using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointCtrl : MonoBehaviour {
    public int position = 0;
    public bool detect = false;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("detect : "+ detect);
    }
     

    void OnTriggerEnter(Collider coll) {
        if (coll.gameObject.tag == "Point1")
        {
            detect = true;
            Debug.Log("COLK!");
            Debug.Log("spawnscript detect : "+detect);
            position = 1;
        }
        if (coll.gameObject.tag == "Point2")
        {
            detect = true;
            Debug.Log("COLK!");
            Debug.Log("spawnscript detect : " + detect);
            position = 2;
        }
        if (coll.gameObject.tag == "Point3")
        {
            detect = true;
            Debug.Log("COLK!");
            Debug.Log("spawnscript detect : " + detect);
            position = 3;
        }
        if (coll.gameObject.tag == "Point4")
        {
            detect = true;
            Debug.Log("COLK!");
            Debug.Log("spawnscript detect : " + detect);
            position = 4;
        }
        if (coll.gameObject.tag == "Point5")
        {
            detect = true;
            Debug.Log("COLK!");
            Debug.Log("spawnscript detect : " + detect);
            position = 5;
        }
        if (coll.gameObject.tag == "Point6")
        {
            detect = true;
            Debug.Log("COLK!");
            Debug.Log("spawnscript detect : " + detect);
            position = 6;
        }
        if (coll.gameObject.tag == "Point7")
        {
            detect = true;
            Debug.Log("COLK!");
            Debug.Log("spawnscript detect : " + detect);
            position = 7;
        }
        if (coll.gameObject.tag == "Point8")
        {
            detect = true;
            Debug.Log("COLK!");
            Debug.Log("spawnscript detect : " + detect);
            position = 8;
        }

    }
}
