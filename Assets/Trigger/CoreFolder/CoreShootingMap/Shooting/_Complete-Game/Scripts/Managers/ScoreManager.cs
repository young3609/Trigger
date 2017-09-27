using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score;        // The player's score.


        Text text;                      // Reference to the Text component.
        public Text finalScore;

        void Awake ()
        {
            // Set up the reference.
            text = GetComponent <Text> ();

            // Reset the score.
            score = Global.totScore;
        }


        void Update ()
        {
            // Set the displayed text to be the word "Score" followed by the score value.
            text.text = "Score: " + score;
            if (Global.i == 4)
            {
                finalScore.text = "SCORE " + Global.totScore.ToString();
            }
        }
    }
}