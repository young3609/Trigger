using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCtrl : MonoBehaviour {

    public GameObject bloodEffect;
    public AudioClip eggbreak;
    private AudioSource source4 = null;
    private GameUI gameUI;
    public bool eggcoll = false;
    void addscore()
    {
        gameUI.DispScore(100);
    }
    void Start(){
        source4 = GetComponent<AudioSource>();
        gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "EGG") {
            eggcoll = true;
            source4.PlayOneShot(eggbreak, 0.9f);
        }

        if (coll.gameObject.tag == "BULLET") {
            addscore();
            CreateBloodEffect(coll.transform.position);
            source4.PlayOneShot(eggbreak, 0.9f);
            coll.gameObject.SetActive(false);
            Destroy(this.gameObject,0.7f);
        }
    }
    void CreateBloodEffect(Vector3 pos) {
        GameObject blood1 = (GameObject)Instantiate(bloodEffect, pos, Quaternion.identity);
        Destroy(blood1, 2.0f);
    }
}
