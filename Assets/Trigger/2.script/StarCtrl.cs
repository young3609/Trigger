using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCtrl : MonoBehaviour {

    public float stardownspeed = 10000.0f;
    public bool starcoll= false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "COLLAREA")
        {
            Debug.Log("HERE COLL");
            GetComponent<Rigidbody>().AddForce(transform.up * stardownspeed);
        }

        if (coll.gameObject.tag == "BULLET") {
            starcoll = true;
            coll.gameObject.SetActive(false);
        }
    }
}
