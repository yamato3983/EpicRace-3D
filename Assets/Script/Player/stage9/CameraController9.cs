using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController9 : MonoBehaviour
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

    GameObject Player;
    PlayerController9 pscript;

    public GameObject targetObject; // 注視したいオブジェクト
    public GameObject mtarget;
    [SerializeField] float mspeed;

    //初期状態 Rotation
    private Quaternion _initialCamRotation;

    private Quaternion rot2;

    public Camera cam;

    void Start()
    {
        offset = transform.position - target.position;
        Player = GameObject.Find("Boat_Player");
        pscript = Player.GetComponent<PlayerController9>();
    }

    void Update()
    {
        if (pscript.Cflg == true)
        {
            size_up();
        }
        else if(pscript.Cflg == false)
        {
            size_down();
        }
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(
                transform.position,
                targetCamPos,
                Time.deltaTime * smoothing
            );
    }
    public void size_up()
    {
        if (cam.orthographicSize <= 15.0f)
        {
            cam.orthographicSize += 2f * Time.deltaTime;
        }
        if (cam.orthographicSize >= 15.0f)
        {
            cam.orthographicSize = 15.0f;
            //pscript.Cflg = false;
        }

    }
    public void size_down()
    {
        if (cam.orthographicSize >= 9.0f)
        {
            cam.orthographicSize -= 2f * Time.deltaTime;
        }
        if (cam.orthographicSize <= 9.0f)
        {
            cam.orthographicSize = 9.0f;
            //pscript.Cflg = false;
        }

    }
}
