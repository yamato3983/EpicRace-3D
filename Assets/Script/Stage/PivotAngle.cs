using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotAngle : MonoBehaviour
{

    [SerializeField]
    GameObject handle;                //��]������I�u�W�F�N�g

    public bool rotflag;       //��]�t���O
    public float speed = 3f;          //��]�Ɋ|����b��
    public float rotAngle_DOWN = 90f; //��]���������p�x(����)
    public float rotAngle_UP = 0f;  //��]���������p�x(�グ)
    public float variation_DOWN;      //1�b�Ԃ̕ω���(����)
    public float variation_UP;        //1�b�Ԃ̕ω���(�グ)
    public float rot;                 //�p�x�̑���

    private void Start()
    {
        rotflag = true;
        rot = 12 * Time.deltaTime;
        variation_UP = rotAngle_UP / speed;
    }

    void Update()
    {



        if (rotflag == true)
        {

            iTween.RotateTo(gameObject, iTween.Hash("z", 90f, "delay", 2, "time", 1f));

            //��������������t���O��؂�ւ���
            if (gameObject.transform.localEulerAngles.z >= 45)
            {
                rotflag = false;
            }
        }

        if (rotflag == false)
        {
            iTween.RotateTo(gameObject, iTween.Hash("z", 0f, "delay", 2, "time", 1f));
        
            //�����オ������t���O��؂�ւ���
            if (gameObject.transform.localEulerAngles.z <= 0)
            {
                rotflag = true;
            }
        }

    }
}

