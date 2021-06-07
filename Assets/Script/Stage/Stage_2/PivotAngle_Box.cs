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

    public bool gimmickFlag_Box;   //true:�����˂����Ă� false:��������Ă�


    private void Start()
    {
        //������
        step = 0;
        speed = 120f;

        //�ŏ��͒ʂ��
        gimmickFlag_Box = true;
    }

    void Update()
    {
        timeCount += Time.deltaTime;   //�Ō�̃t���[������̌o�ߎ��Ԃ����Z
        step = speed * Time.deltaTime; //�X�s�[�h�ƍŏI�t���[���̎��Ԃ��|�����킹��
        rot = this.transform.rotation; //���݂�Rotation���擾

        //0�`2�b
        if (timeCount >= 0f && timeCount <= 2f)
        {

            //��������
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(90, 0, 0), step);
            Debug.Log("1���");

            //��������Ă���
            gimmickFlag_Box = false;
            Debug.Log("���Ƃ����M�~�b�N:" + gimmickFlag_Box);
        }

        //2�`4�b
        if (timeCount >= 2f && timeCount <= 4f)
        {
            //�����グ��
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0f), step);
            Debug.Log("2���");

            //�����オ���Ă���
            gimmickFlag_Box = true;
            Debug.Log("���Ƃ����M�~�b�N:" + gimmickFlag_Box);
        }

        //�b
        if (timeCount >= 6f)
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

