using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替えに使用するライブラリ

public class P_Goal02 : MonoBehaviour
{
    //NPCのスクリプト
    GameObject unitychan;
    public PlayerController2 script_p02;

    public bool stage02;

    // Start is called before the first frame update
    void Start()
    {
        stage02 = false;
    }

    // Update is called once per frame
    void Update()
    {
        unitychan = GameObject.Find("yokoaridance");
        //script_p02 = unitychan.GetComponent<PlayerController2>();

        //NPCがゴールしたらシーンを変更する
        if (script_p02.Gflg == true)
        {
            stage02 = true;
            SceneManager.LoadScene("Clear_player02", LoadSceneMode.Single);
        }
    }
}
