using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GridPlayer : Pathfinding
{
    public Camera playerCam;
    public Camera minimapCam;
    public GUIStyle bgStyle;
    private AudioSource source3 = null;
    public AudioClip bump;
    public AudioClip getscore;
    public AudioClip gethp;
    private GameUI gameUI;
    public Sprite[] hpImage = new Sprite[5];

    public Image damageImage;
    public float flashSpeed = 1f;                              
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    bool damaged;

    public Transform camTransform;
    public float shakeAmount = 2f;
    public float decreaseFactor = 1.0f;
    Vector3 originalPos;
    public float shake = 0f;
    public GameObject green;
    public GameObject white1;
    public GameObject white2;
    public GameObject white3;

    public GameObject greeneffect;
    public GameObject yelloweffect1;
    public GameObject yelloweffect2;
    public GameObject yelloweffect3;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Start()
    {
        GameObject.FindWithTag("HPTAG").GetComponent<Image>().sprite = hpImage[Global.i];
        source3 = GetComponent<AudioSource>();
        gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();
    }
    void Update () 
    {
        FindPath();
        if (Path.Count > 0)
        {
            MoveMethod();
        }

        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        if (shake > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0f;
            camTransform.localPosition = originalPos;
        }
        //shake = 0f;
    }

    void addscore()
    {
        gameUI.DispScore(5000);
    }

    void minusscore()
    {
        gameUI.DispScore(-50);
    }

    //void OnCollisionEnter(Collision coll)
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            damaged = true;
            shake = 1f;
            minusscore();
            source3.PlayOneShot(bump, 0.9f);
        }
        if (coll.gameObject.tag == "TREASURE")
        {
            white1.SetActive(false);
            yelloweffect1.SetActive(true);
            Destroy(coll.gameObject);
            addscore();
            source3.PlayOneShot(getscore, 0.9f);
        }
        if (coll.gameObject.tag == "Treasure2")
        {
            white2.SetActive(false);
            yelloweffect2.SetActive(true);
            Destroy(coll.gameObject);
            addscore();
            source3.PlayOneShot(getscore, 0.9f);
        }
        if (coll.gameObject.tag == "Treasure3")
        {
            white3.SetActive(false);
            yelloweffect3.SetActive(true);
            Destroy(coll.gameObject);
            addscore();
            source3.PlayOneShot(getscore, 0.9f);
        }
        if (coll.gameObject.tag == "MEDIKIT")
        {
            greeneffect.SetActive(true);
            green.SetActive(false);
            Destroy(coll.gameObject);
            if (Global.i - 1 < 0) { Global.i = 0; GameObject.FindWithTag("HPTAG").GetComponent<Image>().sprite = hpImage[Global.i]; }
            else {
                GameObject.FindWithTag("HPTAG").GetComponent<Image>().sprite = hpImage[Global.i - 1];
            }
            Global.i--;
            source3.PlayOneShot(gethp, 0.9f);
        }
    }


    private void FindPath()
    {

        if (Input.GetButtonDown("Fire1") && Input.mousePosition.x > (Screen.width / 10) * 3.5F && Input.mousePosition.y < (Screen.height / 10) * 3.5F)
        {
            //Call to the player map
            Ray ray = minimapCam.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {             
               FindPath(transform.position, hit.point);
            }          
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            //Call minimap
            Ray ray = playerCam.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                FindPath(transform.position, hit.point);
            }      
        }
    }

    private void MoveMethod()
    {
        if (Path.Count > 0)
        {
            Vector3 direction = (Path[0] - transform.position).normalized;

            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * 20F);
            if (transform.position.x < Path[0].x + 0.4F && transform.position.x > Path[0].x - 0.4F && transform.position.z > Path[0].z - 0.4F && transform.position.z < Path[0].z + 0.4F)
            {
                Path.RemoveAt(0);
            }

            RaycastHit[] hit = Physics.RaycastAll(transform.position + (Vector3.up * 20F), Vector3.down, 100);
            float maxY = -Mathf.Infinity;
            foreach (RaycastHit h in hit)
            {
                if (h.transform.tag == "Untagged")
                {
                    if (maxY < h.point.y)
                    {
                        maxY = h.point.y;
                    }
                }
            }
            transform.position = new Vector3(transform.position.x, maxY + 1F, transform.position.z);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "", bgStyle);
    }
}
