using UnityEngine;
using UnityEngine.SceneManagement;

public class Titleback : MonoBehaviour
{
    void Update()
    {
        //�^�b�v�p����
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
