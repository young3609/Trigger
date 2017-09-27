using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class AttackButton : MonoBehaviour {

    private float boss_hp = 100;
    private float initHp;
    public Image imgHpbar;
    public AudioClip fireSfx;
    private AudioSource source = null;
    // Use this for initialization
    void Start () {
        initHp = boss_hp;
        source = GetComponent<AudioSource>();
    }

    void Fire() {
        source.PlayOneShot(fireSfx,0.9f);
    }

    public void Attackboss() {
        if (boss_hp <= 0) {
            Debug.Log("Boss die!!");
            Global.totScore += 2000;
            SceneManager.LoadScene(1);
        }
        Fire();
        boss_hp -= 10;
        imgHpbar.fillAmount = (float)boss_hp / (float)initHp;
        Debug.Log("Attack!!");
    }

    
}
