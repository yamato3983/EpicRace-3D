using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PivotAngle_Bridge_A : MonoBehaviour
{

    [SerializeField]
    private float angle;

    [SerializeField]
    private float step;           //���x����������

    private Vector3 pos;          //���W
    private Quaternion rot;       //�p�x

    private float speed;
    private float timeCount; //���ԃJ�E���g

    public bool gimmickFlag_Box;   //true:�����˂����Ă� false:��������Ă�


    private void Start()
    {
        //������
        step = 0;
        speed = 120f;

        //�ŏ��͋����˂����Ă�
        gimmickFlag_Box = true;
    }

    void Update()
    {
        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        step = speed * Time.deltaTime;
        rot = this.transform.rotation;

        //2�`4�b
        if (timeCount >= 2f && timeCount <= 4)
        {

            //��������
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(0, 0, -90f), step);
            Debug.Log("1���");

            //��������Ă���
            gimmickFlag_Box = false;
            Debug.Log("���M�~�b�N:" + gimmickFlag_Box);
        }

        //5�`8�b
        if (timeCount >= 5f && timeCount <= 8)
        {
            //�����グ��
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0f), step);
            Debug.Log("2���");

            //�����オ���Ă���
            gimmickFlag_Box = true;
            Debug.Log("���M�~�b�N:" + gimmickFlag_Box);
        }

        //8�b
        if (timeCount >= 8f)
        {
            timeCount = 0;
            Debug.Log("�^�C�����Z�b�g");
        }


    }

    //�M�~�b�N�t���O�̃Q�b�^�[
    public bool Get_gimmickFlag_Box()
    {
        return gimmickFlag_Box;
    }
}


