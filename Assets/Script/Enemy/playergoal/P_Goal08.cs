using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替えに使用するライブラリ

public class P_Goal08 : MonoBehaviour
{
    //NPCのスクリプト
    GameObject unitychan;
    public PlayerController8 script_p08;

    public bool stage08;

    // Start is called before the first frame update
    void Start()
    {
        stage08 = false;
    }

    // Update is called once per frame
    void Update()
    {
        unitychan = GameObject.Find("unitychan");

        //NPCがゴールしたらシーンを変更する
        if (script_p08.Gflg == true)
        {
            stage08 = true;
            SceneManager.LoadScene("clear_player08", LoadSceneMode.Single);
        }
    }
}
