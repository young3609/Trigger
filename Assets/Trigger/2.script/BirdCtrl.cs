using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCtrl : MonoBehaviour {

    public GameObject bloodEffect;
    public AudioClip birddie;
    private AudioSource source5 = null;
    private GameUI gameUI;
    private int hp = 100;
    public bool birdcoll = false;
    Animation bird;
    void Start()
    {
        source5 = GetComponent<AudioSource>();
        gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();
        bird = GetComponent<Animation>();

    }
    void addscore()
    {
        gameUI.DispScore(100);
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "BIRD")
        {
            birdcoll = true;
            source5.PlayOneShot(birddie, 0.9f);
        }


        if (coll.gameObject.tag == "BULLET")
        {
            hp -= 100; 
            // Todo 수정중////////////////
            CreateBloodEffect(coll.transform.position);
            coll.gameObject.SetActive(false);
            //Destroy(coll.gameObject);
            source5.PlayOneShot(birddie, 0.9f);

            if (hp == 0)
            {
                addscore();
                bird.Play("death");
                CreateBloodEffect(coll.transform.position);
                coll.gameObject.SetActive(false);
                source5.PlayOneShot(birddie, 0.9f);
                Destroy(this.gameObject, 0.7f);
            }
        }
    }
    void CreateBloodEffect(Vector3 pos)
    {
        GameObject blood1 = (GameObject)Instantiate(bloodEffect, pos, Quaternion.identity);
        Destroy(blood1, 2.0f);
    }
}
