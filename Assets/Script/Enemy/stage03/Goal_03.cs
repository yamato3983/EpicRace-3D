using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替えに使用するライブラリ

public class Goal_03 : MonoBehaviour
{
    //NPCのスクリプト
    GameObject Enemy03;
    public CPU_move03 script_cm03;

    public bool stage03;

    // Start is called before the first frame update
    void Start()
    {
        stage03 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy03 = GameObject.Find("Enemy03");
        script_cm03 = Enemy03.GetComponent<CPU_move03>();

        //NPCがゴールしたらシーンを変更する
        if (script_cm03.goal == true)
        {
            stage03 = true;
            SceneManager.LoadScene("Clear_CPU03", LoadSceneMode.Single);
        }
    }
}
