using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundDown : MonoBehaviour
{

    Rigidbody rd; //リジッドボディ

    public Countdown script_t1; //カウントダウンのやつ

    private void Start()
    {
        //オブジェクトのRigidbodyを取得
        rd = this.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーが触れた時
        if (other.CompareTag("Player"))
        {
            Invoke("gravityChange", 8.0f);
        }

        //CPUが触れた時
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
        //重力をONにする
        rd.useGravity = true;
    }
}
