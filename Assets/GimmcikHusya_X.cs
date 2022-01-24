using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmcikHusya_X : MonoBehaviour
{

    [SerializeField]
    private float angle;

    [SerializeField]
    private float step;           //���x����������

    private Vector3 pos;          //���W
    private Quaternion rot;       //�p�x

    private float speed;
    private float timeCount; //���ԃJ�E���g

    public bool gimmickFlag_Bata;   //true:�ʂ�� false:�ʂ�Ȃ�


    private void Start()
    {
        //������
        step = 0;
        speed = 180f;

        //�ŏ��͒ʂ��
        gimmickFlag_Bata = true;
    }

    void Update()
    {
        timeCount += Time.deltaTime;   //�Ō�̃t���[������̌o�ߎ��Ԃ����Z
        step = speed * Time.deltaTime; //�X�s�[�h�ƍŏI�t���[���̎��Ԃ��|�����킹��
        rot = this.transform.rotation; //���݂�Rotation���擾


        if (timeCount >= 0f && timeCount <= 0.5f)
        {


            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(90, 0, 0), step);
            Debug.Log("1���");
            gimmickFlag_Bata = false;


        }

        if (timeCount >= 0.5f && timeCount <= 1.0f)
        {
            gimmickFlag_Bata = true;
        }


        if (timeCount >= 1.0f && timeCount <= 1.5f)
        {

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(180, 0, 0f), step);
            Debug.Log("2���");
            gimmickFlag_Bata = false;


        }

        if (timeCount >= 1.5f && timeCount <= 2.0f)
        {
            gimmickFlag_Bata = true;
        }

        if (timeCount >= 2.0f && timeCount <= 2.5f)
        {

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(90, 0, 0f), step);
            Debug.Log("2���");
            gimmickFlag_Bata = false;


        }
        if (timeCount >= 2.5f && timeCount <= 3.0f)
        {
            gimmickFlag_Bata = true;
        }

        if (timeCount >= 3.0f && timeCount <= 3.5f)
        {

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0f), step);
            Debug.Log("2���");
            gimmickFlag_Bata = false;


        }

        //�b
        if (timeCount >= 4.0f)
        {
            timeCount = 0;
            Debug.Log("�^�C�����Z�b�g");
            gimmickFlag_Bata = true;
            ;
        }
    }

    //�M�~�b�N�t���O�̃Q�b�^�[
    public bool Get_gimmickFlag_Bata()
    {
        return gimmickFlag_Bata;
    }
}


