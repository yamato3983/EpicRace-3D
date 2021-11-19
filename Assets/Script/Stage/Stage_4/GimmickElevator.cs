using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickElevator : MonoBehaviour
{
    // 移動速度
    [SerializeField] private Vector3 _velocity_x;
    [SerializeField] private Vector3 _velocity_y;
    [SerializeField] private Vector3 _velocity_z;

    public float MovingDistance = 0;
    private float StartPos;

    //時間カウント
    private float timeCount;

    Vector3 objPosition; // オブジェクトの位置を記録

    public bool LiftFlag = true; //true:通れる false:通れない

    private void Start()
    {
        timeCount = 0;
    }

    void Update()
    {

        timeCount += Time.deltaTime;  //最後のフレームからの経過時間を加算

        if (timeCount >= 0 && timeCount <= 1f)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition += _velocity_y * Time.deltaTime;

            //通れない
            LiftFlag = false;

        }
        if(timeCount >=1f && timeCount <= 2f)
        {
            //通れる
            LiftFlag = true;
        }
        if (timeCount >= 2f && timeCount <= 3f)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition -= _velocity_y * Time.deltaTime;

            //通れない
            LiftFlag = false;
        }
        if(timeCount>= 3f && timeCount<= 4f)
        {
            //通れる
            LiftFlag = true;
        }
        if (timeCount >= 4f)
        {
            timeCount = 0;
        }
        
    }
}
