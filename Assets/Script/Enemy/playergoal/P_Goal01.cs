using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class P_Goal01 : MonoBehaviour
{
    //NPC�̃X�N���v�g
    GameObject unitychan;
    public YokoariController script_p01;

    public bool stage01;

    // Start is called before the first frame update
    void Start()
    {
        stage01 = false;
    }

    // Update is called once per frame
    void Update()
    {
        unitychan = GameObject.Find("yokoaridance");
        //script_p01 = unitychan.GetComponent<PlayerController>();

        //NPC���S�[��������V�[����ύX����
        if (script_p01.Gflg == true)
        {
            stage01 = true;
            SceneManager.LoadScene("Clear_player", LoadSceneMode.Single);
        }
    }
}
