using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalToBoss : MonoBehaviour {

    public GameObject POTAL;
    public GameObject POTAL2;
    public GameObject ScreenCenter;
    public bool potalcoll = false;
    public findbossTimerloading timer;
    public SphereCollider player;
    public GameObject bluenova;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            player = GameObject.Find("Player").GetComponent<SphereCollider>();
            player.isTrigger = false;
            ScreenCenter.SetActive(false);
            timer.button0n = true;
            Destroy(GameObject.Find("POTAL"));
            POTAL2.SetActive(true);
            potalcoll = true;
            bluenova.SetActive(true);
        }
    }
}
