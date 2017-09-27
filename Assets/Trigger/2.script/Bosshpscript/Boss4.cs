using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Boss4 : MonoBehaviour {

    public AudioClip fireSfx;
    private AudioSource source = null;
    [SerializeField]
    private Stat health;
    public float curhealth;
    static Animator anim;
    private GameObject explain;

    void Start()
    {
        // bossanim = GameObject.Find("Boss2").GetComponent<Animation>();
        source = GetComponent<AudioSource>();
        explain = GameObject.Find("ExplainPanel");
        explain.gameObject.SetActive(false);
        anim = GameObject.Find("Boss4").GetComponent<Animator>();
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
            anim.SetTrigger("Hitplayer");
            health.CurrentVal -= Global.Power;
            Fire();
            //anim.Play("jumpBig");
            
            if (health.CurrentVal <= 0)
            {
                anim.SetBool("isdie", true);
                Invoke("Death", 2);
                explain.gameObject.SetActive(true);
            }
        }

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // DragMode 
            if (touch.phase == TouchPhase.Began)
           // if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("Hitplayer");
                health.CurrentVal -= Global.Power;
                Fire();
                if (health.CurrentVal <= 0)
                {
                    anim.SetBool("isdie", true);
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
