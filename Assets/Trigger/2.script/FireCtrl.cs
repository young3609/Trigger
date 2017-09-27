using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FireCtrl : MonoBehaviour {

    public GameObject bullet;
    public Transform firePos;
    public AudioClip fireSfx;
    private AudioSource source = null;
    public int poolAmount = 10;
    List<GameObject> bullets;
    bool pressedfirebutton = false;

    void Start()
    {
        bullets = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(bullet);
            obj.SetActive(false);
            bullets.Add(obj);
        }
        source = GetComponent<AudioSource>();
    }
    // Update is called once per frame

    void Update()
    {
        //if(Input.GetMouseButton(0))
        if (Input.GetKeyDown("space"))
        {
            Fire();
        }
        if (pressedfirebutton) {
            Fire();
            pressedfirebutton = false;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        Debug.Log(coll.gameObject.tag);
    }

    void Fire() {
        //GameObject obj = ObjectPool.current.GetPooledObject();
        //if (obj == null) return;
        //obj.transform.position = transform.position;
        //obj.transform.rotation = transform.rotation;
        //obj.SetActive(false);
        CreateBullet();
        source.PlayOneShot(fireSfx, 0.9f);
    }

    void CreateBullet()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                bullets[i].transform.position = transform.position;
                bullets[i].transform.rotation = transform.rotation;
                bullets[i].SetActive(true);
                break;
            }
        }
        //Instantiate(bullet, firePos.position, firePos.rotation);
    }

    public void Fire_Button()
    {
        pressedfirebutton = true;
    }
}
