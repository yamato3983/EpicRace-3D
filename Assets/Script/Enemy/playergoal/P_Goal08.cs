using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class P_Goal08 : MonoBehaviour
{
    //NPC�̃X�N���v�g
    GameObject unitychan;
    public PlayerController8 script_p08;

    public bool stage08;

    // Start is called before the first frame update
    void Start()
    {
        stage08 = false;
    }

    // Update is called once per frame
    void Update()
    {
        unitychan = GameObject.Find("unitychan");

        //NPC���S�[��������V�[����ύX����
        if (script_p08.Gflg == true)
        {
            stage08 = true;
            SceneManager.LoadScene("clear_player08", LoadSceneMode.Single);
        }
    }
}
