using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverManager : MonoBehaviour {

    Animator anim;
    float restartTimer;
    public Timerloading timer;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () {
        if (Global.i == 4 ) {
            anim.SetTrigger("GameOver");

            restartTimer += Time.deltaTime;
            timer.button0n = true;
            if (Global.gameend == 1) {
                SceneManager.LoadScene("main_view");
            }
        }
	}
}
