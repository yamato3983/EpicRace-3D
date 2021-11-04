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

    private void Start()
    {
        StartPos = transform.position.y;
    }

    void Update()
    {

        //移動
        //transform.position = new Vector3(transform.position.x, StartPos + Mathf.PingPong(Time.time * 6f, MovingDistance), transform.position.z);

        
        if (timeCount >= 0 && timeCount <= 0.5)
        {
            //移動
            transform.position = new Vector3(transform.position.x, StartPos + Mathf.PingPong(Time.time * 4f, MovingDistance), transform.position.z);

        }
        if (timeCount >= 1.5 && timeCount <= 2f)
        {
            // 速度_velocityで移動する（ローカル座標）
            //transform.localPosition -= _velocity_y * Time.deltaTime;
        }
        if (timeCount >= 3f)
        {
            //timeCount = 0;
        }
        
    }
}
