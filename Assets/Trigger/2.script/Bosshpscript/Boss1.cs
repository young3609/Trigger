using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Boss1 : MonoBehaviour {

    public AudioClip fireSfx;
    private AudioSource source = null;
    [SerializeField]
    private Stat health;
    public float curhealth;
    private Animation anim;
    private GameObject explain;

    void Start()
    {
        source = GetComponent<AudioSource>();
        explain = GameObject.Find("ExplainPanel");
        explain.gameObject.SetActive(false);
        //anim = GameObject.Find("Boss1").GetComponent<Animation>();
    }
    // Use this for initialization
    private void Awake()
    {
        health.Initialize();
    }

    void Death()
    {
        Global.nextstage++;
        Global.totScore += 2000;
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0)) 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health.CurrentVal -= Global.Power;
            Fire();
            if (health.CurrentVal <= 0)
            {
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
