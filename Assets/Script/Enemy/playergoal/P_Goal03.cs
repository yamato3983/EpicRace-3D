using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class P_Goal03 : MonoBehaviour
{
    //NPC�̃X�N���v�g
    GameObject unitychan;
    public PlayerController3 script_p03;

    public bool stage03;

    // Start is called before the first frame update
    void Start()
    {
        stage03 = false;
    }

    // Update is called once per frame
    void Update()
    {
        unitychan = GameObject.Find("yokoaridance");
        //script_p03 = unitychan.GetComponent<PlayerController3>();

        //NPC���S�[��������V�[����ύX����
        if (script_p03.Gflg == true)
        {
            stage03 = true;
            SceneManager.LoadScene("Clear_player03", LoadSceneMode.Single);
        }
    }
}
