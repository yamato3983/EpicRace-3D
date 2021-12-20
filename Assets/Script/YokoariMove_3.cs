using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokoariMove_3 : MonoBehaviour
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

        if(timeCount >= 0 && timeCount <=0.65f)
        {
            //�^��
            transform.localPosition += _velocity_x * Time.deltaTime;
            transform.localPosition += _velocity_z * Time.deltaTime;
        }
        if(timeCount >= 0.65 && timeCount <= 1.3f)
        {
            //�E
            transform.localPosition -= _velocity_x * Time.deltaTime;
            transform.localPosition += _velocity_z * Time.deltaTime;
        }
        if (timeCount >= 1.3f && timeCount <= 1.95f)
        {
            //�^��
            transform.localPosition += _velocity_x * Time.deltaTime;
            transform.localPosition -= _velocity_z * Time.deltaTime;
        }
        if (timeCount >= 1.95 && timeCount <= 2.6f)
        {
            //��
            transform.localPosition -= _velocity_x * Time.deltaTime;
            transform.localPosition -= _velocity_z * Time.deltaTime;
        }
        if (timeCount >= 2.6f)
        {
            timeCount = 0;
        }
    }
}
