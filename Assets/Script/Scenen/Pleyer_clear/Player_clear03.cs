using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_clear03 : MonoBehaviour
{
    void Update()
    {
        //�^�b�v�p����
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Stage03");
        }
    }
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Stage03");
    }

}