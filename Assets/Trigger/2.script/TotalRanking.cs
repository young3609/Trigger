using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Security.Cryptography;
using System;
using System.Text;

public class TotalRanking : MonoBehaviour
{
    private static TotalRanking instance6;
    public Gameoverinputname input;

    public static TotalRanking Instance
    {
        get { return instance6; }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // If no Player ever existed, we are it.
        if (instance6 == null)
            instance6 = this;
        // If one already exist, it's because it came from another level. 
        else if (instance6 != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    void Update()
    {
        try
        {
            //Global.i == 0 && 
            if (Global.checkpage == false && Global.checknull < 10)
            {
                input = GameObject.Find("GameManager").GetComponent<Gameoverinputname>();
                Debug.Log("checknull : " + Global.checknull);
                Global.checknull++;
            }
            //}
            // startGetScores();
            if (Global.i == 4 && input.Gameisover == true)
            {
                startPostScores();
            }
        }
        catch (Exception e) { }
        //HSController.Instance.startGetScores ();
    }

    private string secretKey = 0;// Edit this value and make sure it's the same as the one stored on the server
    string addScoreURL = ""; //be sure to add a ? to your url (ex)abc123.webhosting.com/addscore.php?
    string highscoreURL = ""; //

    //for testing
    public double uniqueIDdouble;
    public string uniqueID;
    public string name3;
    int score;


    public string[] onlineHighscore;


    public void startPostScores()
    {
        StartCoroutine(PostScores());
    }

    //set actual values before posting score
    public void updateOnlineHighscoreData()
    {
            Debug.Log(Global.totScore);
            uniqueIDdouble = UnityEngine.Random.Range(1, 10000000000000);
            uniqueID = uniqueIDdouble.ToString();
            Debug.Log(uniqueID);
            name3 = input.enterName.text;//"Testname51";
            Debug.Log(name);
            score = Global.totScore;//12000;
            Debug.Log(score);
            input.Gameisover = false;
    }

    public string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes\
        //System.Security.Cryptography.SHA256CryptoServiceProvider md5 = new System.Security.Cryptography.SHA256CryptoServiceProvider();
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }

    public string sha256_hash(string value)
    {
        StringBuilder Sb = new StringBuilder();

        using (SHA256 hash = SHA256.Create())
        {
            Encoding enc = Encoding.UTF8;
            Byte[] result = hash.ComputeHash(enc.GetBytes(value));

            foreach (Byte b in result)
                Sb.Append(b.ToString("x2"));
        }

        return Sb.ToString();
    }

    // remember to use StartCoroutine when calling this function!
    IEnumerator PostScores()
    {
        Debug.Log("IM RUN");
        updateOnlineHighscoreData();
        //This connects to a server side php script that will add the name and score to a MySQL DB.
        // Supply it with a string representing the players name and the players score.
        string hash = Md5Sum(name3 + score + secretKey);
        //string hash = sha256_hash(name3 + score + secretKey);
        //string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash;
        string post_url = addScoreURL + "uniqueID=" + uniqueID + "&name=" + WWW.EscapeURL(name3) + "&score=" + score + "&hash=" + hash;
        //Debug.Log ("post url " + post_url);
        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW("http://" + post_url);
        yield return hs_post; // Wait until the download is done

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
    }
}
