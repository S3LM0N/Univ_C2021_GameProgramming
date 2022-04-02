/*
    드론 목표(이동) 을 관리하는 스크립트입니다.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TaskManage_EndPoint : MonoBehaviour
{
    int PosRange_X, PosRange_Y;
    private void OnTriggerEnter2D(Collider2D LandingZone)
    {
        //Debug.Log(LandingZone.name + "에게 닿았음!");
        PosRange_X = Random.Range(-2/2, 28/2);
        PosRange_Y = Random.Range(-10/2, 7/2);
        transform.position = new Vector2(PosRange_X, PosRange_Y);      
    }
}
