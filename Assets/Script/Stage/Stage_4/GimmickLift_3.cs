using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickLift_3 : MonoBehaviour
{
    // �ړ����x
    [SerializeField] private Vector3 _velocity_x;
    [SerializeField] private Vector3 _velocity_y;
    [SerializeField] private Vector3 _velocity_z;

    //���ԃJ�E���g
    private float timeCount;

    private GameObject Lift;

    private void Start()
    {
        timeCount = 0;
        Lift = GameObject.Find("GimmickLift_1");

    }

    void Update()
    {

        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        if (Lift.GetComponent<GimmickLift>().st4_flag == true)
        {
            if (timeCount >= 0 && timeCount <= 0.5)
            {
                // ���x_velocity�ňړ�����i���[�J�����W�j
                transform.localPosition -= _velocity_y * Time.deltaTime;
            }
            if (timeCount >= 0.5 && timeCount <= 1)
            {
                // ���x_velocity�ňړ�����i���[�J�����W�j
                transform.localPosition -= _velocity_x * Time.deltaTime;
            }

            if (timeCount >= 1 && timeCount <= 1.5)
            {
                // ���x_velocity�ňړ�����i���[�J�����W�j
                transform.localPosition -= _velocity_x * Time.deltaTime;
            }

            if (timeCount >= 1.5 && timeCount <= 2)
            {
                // ���x_velocity�ňړ�����i���[�J�����W�j
                transform.localPosition += _velocity_y * Time.deltaTime;
            }
            if (timeCount >= 2 && timeCount <= 2.5)
            {
                // ���x_velocity�ňړ�����i���[�J�����W�j
                transform.localPosition += _velocity_x * Time.deltaTime;
            }
            if (timeCount >= 2.5 && timeCount <= 3)
            {
                // ���x_velocity�ňړ�����i���[�J�����W�j
                transform.localPosition += _velocity_x * Time.deltaTime;
            }

            if (timeCount >= 3)
            {
                timeCount = 0;
            }
        }
    }
}
