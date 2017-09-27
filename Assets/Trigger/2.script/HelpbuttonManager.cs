using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpbuttonManager : MonoBehaviour {

    /////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// test
    /// </summary>
    public Sprite[] LevelObj = new Sprite[4];
    //float timer = 1f;
    //float delay = 5f;
    int i = 0;
    void Start()
    {
        GameObject.FindWithTag("userTag1").GetComponent<SpriteRenderer>().sprite = LevelObj[0];
    }
  
    public void onClickNextButton()
    {
        Debug.Log(i);

        if (i + 1 == 4) { i = 0; GameObject.FindWithTag("userTag1").GetComponent<SpriteRenderer>().sprite = LevelObj[0]; }
        else { GameObject.FindWithTag("userTag1").GetComponent<SpriteRenderer>().sprite = LevelObj[i + 1]; i++; }
    }

    public void onClickPrevButton() {
        Debug.Log(i);

        if (i - 1 < 0) { i = 3; GameObject.FindWithTag("userTag1").GetComponent<SpriteRenderer>().sprite = LevelObj[3]; }
        else { GameObject.FindWithTag("userTag1").GetComponent<SpriteRenderer>().sprite = LevelObj[i - 1]; i--; }
    }

    //void Update()
    //{
    //    timer -= Time.deltaTime;
    //    if (timer <= 0) {
    //        for(int i = 0; i < 3; i++) {
    //            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == LevelObj[i])
    //            {
    //                if (i + 1 == 3) { i = 0; this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelObj[0]; }
    //                else { this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelObj[i + 1]; }
    //                timer = delay;
    //                return;
    //            }
    //        }
    //    }
    //}

    //################################################ test1
    //  private SpriteRenderer Level_Image;
    //int count = 0;
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0)) {
    //        Level_Image = GetComponent<SpriteRenderer>();
    //        gameObject.GetComponent<Image>().sprite = LevelObj[count++];
    //    }
    //}
    //public void onClickNextButton()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Level_Image = GetComponent<SpriteRenderer>();
    //        gameObject.GetComponent<Image>().sprite = LevelObj[count++];
    //    }
    //}
}
