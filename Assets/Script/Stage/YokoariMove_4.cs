using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokoariMove_4 : MonoBehaviour
{

    // �ړ����x
    [SerializeField] private Vector3 _velocity_x;
    [SerializeField] private Vector3 _velocity_y;
    [SerializeField] private Vector3 _velocity_z;

    float timeCount;

    private void Start()
    {
        timeCount = 0;
    }

    private void Update()
    {
        timeCount += Time.deltaTime; //�Ō�̃t���[������̌o�ߎ���

        if (timeCount >= 0 && timeCount <= 0.65f)
        {
            //�^��
            transform.localPosition -= _velocity_x * Time.deltaTime;
            transform.localPosition -= _velocity_z * Time.deltaTime;
        }
        if (timeCount >= 0.7 && timeCount <= 1.35f)
        {
            //�E
            transform.localPosition += _velocity_x * Time.deltaTime;
            transform.localPosition -= _velocity_z * Time.deltaTime;
        }
        if (timeCount >= 1.4f && timeCount <= 2f)
        {
            //�^��
            transform.localPosition -= _velocity_x * Time.deltaTime;
            transform.localPosition += _velocity_z * Time.deltaTime;
        }
        if (timeCount >= 2.05 && timeCount <= 2.65f)
        {
            //��
            transform.localPosition += _velocity_x * Time.deltaTime;
            transform.localPosition += _velocity_z * Time.deltaTime;
        }
        if (timeCount >= 2.7f)
        {
            timeCount = 0;
        }
    }
}
