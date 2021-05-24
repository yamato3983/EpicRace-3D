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

    /**********************************************
     Subject�Ƃ����N���X�Ɏ�������Ă���@�\�Ƃ���
     ������o�^(�w��)����Subscribe�Ə��������s����OnNext�Ƃ������\�b�h������

     Subscribe:���b�Z�[�W�̎󂯎�莞�Ɏ��s����֐���o�^
     OnNext:Subscribe�œo�^���ꂽ�֐��Ƀ��b�Z�[�W��n���Ď��s����
     **********************************************/

    /*������string���n����Subject���`(int��bool���̌^���\)
    Subject<string> sub_string = new Subject<string>();

    //������bool���n����Subject���`
    Subject<bool> sub_bool = new Subject<bool>();

    /*Subject�̂����AIObsevable���������J���āA������o�^�o����悤�ɂ���
    public IObserver<string> Observer
    {
        get { return _subject; }
    }
    */

    private void Start()
    {
        //������
        step = 0;
        speed = 120f;

        //�ŏ��͕���
        gimmickFlag_Roll = true;
    }

    void Update()
    {
        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        step = speed * Time.deltaTime;
        rot = this.transform.rotation;

        if (timeCount >= 0f && timeCount <= 2)
        {


            //�w�肵�������ɂ�������]����ꍇ
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(180, 0, 0), step);
            Debug.Log("1���");

            //��]���
            gimmickFlag_Roll = false;
            Debug.Log("��]�M�~�b�N" + gimmickFlag_Roll);

        }

        if (timeCount >= 2.1f && timeCount <= 5f)
        {
            Debug.Log("�O���O�؂�ւ��̈׉������Ȃ�");

            //��]��~
            gimmickFlag_Roll = true;
            Debug.Log("��]�M�~�b�N" + gimmickFlag_Roll);

        }
        if (timeCount >= 5.1f && timeCount <= 8f)
        {
            //��]���
            gimmickFlag_Roll = false;
            Debug.Log("��]�M�~�b�N" + gimmickFlag_Roll);

            //�w�肵�������ɂ�������]����ꍇ
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0f), step);
            Debug.Log("2���");

        }

        if (timeCount >= 8.1f && timeCount <= 10f)
        {

            Debug.Log("�O���O�؂�ւ��̈׉������Ȃ�");

            //��]��~
            gimmickFlag_Roll = true;
            Debug.Log("��]�M�~�b�N" + gimmickFlag_Roll);


        }
        if (timeCount >= 10.1f)
        {
            //�^�C�}�[���Z�b�g
            timeCount = 0;
            Debug.Log("�^�C�����Z�b�g");
        }


    }

    public bool Gimmick_Flag_Roll()
    {
        return gimmickFlag_Roll;
    }
}

