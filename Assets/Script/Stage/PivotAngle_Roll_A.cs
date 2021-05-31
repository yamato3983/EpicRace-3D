using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PivotAngle_Roll_A : MonoBehaviour
{

    [SerializeField]
    private float angle;

    [SerializeField]
    private float step;            //���x����������

    private Vector3 pos;          //���W
    private Quaternion rot;       //�p�x

    private float speed;          //���b�|���ē�������
    private float timeCount;      //���ԃJ�E���g

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
        speed = 60f;

    }

    void Update()
    {
        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        step = speed * Time.deltaTime;
        rot = this.transform.rotation;

        if (timeCount >= 0f && timeCount <= 3f)
        {

            //�M�~�b�N�̏�Ԃ𓮂��Ă��Ԃ�
            gimmick = Gimmick.MOVE;

            //�w�肵�������ɂ�������]����ꍇ
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(180, 0, 0), step);
            Debug.Log("1���");
            
        }

        if (timeCount >= 3f && timeCount <= 6f)
        {
            Debug.Log("�O���O�؂�ւ��̈׉������Ȃ�");

            //�M�~�b�N�̏�Ԃ��~�܂��Ă��Ԃ�
            gimmick = Gimmick.STOP;

        }
        if (timeCount >= 6f && timeCount <= 9f)
        {

            //�M�~�b�N�̏�Ԃ𓮂��Ă��Ԃ�
            gimmick = Gimmick.MOVE;
 

            //�w�肵�������ɂ�������]����ꍇ
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(0, 0, 0), step);
            Debug.Log("2���");

        }

        if (timeCount >= 9f && timeCount <= 12f)
        {

            Debug.Log("�O���O�؂�ւ��̈׉������Ȃ�");

            //�M�~�b�N�̏�Ԃ��~�܂��Ă��Ԃ�
            gimmick = Gimmick.STOP;

        }
        if (timeCount >= 12f)
        {
            //�^�C�}�[���Z�b�g
            timeCount = 0;
            Debug.Log("�^�C�����Z�b�g");
        }

        switch (gimmick)
        {
            //�����Ă���
            case Gimmick.MOVE:
                gimmickFlag_Roll = false;
                break;
            //�~�܂��Ă���
            case Gimmick.STOP:
                gimmickFlag_Roll = true;
                break;
        }

    }


    //�M�~�b�N�t���O�̃Q�b�^�[
    public bool Gimmick_Flag_Roll()
    {
        return gimmickFlag_Roll;
    }
}

