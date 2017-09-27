using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtonCtrl : MonoBehaviour {
    //private float left;
    //private float right;
    bool leftpress = false;
    bool rightpress = false;
    private float circleRadius = 100.0f;
    private float angle = 0.0f;
    private float angleSpeed = 25.0f;
    private Transform tr;
    ////camera control
    //private Transform cameratr;
    //public Transform target;
    //private float cameracircleRadius = 140.0f;
    //private float cameraangle = 0.0f;
    //private float cameraangleSpeed = 50.0f;
    // Use this for initialization

    void Start()
    {
        tr = GameObject.Find("PlayerBasket").GetComponent<Transform>();
        //cameratr = GameObject.Find("Main Camera").GetComponent<Transform>();
        
    }
    void Update()
    {
        //left = Input.GetAxis("Button");
        //right = Input.GetAxis("Button");
        //Debug.Log("left =" + left.ToString());
        //Debug.Log("right =" + right.ToString());
        if (leftpress) {
            Debug.Log("change");
            this.angle -= this.angleSpeed * Time.deltaTime;
            float radAngle = angle * Mathf.Deg2Rad;
            Vector3 pos = tr.position;
            pos.x = (circleRadius * Mathf.Sin(radAngle));
            pos.z = -(circleRadius * Mathf.Cos(radAngle));
            tr.position = pos;
            //Debug.Log("install1");
        }
        if (rightpress) {
            Debug.Log("press");
            this.angle += this.angleSpeed * Time.deltaTime;
            float radAngle = angle * Mathf.Deg2Rad;
            Vector3 pos = tr.position;
            pos.x = circleRadius * Mathf.Sin(radAngle);
            pos.z = -(circleRadius * Mathf.Cos(radAngle));
            tr.position = pos;
            //Debug.Log("install2");
        }
    }


    public void Left_Button()
    {
        leftpress = true;
        rightpress = false;
    }

    public void Right_Button() {
        leftpress = false;
        rightpress = true;
    }

}
