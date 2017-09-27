using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tizen;
using UnityEngine.UI;
using Lovatto.SceneLoader;

public class MenuManager : MonoBehaviour
{
    private bl_SceneLoaderManager Manager = null;
    /////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// test
    /// </summary>

    /////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Menu Scene Button Controll
    /// </summary>
    /// 
    public void onClickshootButton()
    {

        Debug.Log("onClickStartButton : Click Button");
        SceneManager.LoadScene("game_view");

    }

    public void onClickStartButton()
    {
        Global.checkpage = false;
        Debug.Log("onClickStartButton : Click Button");
        //SceneManager.LoadScene("shootingmap");

    }

    public void onHelpButton() {
        Debug.Log("onHelpButton : Click Button");
        //SceneManager.LoadScene(3);
    }

    public void onClickRankButton()
    {
        Debug.Log("onClickRankButton : Click Button");
        SceneManager.LoadScene("Ranking");
    }

    public void onClickTotalRankButton()
    {
        Debug.Log("onClickRankButton : Click Button");
         SceneManager.LoadScene("TotalRanking");
    }

    public void onClickExitButton()
    {
        Debug.Log("onClickExitButton : Click Button");
        Application.Quit();
    }

    public void onClickMainPageButton()
    {
        SceneManager.LoadScene(1);
        Debug.Log("onClickExitButton : Click Button");
    }
    /////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Help Scene Button Controll
    

    /////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Rank Scene Button Controll
    /// </summary>
    public void onClickLocalRank_Button()
    {
        SceneManager.LoadScene(1);
        Debug.Log("onClickLocalRank_Button : Click Button");
    }

    public void onClickTotalRank_Button() { 
        SceneManager.LoadScene(1);
        Debug.Log("onClickTotalRank_Button: Click Button");
    }
    /////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Game Scene Button Controll
    /// </summary>
    public void onClickGame_Button() {
        SceneManager.LoadScene("main_view");
        Debug.Log(" Click Button");
    }
    public void onClickBoss_Button() {
       // SceneManager.LoadScene(6);
    }
    /////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Boss Scene Button Controll
    /// </summary>
    public void onClickBossExit_Button()
    {
        SceneManager.LoadScene("game_view");
    }

    /////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// BuyItem Scene Button Controll
    /// </summary>
    public void onClickGoBossButton() {
        if (Global.nextstage > 15) {
            Global.nextstage = 1;
        }
 
        Global.next = Random.Range(0, 2);
        Debug.Log(Global.next);

        Debug.Log(Global.nextstage);
        //SceneManager.LoadScene(Global.nextstage);
    }
    /////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// GotoBoss Button Controll
    /// </summary>
    public void onClickFindGoToButton()
    {
        if (Global.nextstage > 15)
        {
            Global.nextstage = 1;
        }
        Global.next = 0;

        Debug.Log(Global.nextstage);
        //SceneManager.LoadScene(Global.nextstage);
    }

}
