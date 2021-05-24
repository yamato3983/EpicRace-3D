using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_Move : MonoBehaviour
{
    //コンベアが動いているか
    public bool isActive = false;

    //コンベアの初期設定速度
    public float convSpeed = 3.0f;

    //現在のコンベアの速度
    public float ConveyerSpeed { get { return _convSpeed; } }

    private float _convSpeed = 0;

    //コンベアの動く方向
    public Vector3 ConveyerDirection = Vector3.forward;

    //コンベアが物を運ぶ力(加速力)
    [SerializeField]
    private float pushPower = 50f;

    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();

    private void Start()
    {
        //方向の正規化
        ConveyerDirection = ConveyerDirection.normalized;
    }

    private void FixedUpdate()
    {
        if (isActive == true)
        {
            convSpeed = 0;
        }

        //消滅したオブジェクトは削除
        _rigidbodies.RemoveAll(r => r == null);

        foreach(var r in _rigidbodies)
        {
            //物体の移動速度のベルトコンベア方向の成分だけ取り出す
            var objectSpeed = Vector3.Dot(r.velocity, ConveyerDirection);

            //目標値以下なら加速する
            if(objectSpeed < Mathf.Abs(convSpeed))
            {
                r.AddForce(ConveyerDirection * pushPower, ForceMode.Acceleration);
            }
        }
    }
}
