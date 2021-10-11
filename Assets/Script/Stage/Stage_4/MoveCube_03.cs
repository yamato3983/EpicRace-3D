using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube_03 : MonoBehaviour
{
    //��������
    private float speed = 10.0f;

    //�J�E���g
    private float timeCount;

    [SerializeField]
    public bool gimmickFlag_Wail;   //true:�����˂����Ă� false:��������Ă�

    // Use this for initialization
    void Start()
    {
        gimmickFlag_Wail = true;
    }

    // Update is called once per frame
    void Update()
    {

        timeCount += Time.deltaTime;   //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        //2�b
        if (timeCount >= 1f && timeCount <= 1.5f)
        {
            //�㏸
            MoveUp();
            //�t���O�̐؂�ւ�
            gimmickFlag_Wail = false;

        }
        if (timeCount >= 2f && timeCount <= 2.5f)
        {
            //�t���O�̐؂�ւ�
            //gimmickFlag_Wail = false;
        }

        if (timeCount >= 3f && timeCount <= 3.5f)
        {
            //���~
            MoveDown();


        }


        if (timeCount > 3.5)
        {
            timeCount = 0;
            //�t���O�̐؂�ւ�
            gimmickFlag_Wail = true;
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

    //�M�~�b�N�t���O�̃Q�b�^�[
    public bool Get_gimmickFlag_Wail()
    {
        return gimmickFlag_Wail;
    }
}
