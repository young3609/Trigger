using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollManager : MonoBehaviour {

    [SerializeField]
    public Stat health;

    public AudioClip bosshit;
    AudioSource myAudio;
    // Use this for initialization
    void Start () {
        myAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "fire")
        {
            Debug.Log("coll");
            myAudio.PlayOneShot(bosshit);
            health.CurrentVal -= Global.Power;
        }
    }
}
