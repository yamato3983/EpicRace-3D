using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_clear : MonoBehaviour
{
    void Update()
    {
        //�^�b�v�p����
       // if (Input.GetMouseButtonDown(0))
        //{
           // SceneManager.LoadScene("Stage02");
        //}
    }
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Stage02");
    }

}
