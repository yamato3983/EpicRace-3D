using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube_03 : MonoBehaviour
{

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
            //�㏸
            MoveUp();
        }

        if (timeCount >= 5 && timeCount <= 5.75f)
        {
            //���~
            MoveDown();
        }

        if (timeCount > 6f)
        {
            timeCount = 0;
        }

    }

    void MoveUp()
    {

        //��������
         float speed = 3.0f;

        //transform�擾
        Transform myTrans = this.transform;
        //���݂̍��W�擾
        Vector3 pos = myTrans.position;

        //�ړ���
        Vector3 direction = new Vector3(pos.x, pos.y + 6.35f, pos.z);

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, direction, step);
    }

    void MoveDown()
    {

        //��������
        float speed = 8.0f;

        //transform�擾
        Transform myTrans = this.transform;
        //���݂̍��W�擾
        Vector3 pos = myTrans.position;

        //�ړ���
        Vector3 direction = new Vector3(pos.x, pos.y - 6.35f, pos.z);

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, direction, step);
    }
}
