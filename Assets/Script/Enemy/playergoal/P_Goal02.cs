using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class P_Goal02 : MonoBehaviour
{
    //NPC�̃X�N���v�g
    GameObject unitychan;
    public PlayerController2 script_p02;

    public bool stage02;

    // Start is called before the first frame update
    void Start()
    {
        stage02 = false;
    }

    // Update is called once per frame
    void Update()
    {
        unitychan = GameObject.Find("yokoaridance");
        //script_p02 = unitychan.GetComponent<PlayerController2>();

        //NPC���S�[��������V�[����ύX����
        if (script_p02.Gflg == true)
        {
            stage02 = true;
            SceneManager.LoadScene("Clear_player02", LoadSceneMode.Single);
        }
    }
}
