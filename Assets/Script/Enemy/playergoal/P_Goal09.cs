using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替えに使用するライブラリ

public class P_Goal09 : MonoBehaviour
{
    //NPCのスクリプト
    GameObject Boat_Player;
    public PlayerController9 script_p09;

    public bool stage09;

    // Start is called before the first frame update
    void Start()
    {
        stage09 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Boat_Player = GameObject.Find("Boat_Player");

        //NPCがゴールしたらシーンを変更する
        if (script_p09.Gflg == true)
        {
            stage09 = true;
            SceneManager.LoadScene("clear_player9", LoadSceneMode.Single);
        }
    }
}
