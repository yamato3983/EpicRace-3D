using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaulBound : MonoBehaviour
{

    private bool isBound = false; //バウンドのフラグ

    private void FixedUpdate()
    { 

        if(Input.GetKeyDown(KeyCode.Z))
        {
            isBound = true;
        }

        //フラグがONの時跳ねさせる
        if (isBound)
        {
        

            Rigidbody bar = this.GetComponent<Rigidbody>(); //Rigidbody取得
            Vector3 force = new Vector3(0.0f, 5.0f, 1.5f);  //与える力

            bar.AddForce(force, ForceMode.Impulse); //Impulseは跳ねる

            isBound = false;
        }
    }
}
