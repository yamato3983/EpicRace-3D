using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickElevator : MonoBehaviour
{
    // 移動速度
    [SerializeField] private Vector3 _velocity_x;
    [SerializeField] private Vector3 _velocity_y;
    [SerializeField] private Vector3 _velocity_z;

    //時間カウント
    private float timeCount;

    private void Start()
    {
        timeCount = 0;
    }

    void Update()
    {

        timeCount += Time.deltaTime;  //最後のフレームからの経過時間を加算

        if (timeCount >= 0 && timeCount <= 0.5)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition += _velocity_y * Time.deltaTime;
        }
        if (timeCount >= 1.5 && timeCount <= 2f)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition -= _velocity_y * Time.deltaTime;
        }
        if (timeCount >= 3f)
        {
            timeCount = 0;
        }
    }
}
