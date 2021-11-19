using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmicGate : MonoBehaviour
{
    // 移動速度
    [SerializeField] private Vector3 _velocity_x;
    [SerializeField] private Vector3 _velocity_y;
    [SerializeField] private Vector3 _velocity_z;

    //追加カウント
    [SerializeField] private float plusCount;

    //時間カウント
    private float timeCount;

    public bool GateFlag = false;

    private void Start()
    {
        timeCount = 0;
    }

    void Update()
    {

        timeCount += Time.deltaTime;  //最後のフレームからの経過時間を加算

        if (timeCount >= (0 + plusCount) && (timeCount < 0.8f + plusCount))
        {

            //GateFlag = false;

            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition += _velocity_x * Time.deltaTime;

            GateFlag = true;

        }
        if(timeCount >= 0.8f && timeCount <= 1.2f)
        {
            GateFlag = true;
        }
        if (timeCount >= (1.2f)  && timeCount <= (2.0f + plusCount))
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition -= _velocity_x * Time.deltaTime;

            GateFlag = false;
        }
        if(timeCount >= 2.0f && timeCount <= 2.4f)
        {
            GateFlag = false;
        }
        if (timeCount >= (2.4f))
        {
            timeCount = 0;
        }

    }
}
