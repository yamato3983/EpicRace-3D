using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_Bar : MonoBehaviour
{

    private Rigidbody cylinder; //�������I�u�W�F�N�g��錾

    void Update()
    {
        Transform tp = this.transform;
        Vector3 pos = tp.position;     //���ݍ��W�擾

        if (Input.GetKey(KeyCode.Space))
        {
            //pos.z += 0.01f;
            cylinder.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        }

        //tp.position = pos; //�ύX�������W�𔽉f
    }
}
