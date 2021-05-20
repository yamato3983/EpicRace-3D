using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PivotAngle_Box : MonoBehaviour
{

    [SerializeField]
    private float angle;

    [SerializeField]
    private float step;           //���x����������

    private Vector3 pos;          //���W
    private Quaternion rot;       //�p�x

    private float speed;
    private float timeCount; //���ԃJ�E���g

    public bool gimmickFlag_Bridge;   //true:�����˂����Ă� false:��������Ă�


    private void Start()
    {
        //������
        step = 0;
        speed = 120f;

        //�ŏ��͒ʂ��
        gimmickFlag_Bridge = true;
    }

    void Update()
    {
        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        step = speed * Time.deltaTime;
        rot = this.transform.rotation;

        if (timeCount >= 2f && timeCount <= 4)
        {

            //��������
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(90, 0, 0), step);
            Debug.Log("1���");

            //��������Ă���
            gimmickFlag_Bridge = false;
            Debug.Log("���Ƃ����M�~�b�N:" + gimmickFlag_Bridge);
        }

        if (timeCount >= 5f && timeCount <= 8)
        {
            //�����グ��
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0f), step);
            Debug.Log("2���");

            //�����オ���Ă���
            gimmickFlag_Bridge = true;
            Debug.Log("���Ƃ����M�~�b�N:" + gimmickFlag_Bridge);
        }

        if (timeCount >= 8f)
        {
            timeCount = 0;
            Debug.Log("�^�C�����Z�b�g");
        }


    }

    //�M�~�b�N�t���O�̃Q�b�^�[
    public bool Get_gimmickFlag_Bridge()
    {
        return gimmickFlag_Bridge;
    }
}

