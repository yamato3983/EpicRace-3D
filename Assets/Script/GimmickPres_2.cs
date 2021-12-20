using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickPres_2 : MonoBehaviour
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

        transform.Rotate(new Vector3(0, -1, 0));

        timeCount += Time.deltaTime;  //最後のフレームからの経過時間を加算

        if (timeCount >= 0 && timeCount <= 2.35f)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition -= _velocity_x * Time.deltaTime;
        }

        if (timeCount > 2.35f && timeCount <= 3.0f)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition += _velocity_y * Time.deltaTime;
        }

        if (timeCount > 3.0f && timeCount <= 5.35f)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition += _velocity_x * Time.deltaTime;
        }

        if (timeCount > 5.35f && timeCount <= 6.0f)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition -= _velocity_y * Time.deltaTime;
        }

        if (timeCount > 6.0f)
        {
            timeCount = 0;
        }
    }
}
