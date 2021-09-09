using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替えに使用するライブラリ

public class P_Goal01 : MonoBehaviour
{
    //NPCのスクリプト
    GameObject unitychan;
    public PlayerController script_p01;

    public bool stage01;

    // Start is called before the first frame update
    void Start()
    {
        stage01 = false;
    }

    // Update is called once per frame
    void Update()
    {
        unitychan = GameObject.Find("unitychan");
        //script_p01 = unitychan.GetComponent<PlayerController>();

        //NPCがゴールしたらシーンを変更する
        if (script_p01.Gflg == true)
        {
            stage01 = true;
            SceneManager.LoadScene("Clear_player", LoadSceneMode.Single);
        }
    }
}
