using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{
    public class KillMonsterManager : MonoBehaviour
    {

        public static int monsternumber; // Monter number


        Text text;              // Reference to the Text component.

        
        void Awake()
        {
            // Set up the reference.
            text = GetComponent<Text>();

            // Reset the monsternumber
            monsternumber = 10 + 10*Global.MonsterNumber;
            Global.MonsterNumber++;
        }


        void Update()
        {
            // Set the displayed text to be the word "Score" followed by the score value.
            text.text = "Kill Monster: " + monsternumber;
        }
    }
}
