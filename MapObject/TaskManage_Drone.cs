/*
    드론 목표(이동) 을 관리하는 스크립트입니다.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TaskManage_Drone : MonoBehaviour
{
    public Vector2 Stop;
    void Start()
    {
        Stop = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D LandingZone)
    {
        //Debug.Log(LandingZone.name + "에게 닿았음!");
        transform.position = new Vector3(16, -9, 0);        
        GetComponent<Rigidbody2D>().velocity = Stop;
    }
}
