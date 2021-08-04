using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube_02 : MonoBehaviour
{
    //��������
    private float speed = 3.0f;

    //�J�E���g
    private float timeCount;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timeCount += Time.deltaTime;   //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        //2�b
        if (timeCount >= 2 && timeCount <= 4)
        {
            //���~
            MoveDown();
        }

        if (timeCount >= 6 && timeCount <= 8)
        {
            //�㏸
            MoveUp();
        }

        if (timeCount > 8.1)
        {
            timeCount = 0;
        }

    }

    void MoveUp()
    {
        //transform�擾
        Transform myTrans = this.transform;
        //���݂̍��W�擾
        Vector3 pos = myTrans.position;

        //�ړ���
        Vector3 direction = new Vector3(pos.x, 7f, pos.z);

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, direction, step);
    }

    void MoveDown()
    {
        //transform�擾
        Transform myTrans = this.transform;
        //���݂̍��W�擾
        Vector3 pos = myTrans.position;

        //�ړ���
        Vector3 direction = new Vector3(pos.x, 2.02f, pos.z);

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, direction, step);
    }
}

