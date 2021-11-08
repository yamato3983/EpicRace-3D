using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmicGate : MonoBehaviour
{
    // �ړ����x
    [SerializeField] private Vector3 _velocity_x;
    [SerializeField] private Vector3 _velocity_y;
    [SerializeField] private Vector3 _velocity_z;

    //�ǉ��J�E���g
    [SerializeField] private float plusCount;

    //���ԃJ�E���g
    private float timeCount;

    private void Start()
    {
        timeCount = 0;
    }

    void Update()
    {

        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        if (timeCount >= (0 + plusCount) && (timeCount < 0.6f + plusCount))
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition += _velocity_x * Time.deltaTime;

        }
        if (timeCount >= (1.0f)  && timeCount <= (1.6f + plusCount))
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition -= _velocity_x * Time.deltaTime;
        }
        if (timeCount >= (1.9f))
        {
            timeCount = 0;
        }

    }
}
