using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundDown : MonoBehaviour
{

    Rigidbody rd; //���W�b�h�{�f�B

    private void Start()
    {
        //�I�u�W�F�N�g��Rigidbody���擾
        rd = this.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("gravityChange", 4.0f);
        }
    }

    private void gravityChange()
    {
        //�d�͂�ON�ɂ���
        rd.useGravity = true;
    }
}
