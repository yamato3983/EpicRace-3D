using UnityEngine;
using UnityEngine.SceneManagement;

public class clear_player05 : MonoBehaviour
{
    void Update()
    {
        //タップ用処理
        // if (Input.GetMouseButtonDown(0))
        //{
        // SceneManager.LoadScene("Stage03");
        // }
    }
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Stage06");
    }

}