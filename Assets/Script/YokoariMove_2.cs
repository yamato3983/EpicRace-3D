using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokoariMove_2 : MonoBehaviour
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

        if (timeCount >= 0f && timeCount <= 0.4f)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition -= _velocity * Time.deltaTime;
        }

        if (timeCount >= 0.4f && timeCount <= 0.8f)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition += _velocity * Time.deltaTime;
        }
        if (timeCount >= 0.8f && timeCount <= 1.2f)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition += _velocity * Time.deltaTime;
        }


        if (timeCount >= 1.2f && timeCount <= 1.6f)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition -= _velocity * Time.deltaTime;
        }

        if (timeCount > 1.6f)
        {
            timeCount = 0;
        }
    }
}
