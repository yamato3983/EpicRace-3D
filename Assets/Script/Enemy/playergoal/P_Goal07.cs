using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替えに使用するライブラリ

public class P_Goal07 : MonoBehaviour
{
    //NPCのスクリプト
    GameObject unitychan;
    public PlayerController7 script_p07;

    public bool stage07;

    // Start is called before the first frame update
    void Start()
    {
        stage07 = false;
    }

    // Update is called once per frame
    void Update()
    {
        unitychan = GameObject.Find("unitychan");

        //NPCがゴールしたらシーンを変更する
        if (script_p07.Gflg == true)
        {
            stage07 = true;
            SceneManager.LoadScene("clear_player07", LoadSceneMode.Single);
        }
    }
}
