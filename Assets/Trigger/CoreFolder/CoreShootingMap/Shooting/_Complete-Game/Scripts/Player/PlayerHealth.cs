using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
    public class PlayerHealth : MonoBehaviour
    {
        public int startingHealth = 100;                            // The amount of health the player starts the game with.
        public int currentHealth;                                   // The current health the player has.
        public Slider healthSlider;                                 // Reference to the UI's health bar.
        public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
        public AudioClip deathClip;                                 // The audio clip to play when the player dies.
        public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
        public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.


        Animator anim;                                              // Reference to the Animator component.
        AudioSource playerAudio;                                    // Reference to the AudioSource component.
        PlayerMovement playerMovement;                              // Reference to the player's movement.
        PlayerShooting playerShooting;                              // Reference to the PlayerShooting script.
        bool isDead;                                                // Whether the player is dead.
        bool damaged;

        //public Transform camTransform;
        //public float shakeAmount = 2f;
        //public float decreaseFactor = 1.0f;       // 캠흔들기
        //Vector3 originalPos;
        //public float shake = 0f;

        // True when the player gets damaged.
        public GameObject bluepotal;
        public GameObject bluenova;
        public GameObject player;
        CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
        private CapsuleCollider colli;
        public Sprite[] hpImage = new Sprite[5];

        private int nextscenevalue = 0;
        private bool die =false;

        public Gameoverinputname showpop;

        void Awake ()
        {
            //if (camTransform == null)
            //{
            //    camTransform = GetComponent(typeof(Transform)) as Transform; // 캠흔들기
            //}

            // Setting up the references.
            anim = GetComponent <Animator> ();
            playerAudio = GetComponent <AudioSource> ();
            playerMovement = GetComponent <PlayerMovement> ();
            playerShooting = GetComponentInChildren <PlayerShooting> ();
            //********************************************************************
            // Set the initial health of the player.
            currentHealth = startingHealth;
            GameObject.FindWithTag("HPTAG").GetComponent<Image>().sprite = hpImage[Global.i];
        }


        void Update ()
        {
            // If the player has just been damaged...
            if(damaged)
            {
                // ... set the colour of the damageImage to the flash colour.
                damageImage.color = flashColour;
            }
            // Otherwise...
            else
            {
                // ... transition the colour back to clear.
                damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }

            // Reset the damaged flag.
            damaged = false;

            //if (shake > 0)
            //{
            //    camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            //    shake -= Time.deltaTime * decreaseFactor;            // 캠 흔들기
            //}
            //else
            //{
            //    shake = 0f;
            //    camTransform.localPosition = originalPos;
            //}


            if (KillMonsterManager.monsternumber == 0) {
                bluepotal.SetActive(true);
            }

            if (Global.i == 4 && die == false) {
                currentHealth = 0;
                Death();
                die = true;
            }
            if (Global.raser == true) {
                Global.raser = false;   // 레이저를 사용하지 않고 잔류해 있으면 초기화
            }
        }

        //void OnEnable()
        //{
        //    originalPos = camTransform.localPosition;    // 캠 흔들기
        //}


        public void TakeDamage (int amount)
        {
            // Set the damaged flag so the screen will flash.
            damaged = true;

            //// Reduce the current health by the damage amount.
            currentHealth -= amount;

            //// Set the health bar's value to the current health.
            healthSlider.value = currentHealth;
          
            // Play the hurt sound effect.
            playerAudio.Play ();
            anim.SetTrigger("hit");
            //attack();
            // If the player has lost all it's health and the death flag hasn't been set yet...
            if(currentHealth <= 0 && !isDead)         
            {
                // Tell the animator that the player is dead.
                anim.SetTrigger("Die");
                // ... it should die.
                Invoke("Death", 3f);
            }
        }


        void Death ()
        {
            Global.i = 4;
            // Set the death flag so this function won't be called again.
            isDead = true;

            // Turn off any remaining shooting effects.
            playerShooting.DisableEffects ();

            // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
            playerAudio.clip = deathClip;
            playerAudio.Play ();

            // Turn off the movement and shooting scripts.
            playerMovement.enabled = false;
            playerShooting.enabled = false;
        }

         void OnTriggerEnter(Collider coll)
        {
            if (KillMonsterManager.monsternumber == 0 && coll.CompareTag("BluePortal"))
            {
                bluenova.SetActive(true);
                Invoke("nextscene", 2f);
                // Turn the collider into a trigger so shots can pass through it.
                colli = GameObject.Find("Player").GetComponent<CapsuleCollider>();
                colli.isTrigger = true;
                player.SetActive(false);
                nextscenevalue = Random.Range(1, 3);

            }
        }

        //void attack()
        //{
        //    shake = 1f;
        //}

        public void nextscene() {
            if (nextscenevalue == 1)
            {
                SceneManager.LoadScene("game_view");
            }
            else {
                SceneManager.LoadScene("BuyItem");
            }
        }

        public void RestartLevel ()
        {
            // Reload the level that is currently loaded.
            SceneManager.LoadScene (0);
        }
    }
}