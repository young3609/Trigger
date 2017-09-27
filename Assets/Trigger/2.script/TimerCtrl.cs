﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCtrl : MonoBehaviour {

    public Text Timertext;
    private float startTime;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        Timertext.text = minutes + ":" + seconds;

        if (t >= 20) {
            SceneManager.LoadScene(6);
        }
	}
}
