using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossTimer3 : MonoBehaviour {

    public Text Timertext;
    private float startTime;
    private Stat health;
    private Boss3 curhealth;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        Timertext.text = minutes + ":" + seconds;

        if (t >= 20)
        {
            Global.i++;
            SceneManager.LoadScene(2);
        }
    }
}
