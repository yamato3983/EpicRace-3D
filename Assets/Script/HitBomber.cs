using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBomber : MonoBehaviour
{

    //�G�t�F�N�g�p
    public GameObject particleObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dead") //Object�^�O�̕t�����Q�[���I�u�W�F�N�g�ƏՓ˂���������
        {
            Instantiate(particleObject, this.transform.position, Quaternion.identity); //�p�[�e�B�N���p�Q�[���I�u�W�F�N�g����
            Destroy(this.gameObject); //�I�u�W�F�N�g���폜
        }
    }
}
