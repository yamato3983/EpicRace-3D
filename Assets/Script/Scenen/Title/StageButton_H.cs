using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageButton_H : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PC用の処理
        // gameObject.GetComponent<Button>().onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        //タップ用処理
        // if(Input.GetMouseButtonDown(0))
        //{
        //  SceneManager.LoadScene("Stage01");
        // }
    }

    public void OnClickStartButton()
    {
        //NPCがゴールしたらシーンを変更する

        //追加にする予定
        //SceneManager.LoadScene("Stage01");

    }

    /*void StartGame()
    {
        //タップ用処理
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Stage01");
        }

        // GameSceneをロード
        //SceneManager.LoadScene("Stage01");
        //SceneManager.LoadScene("urabe01");
    }*/
}
