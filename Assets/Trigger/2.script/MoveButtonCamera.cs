using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtonCamera : MonoBehaviour {

    public Transform target;
    public float dist = 10.0f;
    public float height = 5.0f;
    public float smoothRotate = 5.0f;
    bool leftpress = false;
    bool rightpress = false;

    private Transform tr;

    void Start()
    {
        tr = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    private float circleRadius = 140.0f; // 카메라 회전 반지름. 높이 조절은 y변수 조절하면됨
    private float angle = 0.0f;
    private float angleSpeed = 25.0f;

    void LateUpdate()
    {
        if (leftpress)
        {
            this.angle -= this.angleSpeed * Time.deltaTime;
            float radAngle = angle * Mathf.Deg2Rad;
            Vector3 pos = tr.position;
            pos.x = (circleRadius * Mathf.Sin(radAngle));
            pos.z = (-(circleRadius * Mathf.Cos(radAngle)));
            //Debug.Log("pos.x  : " + pos.x + " " + "pos.y  : " + pos.y + " " + "pos.z  : " + pos.z);

            tr.position = pos;
            tr.LookAt(target);
        }
        else if (rightpress)
        {
            this.angle += this.angleSpeed * Time.deltaTime;
            float radAngle = angle * Mathf.Deg2Rad;
            Vector3 pos = tr.position;
            pos.x = (circleRadius * Mathf.Sin(radAngle));
            pos.z = (-(circleRadius * Mathf.Cos(radAngle)));
            //  Debug.Log("pos.x  : " + pos.x + " " + "pos.y  : " + pos.y + " " + "pos.z  : " + pos.z);

            tr.position = pos;
            tr.LookAt(target);
        }

    }

    public void Left_Button()
    {
        leftpress = true;
        rightpress = false;
    }

    public void Right_Button()
    {
        leftpress = false;
        rightpress = true;
    }

}
