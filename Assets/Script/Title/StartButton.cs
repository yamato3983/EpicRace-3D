using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PC用の処理
        gameObject.GetComponent<Button>().onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        //タップ用処理
        /*if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Main");
        }*/
    }

    void StartGame()
    {
        // GameSceneをロード
        SceneManager.LoadScene("Main");
    }

}
