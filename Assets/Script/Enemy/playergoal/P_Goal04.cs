using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替えに使用するライブラリ

public class P_Goal04 : MonoBehaviour
{
    //NPCのスクリプト
    GameObject yokoaridance;
    public YokoariController4 script_p04;

    public bool stage04;

    // Start is called before the first frame update
    void Start()
    {
        stage04 = false;
    }

    // Update is called once per frame
    void Update()
    {
        yokoaridance = GameObject.Find("yokoaridance");
        //script_p04 = unitychan.GetComponent<PlayerController4>();

        //NPCがゴールしたらシーンを変更する
        if (script_p04.Gflg == true)
        {
            stage04 = true;
            SceneManager.LoadScene("Clear_player04", LoadSceneMode.Single);
        }
    }
}
