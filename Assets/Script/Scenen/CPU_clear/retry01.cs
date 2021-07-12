using UnityEngine;
using UnityEngine.SceneManagement;

public class retry01 : MonoBehaviour
{
    private void Start()
    {
        
    }
    void Update()
    {
        //タップ用処理
        //if (Input.GetMouseButtonDown(0))
       // {
            //SceneManager.LoadScene("Stage01");
       //}
    }

    public void OnClickStartButton()
    { 
        //NPCがゴールしたらシーンを変更する

        SceneManager.LoadScene("Stage01");
      
    }
}
