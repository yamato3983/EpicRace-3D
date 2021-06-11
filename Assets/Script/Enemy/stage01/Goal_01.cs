using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替えに使用するライブラリ

public class Goal_01 : MonoBehaviour
{
    //NPCのスクリプト
    GameObject Enemy;
    public CPU_move01 script_cm01;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Enemy = GameObject.Find("Enemy");
        script_cm01 = Enemy.GetComponent<CPU_move01>();

        //NPCがゴールしたらシーンを変更する
        if (script_cm01.goal == true)
        {
            SceneManager.LoadScene("Clear_CPU", LoadSceneMode.Single);
        }
    }
}
