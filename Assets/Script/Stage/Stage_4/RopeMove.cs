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
    private float startTime = 5f;

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

        transform.eulerAngles = new Vector3(0f, 0f, angle);

        

    }
}
