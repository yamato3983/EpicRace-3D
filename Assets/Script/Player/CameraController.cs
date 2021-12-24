using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
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

    GameObject Player6;
    PlayerController6 pscript;

    public GameObject targetObject; // 注視したいオブジェクト
    public GameObject mtarget;
    [SerializeField] float mspeed;

    //初期状態 Rotation
    private Quaternion _initialCamRotation;


    void Start()
    {
        Player6 = GameObject.Find("unitychan");
        pscript = Player6.GetComponent<PlayerController6>();
        offset = transform.position - target.position;
        //初期回転の保存
        _initialCamRotation = this.gameObject.transform.rotation;
    }

    void Update()
    {
        if (pscript.Cflg == true)
        {
            //自分の位置、ターゲット、速度
            transform.position = Vector3.MoveTowards(transform.position, mtarget.transform.position, mspeed);
        }
        else
        {
            Vector3 targetCamPos = target.position + offset;
            transform.position = Vector3.Lerp(
                    transform.position,
                    targetCamPos,
                    Time.deltaTime * smoothing
                );
        }
        
        
    }
}