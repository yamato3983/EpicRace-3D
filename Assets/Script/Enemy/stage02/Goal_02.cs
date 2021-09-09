using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替えに使用するライブラリ

public class Goal_02 : MonoBehaviour
{
    //NPCのスクリプト
    GameObject Enemy01;
    public CPU_move02 script_cm02;

    public bool stage02;

    // Start is called before the first frame update
    void Start()
    {
        stage02 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy01 = GameObject.Find("Enemy02");
        //script_cm02 = Enemy01.GetComponent<CPU_move02>();

        //NPCがゴールしたらシーンを変更する
        if (script_cm02.goal == true)
        {
            stage02 = true;
            SceneManager.LoadScene("Clear_CPU02", LoadSceneMode.Single);
        }
    }
}
