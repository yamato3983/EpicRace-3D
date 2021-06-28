using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaulBound : MonoBehaviour
{

    private bool isBound = false; //�o�E���h�̃t���O

    private void FixedUpdate()
    { 

        if(Input.GetKeyDown(KeyCode.Z))
        {
            isBound = true;
        }

        //�t���O��ON�̎����˂�����
        if (isBound)
        {
        

            Rigidbody bar = this.GetComponent<Rigidbody>(); //Rigidbody�擾
            Vector3 force = new Vector3(0.0f, 5.0f, 1.5f);  //�^�����

            bar.AddForce(force, ForceMode.Impulse); //Impulse�͒��˂�

            isBound = false;
        }
    }
}
