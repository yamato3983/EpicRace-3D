using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JumpPad : MonoBehaviour
{

    public Material[] _material;   //割り当てるマテリアル.
    private float step;           //何度ずつ動かすか
    private Vector3 scale;        //大きさ
    private float timeCount;      //時間カウント
    private float timelimit;      //動きを起こすカウント

    [SerializeField]
    public bool Gimmick_Jump;     //ジャンプ台のフラグ

    private JumpColor color;            //マテリアルの番号

    enum JumpColor
    {
        Jump_ON,  //ジャンプ ON
        Jump_OFF    //ジャンプ OFF
    }

    void Start()
    {
        color = 0;  //白
        Gimmick_Jump = false;
        timeCount = 0f;
        timelimit = 5f;


    }

    void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount < (timelimit / 2))
        {
            //ジャンプ台の色を白
            this.GetComponent<Renderer>().material.color = Color.white;

            //ジャンプフラグOFF
            Gimmick_Jump = false;
        }
        if((timelimit / 2) < timeCount)
        {
            //ジャンプ台の色を青
            //マテリアル変更
            this.GetComponent<Renderer>().material.color = Color.blue;
        }
        if(timeCount > 5f)
        {
            //カウントリセット
            timeCount = 0f;

            //ジャンプフラグON
            Gimmick_Jump = true;
           
        }

  
    }
}