using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMove : MonoBehaviour
{

    //進む方向
    private int direction = 1;

    //Z軸の角度
    private float angle = 0f;

    //動き始める時間
    private float startTime;

    //揺れ動く間隔？時間？
    [SerializeField]
    private float duration = 5f;

    //振り子をする角度
    [SerializeField]
    private float limitAngle = 90f;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        //経過時間に合わせた割合を計算
        float t = (Time.time - startTime) / duration;

        //スムーズな角度を計算
        angle = Mathf.SmoothStep(angle, direction * limitAngle, t);

        //角度変更
        transform.eulerAngles = new Vector3(angle, 0f, 0f);

        //角度が指定した角度と1度の差になったら反転
        if (Mathf.Abs(Mathf.DeltaAngle(angle, direction * limitAngle)) < 1f)
        {
            direction *= -1;
            startTime = Time.time;
        }

    }

    //進んでいる向き
    public int GetDirection()
    {
        return direction;
    }
}
