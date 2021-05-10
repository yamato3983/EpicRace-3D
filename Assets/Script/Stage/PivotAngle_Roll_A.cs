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
    private float step = 0;            //���x����������

    private Vector3 pos;          //���W
    private Quaternion rot;       //�p�x

    private float speed = 120f;
    private float timeCount; //���ԃJ�E���g

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
        /*Observable.Timer(TimeSpan.FromSeconds(2)).Subscribe(_ => Debug.Log("2�b�x��Ď��s"));
        �e�L�X�g���󂯎��Ƃ�������O�ɏo���֐���o�^
        sub_bool.Where(AngleFlag == true ==");
        ���s
        sub_string.OnNext("�I���I���I��");
        */
    }

    void Update()
    {
        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        step = speed * Time.deltaTime;
        rot = this.transform.rotation;

        if (timeCount >= 2f && timeCount <= 4)
        {

            //�w�肵�������ɂ�������]����ꍇ
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(180, 0, 0), step);
            Debug.Log("1���");
        }

        if (timeCount >= 5f && timeCount <= 8)
        {
            //�w�肵�������ɂ�������]����ꍇ
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0f), step);
            Debug.Log("2���");

        }

        if (timeCount >= 8f)
        {
            timeCount = 0;
            Debug.Log("�^�C�����Z�b�g");
        }


    }
}

