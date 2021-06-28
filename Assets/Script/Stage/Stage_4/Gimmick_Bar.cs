using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_Bar : MonoBehaviour
{

    private Rigidbody cylinder; //動かすオブジェクトを宣言

    void Update()
    {
        Transform tp = this.transform;
        Vector3 pos = tp.position;     //現在座標取得

        if (Input.GetKey(KeyCode.Space))
        {
            //pos.z += 0.01f;
            cylinder.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        }

        //tp.position = pos; //変更した座標を反映
    }
}
