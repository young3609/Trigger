using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {

    float timer;
    float nextscene;
	// Use this for initialization
	void Start () {
        timer = 0.0f;
        nextscene = 4.0f;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (nextscene <= timer) {
            SceneManager.LoadScene("IntroToMain");
        }
	}
}
