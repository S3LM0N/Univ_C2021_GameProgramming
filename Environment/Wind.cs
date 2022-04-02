/*
    드론 오브젝트에 랜덤으로 외력을 가하는 스크립트입니다.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public Vector2 Wind_Vector;
    public float Wind_Direction;
    public float Wind_Vector_K;
    int Wind_Increase;
    float Wind_AddPower;

    public static float Remap(float val, float in1, float in2, float out1, float out2)
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }
    // Start is called before the first frame update
    void Start()
    {
        Wind_Vector = Vector2.zero;
        Wind_Direction = Random.Range(-180, 180);
        Wind_Direction = Remap(Wind_Direction, -180, 180, -10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
        Wind_Increase = Random.Range(-10, 10);
        if(Wind_Increase == 1){Wind_Direction++;};
        if(Wind_Increase == 0){Wind_Direction--;};

            /*//삼각함수를 이용해 각도에 따라 움직임 제어 -  진동발생 :\
                Wind_Vector.y = Mathf.Sin(Wind_Direction) * Wind_Vector_K ;
                Wind_Vector.x = Mathf.Cos(Wind_Direction) * Wind_Vector_K ;
            */
            if(Wind_Direction > 0){Wind_Vector.y = -5 + Wind_Direction;Wind_Vector.x = Wind_Direction;}
            if(Wind_Direction < 0){Wind_Vector.y = -5 - Wind_Direction;Wind_Vector.x = Wind_Direction;}
        GetComponent<Rigidbody2D>().velocity += Wind_Vector * Wind_Vector_K * Wind_Vector_K;
    }
}
