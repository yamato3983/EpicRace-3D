using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class P_Goal07 : MonoBehaviour
{
    //NPC�̃X�N���v�g
    GameObject unitychan;
    public PlayerController7 script_p07;

    public bool stage07;

    // Start is called before the first frame update
    void Start()
    {
        stage07 = false;
    }

    // Update is called once per frame
    void Update()
    {
        unitychan = GameObject.Find("unitychan");

        //NPC���S�[��������V�[����ύX����
        if (script_p07.Gflg == true)
        {
            stage07 = true;
            SceneManager.LoadScene("clear_player07", LoadSceneMode.Single);
        }
    }
}
