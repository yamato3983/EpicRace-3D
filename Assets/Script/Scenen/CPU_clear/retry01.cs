using UnityEngine;
using UnityEngine.SceneManagement;

public class retry01 : MonoBehaviour
{
    private void Start()
    {
        
    }
    void Update()
    {
        //�^�b�v�p����
        //if (Input.GetMouseButtonDown(0))
       // {
            //SceneManager.LoadScene("Stage01");
       //}
    }

    public void OnClickStartButton()
    { 
        //NPC���S�[��������V�[����ύX����

        SceneManager.LoadScene("Stage01");
      
    }
}
