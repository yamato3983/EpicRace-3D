using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_Conveyer : MonoBehaviour
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

    //UVスクロール速度
    [SerializeField]
    private float m_uvSpeed = 0.5f;

    private void Start()
    {
        //方向の正規化
        ConveyerDirection = ConveyerDirection.normalized;
    }

    private void FixedUpdate()
    {
        //ウィンウィン
        ScrollUV();

        if (isActive == true)
        {
            convSpeed = 0;
        }

        //消滅したオブジェクトは削除
        _rigidbodies.RemoveAll(r => r == null);

        foreach (var r in _rigidbodies)
        {
            //物体の移動速度のベルトコンベア方向の成分だけ取り出す
            var objectSpeed = Vector3.Dot(r.velocity, ConveyerDirection);

            //目標値以下なら加速する
            if (objectSpeed < Mathf.Abs(convSpeed))
            {
                r.AddForce(ConveyerDirection * pushPower, ForceMode.Acceleration);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //当たった奴にRigifBodyをぶち込んでやるぜぇぇぇぇぇぇ
        var rigidBody = collision.gameObject.GetComponent<Rigidbody>();
        _rigidbodies.Add(rigidBody);
    }

    void OnCollisionExit(Collision collision)
    {
        //離れてもRigidBodyをぶちこんでやるぜぇぇぇぇｌ
        //まぁ元からついてたら全然意味ないんですけど…
        var rigidBody = collision.gameObject.GetComponent<Rigidbody>();
        _rigidbodies.Remove(rigidBody);
    }

    //テクスチャのUV値をスクロールさせて、ベルトコンベアの見た目を表現する。
    void ScrollUV()
    {
        //アタッチされてるマテリアルテクスチャを、m_uvSpeedとタイムを掛けて動かす
        var material = GetComponent<Renderer>().material;
        Vector2 offset = material.mainTextureOffset;

        //右側(プレイヤーの進行方向と逆向きに動かす)
        offset += Vector2.right * m_uvSpeed * Time.deltaTime;

        material.mainTextureOffset = offset;

       
    }

}
