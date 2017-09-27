using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {

    public Transform[] points;
    public GameObject[] objectPrefab;

    private float createTime = 6.0f;
    private float collcreateTime = 2.0f;
    public int maxMoster = 10;
    public bool isGameover = false;
    private int pos = 1;
    private int poscount = 1;
    private bool starting = false;
    private int timer = 0;

    Point1 p1; Point2 p2; Point3 p3; Point4 p4; Point5 p5; Point6 p6; Point7 p7; Point8 p8;

    // Use this for initialization
    void Awake () {
        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
        p1 = GameObject.Find("Point1").GetComponent<Point1>();
        p2 = GameObject.Find("Point2").GetComponent<Point2>();
        p3 = GameObject.Find("Point3").GetComponent<Point3>();
        p4 = GameObject.Find("Point4").GetComponent<Point4>();
        p5 = GameObject.Find("Point5").GetComponent<Point5>();
        p6 = GameObject.Find("Point6").GetComponent<Point6>();
        p7 = GameObject.Find("Point7").GetComponent<Point7>();
        p8 = GameObject.Find("Point8").GetComponent<Point8>();
        InitCreateitems();
    }

    //void Update()
    //{
    //    Debug.Log("isGameover : " + isGameover);
    //    Debug.Log("point1 detect : " + p1.detect);

    //}

    void InitCreateitems()
    {
        Debug.Log("startcoutine");
        for (int pos = 1; pos <= 8; pos++) {
            int idx = Random.Range(0, objectPrefab.Length);
            Instantiate(objectPrefab[idx], points[pos].position, points[pos].rotation);
        }
        if (points.Length > 0)
        {
           StartCoroutine(this.CreateItems());
        }
    }

    //void Createitem() {
    //    Coroutine(this.delaytime());
    //}

    //IEnumerable delaytime() {
    //    pos = spc.position;
    //    Debug.Log("pos1 : " + pos);
    //    int idx = Random.Range(0, objectPrefab.Length);
    //    Instantiate(objectPrefab[idx], points[pos].position, points[pos].rotation);
    //    yield return new WaitForSeconds(5.0f);
    //    spc.detect = false;
    //}

    IEnumerator CreateItems() {
        while (!isGameover) {
            if (p1.detect)
            {
                yield return new WaitForSeconds(2.0f);
                pos = p1.position;
                Debug.Log("gamemgr detect : " + p1.detect);
                Debug.Log("pos1 : " + pos);
                int idx = Random.Range(0, objectPrefab.Length);
                Instantiate(objectPrefab[idx], points[pos].position, points[pos].rotation);
                p1.detect = false;
            }
            else if (p2.detect)
            {
                yield return new WaitForSeconds(2.0f);
                pos = p2.position;
                Debug.Log("gamemgr detect2 : " + p2.detect);
                Debug.Log("pos2 : " + pos);
                int idx = Random.Range(0, objectPrefab.Length);
                Instantiate(objectPrefab[idx], points[pos].position, points[pos].rotation);
                p2.detect = false;
            }
            else if (p3.detect)
            {
                yield return new WaitForSeconds(2.0f);
                pos = p3.position;
                Debug.Log("gamemgr detect3 : " + p3.detect);
                Debug.Log("pos3 : " + pos);
                int idx = Random.Range(0, objectPrefab.Length);
                Instantiate(objectPrefab[idx], points[pos].position, points[pos].rotation);
                p3.detect = false;
            }
            else if (p4.detect)
            {
                yield return new WaitForSeconds(2.0f);
                pos = p4.position;
                Debug.Log("gamemgr detect4 : " + p4.detect);
                Debug.Log("pos4 : " + pos);
                int idx = Random.Range(0, objectPrefab.Length);
                Instantiate(objectPrefab[idx], points[pos].position, points[pos].rotation);
                p4.detect = false;
            }
            else if (p5.detect)
            {
                yield return new WaitForSeconds(2.0f);
                pos = p5.position;
                Debug.Log("gamemgr detect5 : " + p5.detect);
                Debug.Log("pos5 : " + pos);
                int idx = Random.Range(0, objectPrefab.Length);
                Instantiate(objectPrefab[idx], points[pos].position, points[pos].rotation);
                p5.detect = false;
            }
            else if (p6.detect)
            {
                yield return new WaitForSeconds(2.0f);
                pos = p6.position;
                Debug.Log("gamemgr detect6 : " + p6.detect);
                Debug.Log("pos6 : " + pos);
                int idx = Random.Range(0, objectPrefab.Length);
                Instantiate(objectPrefab[idx], points[pos].position, points[pos].rotation);
                p6.detect = false;
            }
            else if (p7.detect)
            {
                yield return new WaitForSeconds(2.0f);
                pos = p7.position;
                Debug.Log("gamemgr detect7 : " + p7.detect);
                Debug.Log("pos7 : " + pos);
                int idx = Random.Range(0, objectPrefab.Length);
                Instantiate(objectPrefab[idx], points[pos].position, points[pos].rotation);
                p7.detect = false;
            }
            else if (p8.detect)
            {
                yield return new WaitForSeconds(2.0f);
                pos = p8.position;
                Debug.Log("gamemgr detect8 : " + p8.detect);
                Debug.Log("pos8 : " + pos);
                int idx = Random.Range(0, objectPrefab.Length);
                Instantiate(objectPrefab[idx], points[pos].position, points[pos].rotation);
                p8.detect = false;
            }
            else
            {
                yield return null;
            }
        }
    }


 }

