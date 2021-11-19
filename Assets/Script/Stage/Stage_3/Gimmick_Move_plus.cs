using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_Move_plus: MonoBehaviour
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

        if (timeCount >= 0 && timeCount <= 1.0)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition += _velocity * Time.deltaTime;
        }
        if (timeCount >= 0.5 && timeCount <= 0.8)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            //transform.localPosition += _velocity * Time.deltaTime;
        }
        if (timeCount >= 0.8 && timeCount <= 1.8)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition -= _velocity * Time.deltaTime;
        }

        if(timeCount >= 1.8 && timeCount <= 2.1)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            //transform.localPosition -= _velocity * Time.deltaTime;
        }

        if (timeCount >= 1.8 && timeCount <= 2.1)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            //transform.localPosition += _velocity * Time.deltaTime;
        }

        if(timeCount >= 2.1)
        {
            timeCount = 0;
        }
    }
}


