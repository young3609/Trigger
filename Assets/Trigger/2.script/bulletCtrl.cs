using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCtrl : MonoBehaviour {

    public int damage = 20;

    public float speed = 3000.0f;
    private Rigidbody stardown;
    private int i = 1;
    public float stardownspeed = 3000.0f;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().AddForce(transform.up*speed);
	}


    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "STAR")
        {
            //stardown = GameObject.Find("Star0(Clone)").GetComponent<Rigidbody>();
            stardown = coll.gameObject.GetComponent<Rigidbody>();
            //Debug.Log(i);
            Debug.Log("COLL");
           // Destroy(coll1.gameObject);
            stardown.useGravity = true;
            //GameObject.Find("Star0(Clone)").GetComponent<Rigidbody>().AddForce(-transform.up * stardownspeed);
            coll.gameObject.GetComponent<Rigidbody>().AddForce(-transform.up * stardownspeed);
            // i++;
        }
    }

}
