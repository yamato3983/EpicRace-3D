using UnityEngine;
using UnityEngine.SceneManagement;

public class retry02 : MonoBehaviour
{
    private void Start()
    {

    }
    void Update()
    {
        //�^�b�v�p����
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Stage02");
        }
    }

    public void OnClickStartButton()
    {
        //NPC���S�[��������V�[����ύX����
        SceneManager.LoadScene("Stage02");

    }
}