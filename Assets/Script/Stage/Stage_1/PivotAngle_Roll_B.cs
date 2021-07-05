using System;
using System.Collections;
using System.Collections.Generic;
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
        speed = 60f;

    }

    void Update()
    {
        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        step = speed * Time.deltaTime;
        rot = this.transform.rotation;

        //0�`3�b
        if (timeCount >= 0f && timeCount <= 3.5f)
        {

            //�M�~�b�N�̏�Ԃ𓮂��Ă��Ԃ�
            gimmick = Gimmick.MOVE;

            //�w�肵�������ɂ�������]����ꍇ
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(-180, 0, 0), step);
            Debug.Log("1���");

        }

        //3�`6�b
        if (timeCount >= 3.0f && timeCount <= 6.4f)
        {
            Debug.Log("�O���O�؂�ւ��̈׉������Ȃ�");

            //�M�~�b�N�̏�Ԃ��~�܂��Ă��Ԃ�
            gimmick = Gimmick.STOP;

        }

        //6�`9�b
        if (timeCount >= 6.5f && timeCount <= 10.0f)
        {

            //�M�~�b�N�̏�Ԃ𓮂��Ă��Ԃ�
            gimmick = Gimmick.MOVE;

            //�w�肵�������ɂ�������]����ꍇ
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(0, 0, 0), step);
            Debug.Log("2���");

        }

        //9�`12�b
        if (timeCount >= 10.0f && timeCount <= 13f)
        {

            Debug.Log("�O���O�؂�ւ��̈׉������Ȃ�");

            //�M�~�b�N�̏�Ԃ��~�܂��Ă��Ԃ�
            gimmick = Gimmick.STOP;

        }

        //12�b
        if (timeCount >= 13f)
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

