/*
    드론 오브젝트를 화살표로 조종하는 스크립트입니다.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Control : MonoBehaviour
{
    public Vector2 Throttle;
    public float Throttle_K;
    public float Roll_K;
    public float Angle;
    void Start()
    {
        Throttle = Vector2.zero;
    }
    public static float Remap(float val, float in1, float in2, float out1, float out2)
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }
    void Update()
    {

        
        //Control
        Angle = transform.rotation.eulerAngles.z - 180;
        Angle = Remap(Angle, -180, 180, -10, 10);
        if(Input.GetKey(KeyCode.RightArrow))
        {
            //Throttle.x += 0.01f;
            transform.Rotate(Vector3.forward, -Roll_K * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            //Throttle.x -= 0.01f;
            transform.Rotate(Vector3.forward, Roll_K * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            /*//삼각함수를 이용해 각도에 따라 움직임 제어 - 위/아래와 좌/우 화살표 중복입력 시 진동발생
                Throttle.y += Mathf.Cos(Angle);
                Throttle.x += Mathf.Sin(Angle);
            */
            if(Angle > 0){Throttle.y += 5 - Angle;Throttle.x = -Angle;}
            if(Angle < 0){Throttle.y += 5 + Angle;Throttle.x = -Angle;}
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            /*//삼각함수를 이용해 각도에 따라 움직임 제어 - 위/아래와 좌/우 화살표 중복입력 시 진동발생
                Throttle.y -= Mathf.Cos(Angle);
                Throttle.x -= Mathf.Sin(Angle);
            */
            if(Angle > 0){Throttle.y += -5 + Angle;Throttle.x = Angle;}
            if(Angle < 0){Throttle.y += -5 - Angle;Throttle.x = Angle;}
        }

        //Throttle.y = Input.GetAxis("Vertical") * Throttle_K;
        //Throttle.x = Input.GetAxis("Horizontal") * Throttle_K;

        Throttle.y *= Throttle_K;
        Throttle.x *= Throttle_K;

        GetComponent<Rigidbody2D>().velocity += Throttle;
        
    }
}