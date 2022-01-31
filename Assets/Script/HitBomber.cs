using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBomber : MonoBehaviour
{

    //エフェクト用
    public GameObject particleObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dead") //Objectタグの付いたゲームオブジェクトと衝突したか判別
        {
            Instantiate(particleObject, this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
            Destroy(this.gameObject); //オブジェクトを削除
        }
    }
}
