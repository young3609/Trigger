using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundCtrl : MonoBehaviour {

    //public float hp = 100;
    //private float initHp;
    //public Image imgHpbar;
    public AudioClip starlost;
    private AudioSource source2 = null;
    public Sprite[] hpImage = new Sprite[5];

    void Start()
    {
        GameObject.FindWithTag("HPTAG").GetComponent<Image>().sprite = hpImage[Global.i];
        source2 = GetComponent<AudioSource>(); 
        //initHp = hp;
    }
 
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "STAR") {
           //// hp -= 100;
           Destroy(coll.gameObject);
           // GameObject.FindWithTag("HPTAG").GetComponent<Image>().sprite = hpImage[Global.i + 1];
           // Global.i++;
           // if (Global.i == 4) { PlayerDie(); }
           //// Debug.Log("Player HP = " + hp.ToString());
           //// imgHpbar.fillAmount = (float)hp / (float)initHp;
            source2.PlayOneShot(starlost, 0.9f);
        }

        //if (hp <= 0) {
        //    PlayerDie();
        //}
    }
    //void PlayerDie() {
    //    Debug.Log("Player Die !!");
    //}
}
