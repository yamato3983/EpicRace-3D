using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundDown : MonoBehaviour
{

    Rigidbody rd; //リジッドボディ

    private void Start()
    {
        //オブジェクトのRigidbodyを取得
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
        //重力をONにする
        rd.useGravity = true;
    }
}
