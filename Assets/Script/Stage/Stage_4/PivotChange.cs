using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotChange : MonoBehaviour
{

    /*********
    Gizmoとは、任意のオブジェクトを可視化する機能
    **********/

    //原点マークのサイズ
    public float gizmosize = 0.2f;

    //原点マークの色
    public Color pivotColor = Color.yellow;

    // Update is called once per frame
    void OnDrawGizmos()
    {
        //ギズモに色を付ける
        Gizmos.color = pivotColor;

        //丸い点として可視化させる
        Gizmos.DrawWireSphere(transform.position, gizmosize);
    }
}
