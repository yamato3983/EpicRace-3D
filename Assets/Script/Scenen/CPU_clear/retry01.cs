using UnityEngine;
using UnityEngine.SceneManagement;

public class retry01 : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void OnClickStartButton()
    { 
        //NPCがゴールしたらシーンを変更する

        SceneManager.LoadScene("urabe01");
      
    }
}
