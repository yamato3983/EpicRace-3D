using UnityEngine;
using UnityEngine.SceneManagement;

public class retry07 : MonoBehaviour
{
    private void Start()
    {

    }
    void Update()
    {
        //タップ用処理
        //if (Input.GetMouseButtonDown(0))
        // {
        // SceneManager.LoadScene("Stage03");
        // }
    }

    public void OnClickStartButton()
    {
        //NPCがゴールしたらシーンを変更する

        SceneManager.LoadScene("Stage07");

    }
}
