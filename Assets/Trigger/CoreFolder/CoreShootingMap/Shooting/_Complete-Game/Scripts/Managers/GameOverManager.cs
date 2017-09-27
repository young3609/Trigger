using UnityEngine;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
    public class GameOverManager : MonoBehaviour
    {

        public PlayerHealth playerHealth;       // Reference to the player's health.


        Animator anim;                          // Reference to the animator component.

        void Awake ()
        {
            // Set up the reference.
            anim = GetComponent <Animator> ();
        }


        void Update()
        {
            // If the player has run out of health...
            if (playerHealth.currentHealth <= 0 || Global.i == 4)
            {
                // ... tell the animator the game is over.
                Invoke("installanim", 3.0f);
                if (Global.gameend == 1) 
                {
                    SceneManager.LoadScene("main_view");
                }
            }
        }

        public void installanim() {
            anim.SetTrigger("GameOver");
        }
    }
}