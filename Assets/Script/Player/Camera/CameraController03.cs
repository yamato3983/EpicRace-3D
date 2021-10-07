using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController03 : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    private Vector3 offset;
    [SerializeField]
    private float angle;

    [SerializeField]
    private float step;           //何度ずつ動かすか

    private Vector3 pos;          //座標
    private Quaternion rot;       //角度

    private float speed;
    private float timeCount; //時間カウント

    PlayerController3 pc;
    GameObject player;


    //[serializefield] private transform _targettransfrom;
    //[serializefield] private float _speed = 0.5f;
    //[serializefield] private float _radius = 5.0f;
    //[serializefield] private float _upper = 1.0f;
    //回転させるスピード
    public float rotateSpeed = 3.0f;

    void Start()
    {
        offset = transform.position - target.position;
        player = GameObject.Find("unitychan");
        pc = player.GetComponent<PlayerController3>();

    }
    //void Rotation()
    //{
    //    float posX = _radius * Mathf.Sin(Time.time * _speed);
    //    float posZ = _radius * Mathf.Cos(Time.time * _speed);

    //    transform.position = new Vector3(posX, _upper, posZ);
    //    transform.LookAt(_targetTransfrom);
    //}

    void Update()
    {
        //プレイヤー位置情報
        Vector3 playerPos = player.transform.position;

        if (pc.Cflg == false)
        {
            Vector3 targetCamPos = target.position + offset;
            transform.position = Vector3.Lerp(
                transform.position,
                targetCamPos,
                Time.deltaTime * smoothing
            );
        }
        else if (pc.Cflg == true)
        {
            //カメラを回転させる
            //transform.RotateAround(playerPos, Vector3.up, angle);
        }
    }
}
