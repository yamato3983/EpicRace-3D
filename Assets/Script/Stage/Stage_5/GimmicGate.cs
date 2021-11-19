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

    public bool GateFlag = false;

    private void Start()
    {
        timeCount = 0;
    }

    void Update()
    {

        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        if (timeCount >= (0 + plusCount) && (timeCount < 0.8f + plusCount))
        {

            //GateFlag = false;

            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition += _velocity_x * Time.deltaTime;

            GateFlag = true;

        }
        if(timeCount >= 0.8f && timeCount <= 1.2f)
        {
            GateFlag = true;
        }
        if (timeCount >= (1.2f)  && timeCount <= (2.0f + plusCount))
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition -= _velocity_x * Time.deltaTime;

            GateFlag = false;
        }
        if(timeCount >= 2.0f && timeCount <= 2.4f)
        {
            GateFlag = false;
        }
        if (timeCount >= (2.4f))
        {
            timeCount = 0;
        }

    }
}
