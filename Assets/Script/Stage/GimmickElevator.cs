using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickElevator : MonoBehaviour
{
    // �ړ����x
    [SerializeField] private Vector3 _velocity_x;
    [SerializeField] private Vector3 _velocity_y;
    [SerializeField] private Vector3 _velocity_z;

    public float MovingDistance = 0;
    private float StartPos;

    //���ԃJ�E���g
    private float timeCount;

    Vector3 objPosition; // �I�u�W�F�N�g�̈ʒu���L�^

    private void Start()
    {
        StartPos = transform.position.y;
    }

    void Update()
    {

        //�ړ�
        //transform.position = new Vector3(transform.position.x, StartPos + Mathf.PingPong(Time.time * 6f, MovingDistance), transform.position.z);

        
        if (timeCount >= 0 && timeCount <= 0.5)
        {
            //�ړ�
            transform.position = new Vector3(transform.position.x, StartPos + Mathf.PingPong(Time.time * 4f, MovingDistance), transform.position.z);

        }
        if (timeCount >= 1.5 && timeCount <= 2f)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            //transform.localPosition -= _velocity_y * Time.deltaTime;
        }
        if (timeCount >= 3f)
        {
            //timeCount = 0;
        }
        
    }
}
