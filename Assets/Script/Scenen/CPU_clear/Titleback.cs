using UnityEngine;
using UnityEngine.SceneManagement;

public class Titleback : MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("StartScene");
    }

}
