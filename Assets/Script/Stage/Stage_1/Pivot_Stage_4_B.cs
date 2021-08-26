using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot_Stage_4_B : MonoBehaviour
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
        speed = 130f;

        //�ŏ��͋����˂����Ă�
        gimmickFlag_Bridge = true;
    }

    void Update()
    {
        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        step = speed * Time.deltaTime;
        rot = this.transform.rotation;

        //2�`4�b
        if (timeCount >= 3f && timeCount <= 5)
        {

            //��������
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(0, 90, 90f), step);
            Debug.Log("1���");

            //��������Ă���
            gimmickFlag_Bridge = false;
            Debug.Log("���M�~�b�N:" + gimmickFlag_Bridge);
        }

        //5�`8�b
        if (timeCount >= 6f && timeCount <= 6.7f)
        {
            //�����グ��
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 90, 0f), step);
            Debug.Log("2���");

        }
        if (timeCount >= 6.75f)
        {
            //�����オ���Ă���
            gimmickFlag_Bridge = true;
            Debug.Log("���M�~�b�N:" + gimmickFlag_Bridge);

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