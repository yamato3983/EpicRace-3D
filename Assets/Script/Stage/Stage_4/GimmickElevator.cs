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

    public bool LiftFlag = true; //true:�ʂ�� false:�ʂ�Ȃ�

    private void Start()
    {
        timeCount = 0;
    }

    void Update()
    {

        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        if (timeCount >= 0 && timeCount <= 1f)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition += _velocity_y * Time.deltaTime;

            //�ʂ�Ȃ�
            LiftFlag = false;

        }
        if(timeCount >=1f && timeCount <= 2f)
        {
            //�ʂ��
            LiftFlag = true;
        }
        if (timeCount >= 2f && timeCount <= 3f)
        {
            // ���x_velocity�ňړ�����i���[�J�����W�j
            transform.localPosition -= _velocity_y * Time.deltaTime;

            //�ʂ�Ȃ�
            LiftFlag = false;
        }
        if(timeCount>= 3f && timeCount<= 4f)
        {
            //�ʂ��
            LiftFlag = true;
        }
        if (timeCount >= 4f)
        {
            timeCount = 0;
        }
        
    }
}
