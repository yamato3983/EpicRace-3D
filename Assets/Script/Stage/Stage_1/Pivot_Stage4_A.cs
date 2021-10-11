using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot_Stage4_A : MonoBehaviour
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
        speed = 180f;

        //�ŏ��͋����˂����Ă�
        gimmickFlag_Bridge = true;
    }

    void Update()
    {
        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        step = speed * Time.deltaTime;
        rot = this.transform.rotation;

        //2�`4�b
        if (timeCount >= 0.7f && timeCount <= 1.7)
        {

            //��������
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(0, 90, -90f), step);
            Debug.Log("1���");

            //��������Ă���
            gimmickFlag_Bridge = false;
            Debug.Log("���M�~�b�N:" + gimmickFlag_Bridge);
        }

        //5�`8�b
        if (timeCount >= 2.4f && timeCount <= 3.4f)
        {
            //�����グ��
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 90, 0f), step);
            Debug.Log("2���");

            //�����オ���Ă���
            gimmickFlag_Bridge = true;
            Debug.Log("���M�~�b�N:" + gimmickFlag_Bridge);
        }

        //8�b
        if (timeCount >= 3.4f)
        {
            timeCount = 0;
            Debug.Log("�^�C�����Z�b�g");
        }


    }

    //�M�~�b�N�t���O�̃Q�b�^�[
    public bool Get_gimmickFlag_Box()
    {
        return gimmickFlag_Bridge;
    }
}


