using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class P_Goal05 : MonoBehaviour
{
    //NPC�̃X�N���v�g
    GameObject unitychan;
    public PlayerController5 script_p05;

    public bool stage05;

    // Start is called before the first frame update
    void Start()
    {
        stage05 = false;
    }

    // Update is called once per frame
    void Update()
    {
        unitychan = GameObject.Find("unitychan");
        //script_p03 = unitychan.GetComponent<PlayerController3>();

        //NPC���S�[��������V�[����ύX����
        if (script_p05.Gflg == true)
        {
            stage05 = true;
            SceneManager.LoadScene("clear_player05", LoadSceneMode.Single);
        }
    }
}
