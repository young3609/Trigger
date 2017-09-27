using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss3 : MonoBehaviour {

    public AudioClip fireSfx;
    private AudioSource source = null;
    [SerializeField]
    private Stat health;
    public float curhealth;
    private Animation anim;
    private GameObject explain;

    void Start()
    {
        // bossanim = GameObject.Find("Boss2").GetComponent<Animation>();
        source = GetComponent<AudioSource>();
        explain = GameObject.Find("ExplainPanel");
        explain.gameObject.SetActive(false);
        anim = GameObject.Find("Boss3").GetComponent<Animation>();
    }
    // Use this for initialization
    private void Awake()
    {
        health.Initialize();
    }

    void Death()
    {
        //bossanim.Play("Die");
        Global.nextstage++;
        Global.totScore += 2000;
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health.CurrentVal -= Global.Power;
            Fire();
            if (health.CurrentVal <= 0)
            {
                anim.Play("Die");
                Invoke("Death", 2);
                explain.gameObject.SetActive(true);
            }
        }

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // DragMode 
            if (touch.phase == TouchPhase.Began)
            //if (Input.GetKeyDown(KeyCode.Space))
            {
                health.CurrentVal -= Global.Power;
                Fire();
                if (health.CurrentVal <= 0)
                {
                    Invoke("Death", 2);
                    explain.gameObject.SetActive(true);
                }
            }
        }
        // if (Input.touchCount > 0) {
        //    health.CurrentVal -= 10;
        //}
        if (Input.GetKeyDown(KeyCode.W))
        {
            health.CurrentVal += 10;
        }
        curhealth = health.CurrentVal;
    }

    void Fire()
    {
        source.PlayOneShot(fireSfx, 0.9f);
    }

    public void OKButton()
    {
        explain.gameObject.SetActive(false);
    }
}
