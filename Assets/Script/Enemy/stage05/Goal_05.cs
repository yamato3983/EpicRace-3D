using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class Goal_05 : MonoBehaviour
{
    //NPC�̃X�N���v�g
    GameObject Enemy;
    public CPU_move05 script_cm05;

    public bool stage05;

    // Start is called before the first frame update
    void Start()
    {
        stage05 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy = GameObject.Find("Enemy05");
        //script_cm01 = Enemy.GetComponent<CPU_move1>();

        //NPC���S�[��������V�[����ύX����
        if (script_cm05.goal == true)
        {
            stage05 = true;
            SceneManager.LoadScene("Clear_CPU", LoadSceneMode.Single);
        }
    }
}
