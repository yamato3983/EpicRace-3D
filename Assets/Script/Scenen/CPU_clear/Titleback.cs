using UnityEngine;
using UnityEngine.SceneManagement;

public class Titleback : MonoBehaviour
{
    void Update()
    {
        //タップ用処理
        //if (Input.GetMouseButtonDown(0))
       // {
            //SceneManager.LoadScene("StartScene");
        //}
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("StartScene");
    }

}
