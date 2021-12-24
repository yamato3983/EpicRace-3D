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
    private float step;           //���x����������

    private Vector3 pos;          //���W
    private Quaternion rot;       //�p�x

    private float speed;
    private float timeCount; //���ԃJ�E���g

    GameObject Player6;
    PlayerController6 pscript;

    public GameObject targetObject; // �����������I�u�W�F�N�g
    public GameObject mtarget;
    [SerializeField] float mspeed;

    //������� Rotation
    private Quaternion _initialCamRotation;


    void Start()
    {
        Player6 = GameObject.Find("unitychan");
        pscript = Player6.GetComponent<PlayerController6>();
        offset = transform.position - target.position;
        //������]�̕ۑ�
        _initialCamRotation = this.gameObject.transform.rotation;
    }

    void Update()
    {
        if (pscript.Cflg == true)
        {
            //�����̈ʒu�A�^�[�Q�b�g�A���x
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