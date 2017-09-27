using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    public static int totScore= 0;
    public static float bosshp = 1000;
    public static int Power = 0;
    public static int i = 0;
    public static int MonsterNumber = 0;
    // public static int stage = 7;
    public static int nextstage = 15;
    public static int stagecount = 0;
    public static int buyweapon = -1;
    public static bool raser = false;
    public static bool bossclear = false;
    public static int hitcount = 0;
    public static int invokehitcount = 0;
    public static int gameend = 0;
    public static int next = 0;
    public static int checknull = 0;
    public static bool checkpage = false;
}

public class UIinitialize : MonoBehaviour {
	// Use this for initialization
	void Start () {
		// 나중에 위의 변수들을 초기화 해야함 왜냐하면 실행할때 마다 초기화해야되므로
        Global.totScore = 0;
        Global.bosshp = 1000;
        Global.i = 0;
        Global.MonsterNumber = 0;
        Global.Power = 0;
        // public static int stage = 7;
        Global.nextstage = 15;
        Global.stagecount = 0;
        Global.buyweapon = -1;
        Global.raser = false;
        Global.bossclear = false;
        Global.hitcount = 0;
        Global.invokehitcount = 0;
        Global.gameend = 0;
        Global.checknull = 0;
        Global.checkpage = true;
    }

}
