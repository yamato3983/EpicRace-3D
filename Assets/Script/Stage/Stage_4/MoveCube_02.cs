using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube_02 : MonoBehaviour
{
    //��������
    private float speed = 7.0f;

    //�J�E���g
    private float timeCount;

    [SerializeField]
    public bool gimmickFlag_Wail;   //true:�����˂����Ă� false:��������Ă�

    // Use this for initialization
    void Start()
    {
        gimmickFlag_Wail = false;
    }

    // Update is called once per frame
    void Update()
    {

        timeCount += Time.deltaTime;   //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        //2�b
        if (timeCount >= 1 && timeCount <= 1.7)
        {
            //���~
            MoveDown();
        }
        if(timeCount >= 1.7 && timeCount <= 2.8)
        {
            //�t���O�̐؂�ւ�
            gimmickFlag_Wail = true;
        }

        if (timeCount >= 3.0 && timeCount <= 4)
        {
            //�㏸
            MoveUp();
            //�t���O�̐؂�ւ�
            gimmickFlag_Wail = false;
        }

        if (timeCount > 5.1)
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

