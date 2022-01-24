using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokoariMove_X : MonoBehaviour
{
    // �ړ����x
    [SerializeField] private Vector3 _velocity;

    //���ԃJ�E���g
    private float timeCount;

    private void Start()
    {
        timeCount = 0;
    }

    void Update()
    {

        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        if (timeCount >= 0f && timeCount <= 0.6f)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition -= _velocity * Time.deltaTime;
        }

        if (timeCount >= 0.9f && timeCount <= 1.5f)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition += _velocity * Time.deltaTime;
        }
        if (timeCount >= 1.5f && timeCount <= 2.1f)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition += _velocity * Time.deltaTime;
        }


        if (timeCount >= 2.4f && timeCount <= 3.0f)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition -= _velocity * Time.deltaTime;
        }

        if (timeCount >= 3f)
        {
            timeCount = 0;
        }
    }
}
