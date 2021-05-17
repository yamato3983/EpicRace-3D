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

    public bool gimmickFlag_Bridge;   //true:�����˂����Ă� false:��������Ă�

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

        //�ŏ��͋����˂����Ă�
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
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(0, 0, -90f), step);
            Debug.Log("1���");

            //��������Ă���
            gimmickFlag_Bridge = false;
            Debug.Log("���M�~�b�N:" + gimmickFlag_Bridge);
        }

        if (timeCount >= 5f && timeCount <= 8)
        {
            //�����グ��
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0f), step);
            Debug.Log("2���");

            //�����オ���Ă���
            gimmickFlag_Bridge = true;
            Debug.Log("���M�~�b�N:" + gimmickFlag_Bridge);
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


