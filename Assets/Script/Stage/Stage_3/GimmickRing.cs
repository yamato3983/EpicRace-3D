using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickRing : MonoBehaviour
{

    [SerializeField]
    private float angle;

    [SerializeField]
    private float step;           //���x����������

    private Vector3 pos;          //���W
    private Quaternion rot;       //�p�x

    private float speed;
    private float timeCount; //���ԃJ�E���g

    public bool gimmickFlag_Ring;   //true:�����˂����Ă� false:��������Ă�


    private void Start()
    {
        //������
        step = 0;
        speed = 120f;

        //�ŏ��͒ʂ��
        gimmickFlag_Ring = true;
    }

    void Update()
    {
        timeCount += Time.deltaTime;   //�Ō�̃t���[������̌o�ߎ��Ԃ����Z
        step = speed * Time.deltaTime; //�X�s�[�h�ƍŏI�t���[���̎��Ԃ��|�����킹��
        rot = this.transform.rotation; //���݂�Rotation���擾

        //0�`2�b
        if (timeCount >= 2f && timeCount <= 4f)
        {

            //��]
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(180, 0, 0), step);


            //��]��
            gimmickFlag_Ring = false;
        
        }

        //2�`3�b
        if(timeCount >= 4 && timeCount <= 6)
        {
            gimmickFlag_Ring = true;
        }

        //3�`5�b
        if (timeCount >= 6f && timeCount <= 8f)
        {
            //��]
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0f), step);


            //��]���ĂȂ�
            gimmickFlag_Ring = false;
           
        }
        //5�`7�b
        if(timeCount >=8f && timeCount <=10f)
        {
            gimmickFlag_Ring = true;
        }

        //7�b
        if (timeCount >= 10f)
        {
            timeCount = 0;
            Debug.Log("�^�C�����Z�b�g");
        }


    }

    //�M�~�b�N�t���O�̃Q�b�^�[
    public bool Get_gimmickFlag_Box()
    {
        return gimmickFlag_Ring;
    }
}

