using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class Gameoverinputname : MonoBehaviour
{

    // Use this for initialization
    private string connectionString;

    private List<HighScore> highScores = new List<HighScore>();

    public GameObject scorePrefab;

    public int topRank;

    public int saveScores;

    public Text enterName;

    public GameObject nameDialog;

    public bool Gameisover = false;

    public bool ispop = false;

    // Use this for initialization
    void Start()
    {
        connectionString = "URI=file:" + Application.dataPath + "/HighScoreDB.sqlite";
        CreateTable();
        DeleteExtraScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.i == 4 && ispop == false) // 게임오버가 되면
        {
            nameDialog.SetActive(true);
            ispop = true;
        }
    }

    private void CreateTable()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {

            dbConnection.Open();
            Debug.Log("create t1 : Insert Connection!!");
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("CREATE TABLE if not exists HighScores (PlayerID INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE , Name TEXT NOT NULL , Score INTEGER NOT NULL , Date DATETIME NOT NULL  DEFAULT CURRENT_DATE)");

                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();

            }
        }
    }

    public void EnterName()
    {
        if (enterName.text != string.Empty)
        {
            Gameisover = true;
            int score = Global.totScore;
            InsertScore(enterName.text, score);
            enterName.text = string.Empty;
            nameDialog.SetActive(false);
            ispop = false;
            Global.gameend = 1;
        }
    }

    private void InsertScore(string name, int newScore)
    {
        GetScores();
        int hsCount = highScores.Count;
        if (highScores.Count > 0)
        {
            HighScore lowestScore = highScores[highScores.Count - 1];

            if (lowestScore != null && saveScores > 0 && highScores.Count >= saveScores && newScore > lowestScore.Score)
            {
                DeleteScore(lowestScore.ID);
                hsCount--;
            }

        }

        if (hsCount < saveScores)
        {
            using (IDbConnection dbConnection = new SqliteConnection(connectionString))
            {

                dbConnection.Open();
                Debug.Log("insert t1 : Insert Connection!!");
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    string sqlQuery = String.Format("INSERT INTO HighScores(Name,Score) VALUES(\"{0}\",\"{1}\")", name, newScore);

                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    dbConnection.Close();

                }
            }
        }
    }

    private void GetScores()
    {
        highScores.Clear();
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {

            dbConnection.Open();
            Debug.Log("get score t1 : Get Connection!!");
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM HighScores";

                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        highScores.Add(new HighScore(reader.GetInt32(0), reader.GetInt32(2), reader.GetString(1), reader.GetDateTime(3)));
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
        highScores.Sort();
    }
    private void DeleteScore(int id)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {

            dbConnection.Open();
            Debug.Log("Insert Connection!!");
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"", id);

                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();

            }
        }
    }

    private void DeleteExtraScore()
    {
        GetScores();

        if (saveScores <= highScores.Count)
        {
            int deleteCount = highScores.Count - saveScores;
            highScores.Reverse();

            using (IDbConnection dbConnection = new SqliteConnection(connectionString))
            {

                dbConnection.Open();
                Debug.Log("Insert Connection!!");
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {

                    for (int i = 0; i < deleteCount; i++)
                    {
                        string sqlQuery = String.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"", highScores[i].ID);

                        dbCmd.CommandText = sqlQuery;
                        dbCmd.ExecuteScalar();
                    }
                    dbConnection.Close();

                }
            }
        }
    }
}
