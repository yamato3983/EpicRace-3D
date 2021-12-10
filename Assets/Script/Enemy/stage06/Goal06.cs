using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替えに使用するライブラリ

public class Goal06 : MonoBehaviour
{
    //NPCのスクリプト
    GameObject Enemy;
    public move06 script_cm06;

    public bool stage06;

    // Start is called before the first frame update
    void Start()
    {
        stage06 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy = GameObject.Find("Enemy06");
        //script_cm01 = Enemy.GetComponent<CPU_move1>();

        //NPCがゴールしたらシーンを変更する
        if (script_cm06.goal == true)
        {
            stage06 = true;
            SceneManager.LoadScene("Clear_CPU06", LoadSceneMode.Single);
        }
    }
}
