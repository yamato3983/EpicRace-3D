using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替えに使用するライブラリ

public class P_Goal06 : MonoBehaviour
{
    //NPCのスクリプト
    GameObject unitychan;
    public PlayerController6 script_p06;

    public bool stage06;

    // Start is called before the first frame update
    void Start()
    {
        stage06 = false;
    }

    // Update is called once per frame
    void Update()
    {
        unitychan = GameObject.Find("unitychan");
        //script_p03 = unitychan.GetComponent<PlayerController3>();

        //NPCがゴールしたらシーンを変更する
        if (script_p06.Gflg == true)
        {
            stage06 = true;
            SceneManager.LoadScene("clear_player06", LoadSceneMode.Single);
        }
    }
}
