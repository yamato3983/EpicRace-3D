using UnityEngine;
using UnityEngine.SceneManagement;

public class retry02 : MonoBehaviour
{
    private void Start()
    {

    }
    public void OnClickStartButton()
    {
        //NPCがゴールしたらシーンを変更する

        SceneManager.LoadScene("urabe02");

    }
}