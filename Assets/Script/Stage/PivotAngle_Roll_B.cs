using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PivotAngle_Roll_B : MonoBehaviour
{

    [SerializeField]
    private float angle;

    [SerializeField]
    private float step;            //���x����������

    private Vector3 pos;          //���W
    private Quaternion rot;       //�p�x

    private float speed;
    private float timeCount; //���ԃJ�E���g

    [SerializeField]
    public bool gimmickFlag_Roll;

    public enum Gimmick
    {
        MOVE, //�ғ�
        STOP  //��~��
    }

    Gimmick gimmick = Gimmick.STOP; //�ŏ��͒�~���Ă�

    private void Start()
    {
        //������
        step = 0;
        speed = 120f;

    }

    void Update()
    {
        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        step = speed * Time.deltaTime;
        rot = this.transform.rotation;

        if (timeCount >= 0f && timeCount <= 1.5f)
        {


            //�w�肵�������ɂ�������]����ꍇ
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(180, 0, 0), step);
            Debug.Log("1���");

            //��]���
            //gimmickFlag_Roll = false;
            //Debug.Log("��]�M�~�b�N" + gimmickFlag_Roll);

            gimmick = Gimmick.MOVE;

        }

        if (timeCount >= 2f && timeCount <= 3.5f)
        {
            Debug.Log("�O���O�؂�ւ��̈׉������Ȃ�");

            gimmick = Gimmick.STOP;

        }
        if (timeCount >= 5f && timeCount <= 6.5f)
        {

            gimmick = Gimmick.MOVE;

            //�w�肵�������ɂ�������]����ꍇ
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(0, 0, 0), step);
            Debug.Log("2���");

        }

        if (timeCount >= 6.5f && timeCount <= 8f)
        {

            Debug.Log("�O���O�؂�ւ��̈׉������Ȃ�");

            gimmick = Gimmick.STOP;

        }
        if (timeCount >= 9.5f)
        {
            //�^�C�}�[���Z�b�g
            timeCount = 0;
            Debug.Log("�^�C�����Z�b�g");
        }

        switch (gimmick)
        {
            case Gimmick.MOVE:
                gimmickFlag_Roll = false;
                break;
            case Gimmick.STOP:
                gimmickFlag_Roll = true;
                break;
        }

    }

    public bool Gimmick_Flag_Roll()
    {
        return gimmickFlag_Roll;
    }
}

