using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class P_Goal06 : MonoBehaviour
{
    //NPC�̃X�N���v�g
    GameObject unitychan;
    public PlayerController6 script_p06;

    public bool stage06;

    // Start is called before the first frame update
    void Start()
    {
        stage06 = false;
    }

    // Update is called once per frame
    void Update()
    {
        unitychan = GameObject.Find("unitychan");
        //script_p03 = unitychan.GetComponent<PlayerController3>();

        //NPC���S�[��������V�[����ύX����
        if (script_p06.Gflg == true)
        {
            stage06 = true;
            SceneManager.LoadScene("clear_player06", LoadSceneMode.Single);
        }
    }
}
