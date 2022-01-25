using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_clear08 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Stage08");
    }
}
