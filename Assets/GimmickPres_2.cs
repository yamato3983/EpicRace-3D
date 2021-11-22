using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickPres_2 : MonoBehaviour
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

        transform.Rotate(new Vector3(0, -1, 0));

        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        if (timeCount >= 0 && timeCount <= 2.35f)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition -= _velocity_x * Time.deltaTime;
        }

        if (timeCount > 2.35f && timeCount <= 3.0f)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition += _velocity_y * Time.deltaTime;
        }

        if (timeCount > 3.0f && timeCount <= 5.35f)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition += _velocity_x * Time.deltaTime;
        }

        if (timeCount > 5.35f && timeCount <= 6.0f)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition -= _velocity_y * Time.deltaTime;
        }

        if (timeCount > 6.0f)
        {
            timeCount = 0;
        }
    }
}
