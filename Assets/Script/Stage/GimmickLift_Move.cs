using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickLift_Move : MonoBehaviour
{
    // �ړ����x
    [SerializeField] private Vector3 _velocity_x;
    [SerializeField] private Vector3 _velocity_y;
    [SerializeField] private Vector3 _velocity_z;

    //���ԃJ�E���g
    private float timeCount;

    private void Start()
    {
        timeCount = 0;
    }

    void Update()
    {

        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        if (timeCount >= 0 && timeCount <= 0.2)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition -= _velocity_x * Time.deltaTime;
        }
        if (timeCount >= 0.2 && timeCount <=0.4)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition -= _velocity_x * Time.deltaTime;
        }

        if (timeCount >= 0.6 && timeCount <= 0.8)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition -= _velocity_y * Time.deltaTime;
        }

        if (timeCount >= 1.0 && timeCount <= 1.2)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition += _velocity_x * Time.deltaTime;
        }
        if (timeCount >= 1.2 && timeCount <= 1.4)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition += _velocity_x * Time.deltaTime;
        }
        if (timeCount >= 1.6 && timeCount <= 1.8)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition += _velocity_y * Time.deltaTime;
        }

        if (timeCount >= 2f)
        {
            timeCount = 0;
        }
    }
}
