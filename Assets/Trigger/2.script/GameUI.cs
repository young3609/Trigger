using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Text txtScore;
    public Text txtScore2;
    private int show;

    // Use this for initialization
    //void Update()
    //{
    //    if (Global.count == 0)
    //    {
    //        DispScore(0);
    //        Global.count++;
    //    }
    //}

    void Start() {
        Debug.Log("totScore : " + Global.totScore);
        initScore(Global.totScore);
    }

    public void initScore(int score) {
        Global.totScore = score;
        txtScore.text = "SCORE <color=#116D5D>" + Global.totScore.ToString() + "</color>";
        txtScore2.text = "SCORE " + Global.totScore.ToString();
    }

    public void DispScore(int score)
    {
        Global.totScore += score;
        txtScore.text = "SCORE <color=#116D5D>" + Global.totScore.ToString() + "</color>";
        txtScore2.text = "SCORE " + Global.totScore.ToString();
    }
}
