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

    private void Start()
    {
        timeCount = 0;
    }

    void Update()
    {

        timeCount += Time.deltaTime;  //最後のフレームからの経過時間を加算

        if (timeCount >= (0 + plusCount) && (timeCount < 0.6f + plusCount))
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition += _velocity_x * Time.deltaTime;

        }
        if (timeCount >= (1.0f)  && timeCount <= (1.6f + plusCount))
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition -= _velocity_x * Time.deltaTime;
        }
        if (timeCount >= (1.9f))
        {
            timeCount = 0;
        }

    }
}
