using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替えに使用するライブラリ

public class Goal_04 : MonoBehaviour
{
    //NPCのスクリプト
    GameObject Enemy04;
    public CPU_move04 script_cm04;

    public bool stage04;

    // Start is called before the first frame update
    void Start()
    {
        stage04 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy04 = GameObject.Find("Enemy04");
        script_cm04 = Enemy04.GetComponent<CPU_move04>();

        //NPCがゴールしたらシーンを変更する
        if (script_cm04.goal == true)
        {
            stage04 = true;
            SceneManager.LoadScene("Clear_CPU04", LoadSceneMode.Single);
        }
    }
}
