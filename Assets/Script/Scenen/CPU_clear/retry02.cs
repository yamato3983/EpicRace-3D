using UnityEngine;
using UnityEngine.SceneManagement;

public class retry02 : MonoBehaviour
{
    private void Start()
    {

    }
    void Update()
    {
        //タップ用処理
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Stage02");
        }
    }

    public void OnClickStartButton()
    {
        //NPCがゴールしたらシーンを変更する
        SceneManager.LoadScene("Stage02");

    }
}