using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class raserUI : MonoBehaviour {
    public Text rasertext;
    public Sprite[] hpImage = new Sprite[2];
    // Use this for initialization
    void Start () {
        if (Global.raser == false)
        {
            initRaser(Global.raser);
        }
        else {
            DispRaser(Global.raser);
        }
	}

    public void initRaser(bool raser) {
        Global.raser = false;
        rasertext.text = "RaserBeam : OFF";
        GameObject.FindWithTag("LASER").GetComponent<Image>().sprite = hpImage[0];
    }

    public void DispRaser(bool raser) {
        Global.raser = true;
        rasertext.text = "RaserBeam : ON";
        GameObject.FindWithTag("LASER").GetComponent<Image>().sprite = hpImage[1];
    }

}
