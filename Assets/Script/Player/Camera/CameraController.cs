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
    

    void Start()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(
            transform.position,
            targetCamPos,
            Time.deltaTime * smoothing
        );
    }
}