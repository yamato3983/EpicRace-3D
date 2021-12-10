using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替えに使用するライブラリ

public class P_Goal05 : MonoBehaviour
{
    //NPCのスクリプト
    GameObject unitychan;
    public PlayerController5 script_p05;

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
        //script_p03 = unitychan.GetComponent<PlayerController3>();

        //NPCがゴールしたらシーンを変更する
        if (script_p05.Gflg == true)
        {
            stage05 = true;
            SceneManager.LoadScene("clear_player05", LoadSceneMode.Single);
        }
    }
}
