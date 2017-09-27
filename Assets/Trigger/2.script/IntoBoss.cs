using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntoBoss : MonoBehaviour
{
    public float restartDelay = 5f;

    Animator anim;
    float restartTimer;
    public PotalToBoss potal;
    public bool nextscene = false;
    public findbossTimerloading loader;
    private bool isinstall = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (potal.potalcoll == true)
        {
            anim.SetTrigger("GotoBoss");
            Global.next = 0;
            restartTimer += Time.deltaTime;

            if (isinstall == false && restartTimer >= restartDelay) {
                loader.LoadLevel("boss_view");
                isinstall = true;
            }
        }
    }
}
