using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

public class BasketCtrl : MonoBehaviour {
    public float h;
    //public bool h;
    //public bool h1;
    private Transform tr;
    private GameUI gameUI;
    private raserUI raserUI;
    public AudioClip starin;
    private AudioSource source3 = null;
    private Rigidbody stardown;
    private int i = 1;
    public float stardownspeed = 3000.0f;
    private int starcount = 0;
    public GameObject buff;

    // Use this for initialization
    void Start () {
        // stardown = GameObject.Find("Star1").GetComponent<Rigidbody>();
        //FloatingTextController.Initialize();
        Global.raser = false;
        source3 = GetComponent<AudioSource>();
        tr = GetComponent<Transform>();
        gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();
        raserUI = GameObject.Find("Raserbeamgage").GetComponent<raserUI>();
    }
    private float circleRadius = 100.0f;
    private float angle = 0.0f;
    private float angleSpeed = 50.0f;
    //public Vector3 pivot;
    void Update()
    {
        // h = Input.GetAxis("Horizontal"); // 키보드의 A,D 또는 화살표키 LEFT,RIGHT를 눌렀을때 -1부터 +1까지 값을 반환
        //h = CrossPlatformInputManager.GetAxisRaw( "Horizontal" );
         h = UltimateJoystick.GetPosition( "Movement" ).x;
         // Debug.Log("H=" + h.ToString());
        //h = Input.GetKeyDown(KeyCode.D);
        //h1 = Input.GetKeyDown(KeyCode.A);
        //오른쪽
        if (h > 0)
        {
                this.angle += this.angleSpeed * Time.deltaTime;
                float radAngle = angle * Mathf.Deg2Rad;
                Vector3 pos = tr.position;
                pos.x = circleRadius * Mathf.Sin(radAngle);
                pos.z = -(circleRadius * Mathf.Cos(radAngle));
                //Debug.Log("x : " + pos.x);
                //Debug.Log("z : " + pos.z);
                tr.position = pos;
               // Debug.Log(h);
            // transform.Rotate(pos);
            // Debug.Log(Time.deltaTime);
        }

        //왼쪽
        else if (h < 0) {

            //Debug.Log("change");
            this.angle -= this.angleSpeed * Time.deltaTime;
            float radAngle = angle * Mathf.Deg2Rad;
            Vector3 pos = tr.position;
            pos.x =  (circleRadius * Mathf.Sin(radAngle));
            pos.z = -(circleRadius * Mathf.Cos(radAngle));
            //Debug.Log("x : " + pos.x);
            //Debug.Log("z : " + pos.z);
            //Debug.Log(h);
            tr.position = pos;
        }
        // 목표물 중심으로 회전
        //tr.Rotate(Vector3.down, angleSpeed * Time.deltaTime);
    }

    void addscore() {
        gameUI.DispScore(50);
        starcount++;
        if (starcount == 3)
        {
            starcount = 0;
            raserUI.DispRaser(true);
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "COLLAREA")
        {
            stardown = GameObject.Find("Star" + i).GetComponent<Rigidbody>();
            Debug.Log(i);
            Debug.Log("COLL");
            Destroy(coll.gameObject);
            stardown.useGravity = true;
            GameObject.Find("Star"+i).GetComponent<Rigidbody>().AddForce(-transform.up * stardownspeed);
            i++;
        }

        if (coll.gameObject.tag == "STAR")
        {
            buff.SetActive(true);
            Destroy(coll.gameObject);
            addscore();
            Debug.Log("COLL");
            source3.PlayOneShot(starin, 0.9f);
            Invoke("buffoff", 1f);
           // FloatingTextController.CreateFloatingText(Random.Range(0, 100).ToString(), transform);
        }
    }

    public void buffoff()
    {
        buff.SetActive(false);
    }
    //void OnCollisionEnter(Collision coll)
    //{

    //    //if (coll.gameObject.tag == "COLLAREA")
    //    //{
    //    //    Debug.Log("COLL");
    //    //    stardown.useGravity = true;
    //    //}

    //    if (coll.gameObject.tag == "STAR")
    //    {
    //        Destroy(coll.gameObject);
    //        addscore();
    //        Debug.Log("COLL");
    //        source3.PlayOneShot(starin, 0.9f);
    //    }
    //}
}
