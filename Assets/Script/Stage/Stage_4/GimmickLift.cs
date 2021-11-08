using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickLift : MonoBehaviour
{
    // 移動速度
    [SerializeField] private Vector3 _velocity_x;
    [SerializeField] private Vector3 _velocity_y;
    [SerializeField] private Vector3 _velocity_z;

    //時間カウント
    private float timeCount;

    public  bool st4_flag;

    private void Start()
    {
        timeCount = 0;
        st4_flag = true;
        Debug.Log("ちんぽ");
    }

    void Update()
    {

        timeCount += Time.deltaTime;  //最後のフレームからの経過時間を加算

        // transformを取得
        Transform myTransform = this.transform;
        // ローカル座標での座標を取得
        Vector3 localPos = myTransform.localPosition;

        if (st4_flag == true)
        {

            if (timeCount >= 0 && timeCount <= 0.5)
            {
                // 速度_velocityで移動する（ローカル座標）
                localPos -= _velocity_y * Time.deltaTime;
            }
            if (timeCount >= 0.5 && timeCount <= 1)
            {
                // 速度_velocityで移動する（ローカル座標）
                localPos -= _velocity_x * Time.deltaTime;
            }

            if (timeCount >= 1 && timeCount <= 1.5)
            {
                // 速度_velocityで移動する（ローカル座標）
                localPos -= _velocity_x * Time.deltaTime;
            }

            if (timeCount >= 1.5 && timeCount <= 2)
            {
                // 速度_velocityで移動する（ローカル座標）
                localPos += _velocity_y * Time.deltaTime;
            }
            if (timeCount >= 2 && timeCount <= 2.5)
            {
                // 速度_velocityで移動する（ローカル座標）
                localPos += _velocity_x * Time.deltaTime;
            }
            if (timeCount >= 2.5 && timeCount <= 3)
            {
                // 速度_velocityで移動する（ローカル座標）
                localPos += _velocity_x * Time.deltaTime;

            }

            if (timeCount >= 3)
            {
                timeCount = 0;
            }

            myTransform.localPosition = localPos;
        }
    }
}
