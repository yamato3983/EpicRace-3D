using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class P_Goal09 : MonoBehaviour
{
    //NPC�̃X�N���v�g
    GameObject Boat_Player;
    public PlayerController9 script_p09;

    public bool stage09;

    // Start is called before the first frame update
    void Start()
    {
        stage09 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Boat_Player = GameObject.Find("Boat_Player");

        //NPC���S�[��������V�[����ύX����
        if (script_p09.Gflg == true)
        {
            stage09 = true;
            SceneManager.LoadScene("clear_player9", LoadSceneMode.Single);
        }
    }
}
