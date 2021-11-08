using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundDown : MonoBehaviour
{

    Rigidbody rd; //���W�b�h�{�f�B

    public Countdown script_t1; //�J�E���g�_�E���̂��

    private void Start()
    {
        //�I�u�W�F�N�g��Rigidbody���擾
        rd = this.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //�v���C���[���G�ꂽ��
        if (other.CompareTag("Player"))
        {
            Invoke("gravityChange", 8.0f);
        }

        //CPU���G�ꂽ��
        if(other.CompareTag("CPU"))
        {
            Invoke("gravityChange", 8.0f);
        }

        if(other.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }

    private void gravityChange()
    {
        //�d�͂�ON�ɂ���
        rd.useGravity = true;
    }
}
