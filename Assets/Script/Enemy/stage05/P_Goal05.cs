using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替えに使用するライブラリ

public class P_Goal05 : MonoBehaviour
{
    //NPCのスクリプト
    GameObject unitychan;
    public PlayerController script_p05;

    public bool stage05;

    // Start is called before the first frame update
    void Start()
    {
        stage05 = false;
    }

    // Update is called once per frame
    void Update()
    {
        unitychan = GameObject.Find("unitychan");
        //script_p01 = unitychan.GetComponent<PlayerController>();

        //NPCがゴールしたらシーンを変更する
        if (script_p05.Gflg == true)
        {
            stage05 = true;
            SceneManager.LoadScene("Clear_player", LoadSceneMode.Single);
        }
    }
}
