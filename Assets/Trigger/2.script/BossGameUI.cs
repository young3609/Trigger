using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossGameUI : MonoBehaviour {

    public Text txtScore;
    private int storescore;

    void Update()
    {
        BossDispScore(Global.totScore);
    }

    public void BossDispScore(int score)
    {
        storescore = Global.totScore;
        txtScore.text = "SCORE <color=#116D5D>" + storescore.ToString() + "</color>";
    }
}
