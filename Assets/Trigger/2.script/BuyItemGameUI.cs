using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemGameUI : MonoBehaviour {

    public Text txtScore;
    private int storescore;

    void Update()
    {
        BuyItemDispScore(Global.totScore);
    }

    public void BuyItemDispScore(int score)
    {
        storescore = Global.totScore;
        txtScore.text = "SCORE <color=#116D5D>" + storescore.ToString() + "</color>";
    }
}
