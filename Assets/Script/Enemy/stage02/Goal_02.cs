using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class Goal_02 : MonoBehaviour
{
    //NPC�̃X�N���v�g
    GameObject Enemy01;
    public CPU_move02 script_cm02;

    public bool stage02;

    // Start is called before the first frame update
    void Start()
    {
        stage02 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy01 = GameObject.Find("Enemy02");
        //script_cm02 = Enemy01.GetComponent<CPU_move02>();

        //NPC���S�[��������V�[����ύX����
        if (script_cm02.goal == true)
        {
            stage02 = true;
            SceneManager.LoadScene("Clear_CPU02", LoadSceneMode.Single);
        }
    }
}
