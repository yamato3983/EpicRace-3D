using UnityEngine;
using UnityEngine.SceneManagement;

public class clear_player05 : MonoBehaviour
{
    void Update()
    {
        //�^�b�v�p����
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