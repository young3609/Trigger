using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuyItemButtonCtrl : MonoBehaviour {

    private GameUI gameUI;
    private GameObject explain;
    public Sprite[] curweaponimage = new Sprite[15];
    private int weapon;
    public GameObject rednova;
    public GameObject rednova2;

    void Start() {
        gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();
        explain = GameObject.Find("ExplainPanel");
        explain.gameObject.SetActive(false);
    }

    private void Update()
    {
        GameObject.FindWithTag("CURWEAPON").GetComponent<Image>().sprite = curweaponimage[weapon];
    }

    public void Button1() {

        Global.Power = 1;
        if (Global.totScore >= 1000)
        {
            Global.totScore -= 1000;
            Global.buyweapon = 12;
            weapon = 0;
            rednova.SetActive(true);
            Invoke("novaoff", 1f);
        }else
        {
            explain.gameObject.SetActive(true);
        }
    }
    public void Button2()
    {
        Global.Power = 2;
        if (Global.totScore >= 2000)
        {
            Global.totScore -= 2000;
            Global.buyweapon = 12;
            weapon = 1;
            rednova2.SetActive(true);
            Invoke("novaoff", 1f);
        }
        else
        {
            explain.gameObject.SetActive(true);
        }
    }
    public void Button3()
    {
        Global.Power = 3;
        if (Global.totScore >= 3000)
        {
            Global.totScore -= 3000;
            Global.buyweapon = 12;
            weapon = 2;
            rednova.SetActive(true);
            Invoke("novaoff", 1f);
        }
        else
        {
            explain.gameObject.SetActive(true);
        }
    }
    public void Button4()
    {

        Global.Power = 4;
        if (Global.totScore >= 4000)
        {
            Global.totScore -= 4000;
            Global.buyweapon = 0;
            weapon = 3;
            rednova2.SetActive(true);
            Invoke("novaoff", 1f);
        }
        else
        {
            explain.gameObject.SetActive(true);
        }
    }
    //public void Button5()
    //{

    //    Global.Power = 5;
    //    if (Global.totScore >= 5000)
    //    {
    //        Global.totScore -= 5000;
    //        Global.buyweapon = 1;
    //    }
    //    else
    //    {
    //        explain.gameObject.SetActive(true);
    //    }
    //}
    public void Button6()
    {
        Global.Power = 5;
        if (Global.totScore >= 6000)
        {
            Global.totScore -= 6000;
            Global.buyweapon = 2;
            weapon = 4;
            rednova.SetActive(true);
            Invoke("novaoff", 1f);
        }
        else
        {
            explain.gameObject.SetActive(true);
        }
    }
    public void Button7()
    {

        Global.Power = 6;
        if (Global.totScore >= 7000)
        {
            Global.totScore -= 7000;
            Global.buyweapon = 3;
            weapon = 5;
            rednova2.SetActive(true);
            Invoke("novaoff", 1f);
        }
        else
        {
            explain.gameObject.SetActive(true);
        }
    }
    public void Button8()
    {

        Global.Power = 7;
        if (Global.totScore >= 8000)
        {
            Global.totScore -= 8000;
            Global.buyweapon = 4;
            weapon = 6;
        }
        else
        {
            explain.gameObject.SetActive(true);
        }
    }

    public void Button9()
    {

        Global.Power = 8;
        if (Global.totScore >= 9000)
        {
            Global.totScore -= 9000;
            Global.buyweapon = 5;
            weapon = 7;
            rednova.SetActive(true);
            Invoke("novaoff", 1f);
        }
        else
        {
            explain.gameObject.SetActive(true);
        }
    }

    public void Button10()
    {

        Global.Power = 9;
        if (Global.totScore >= 10000)
        {
            Global.totScore -= 10000;
            Global.buyweapon = 6;
            weapon = 8;
            rednova2.SetActive(true);
            Invoke("novaoff", 1f);
        }
        else
        {
            explain.gameObject.SetActive(true);
        }
    }

    public void Button11()
    {

        Global.Power = 10;
        if (Global.totScore >= 11000)
        {
            Global.totScore -= 11000;
            Global.buyweapon = 7;
            weapon = 9;
            rednova.SetActive(true);
            Invoke("novaoff", 1f);
        }
        else
        {
            explain.gameObject.SetActive(true);
        }
    }

    public void Button12()
    {

        Global.Power = 12;
        if (Global.totScore >= 12000)
        {
            Global.totScore -= 12000;
            Global.buyweapon = 8;
            weapon = 10;
            rednova2.SetActive(true);
            Invoke("novaoff", 1f);
        }
        else
        {
            explain.gameObject.SetActive(true);
        }
    }

    public void Button13()
    {

        Global.Power = 13;
        if (Global.totScore >= 13000)
        {
            Global.totScore -= 13000;
            Global.buyweapon = 9;
            weapon = 11;
            rednova.SetActive(true);
            Invoke("novaoff", 1f);
        }
        else
        {
            explain.gameObject.SetActive(true);
        }
    }

    public void Button14()
    {

        Global.Power = 14;
        if (Global.totScore >= 14000)
        {
            Global.totScore -= 14000;
            Global.buyweapon = 10;
            weapon = 12;
            rednova2.SetActive(true);
            Invoke("novaoff", 1f);
        }
        else
        {
            explain.gameObject.SetActive(true);
        }
    }

    public void Button15()
    {

        //Global.Power = 15;
        Global.Power = 15;
        if (Global.totScore >= 15000)
        {
            Global.totScore -= 15000;
            Global.buyweapon = 11;
            weapon = 13;
            rednova.SetActive(true);
            Invoke("novaoff", 1f);
        }
        else
        {
            explain.gameObject.SetActive(true);
        }
    }

    public void Button16()
    {
        Global.Power = 16;
        if (Global.totScore >= 16000)
        {
            Global.totScore -= 16000;
            Global.buyweapon = 12;
            weapon = 14;
            rednova2.SetActive(true);
            Invoke("novaoff", 1f);
        }
        else
        {
            explain.gameObject.SetActive(true);
        }
    }

    public void ShowCurweaponImage() {
        if (Global.totScore >= 10000)
        {
           // Global.totScore -= 10000;
            //SceneManager.LoadScene(19);
        }
        else
        {
            explain.gameObject.SetActive(true);
        }
    }

    public void novaoff() {
        rednova.SetActive(false);
        rednova2.SetActive(false);
    }

    public void OKButton() {
        explain.gameObject.SetActive(false);
    }
}
