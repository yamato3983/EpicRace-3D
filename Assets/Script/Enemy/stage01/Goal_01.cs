using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class Goal_01 : MonoBehaviour
{
    //NPC�̃X�N���v�g
    GameObject Enemy;
    public CPU_move1 script_cm01;

    public bool stage01;
   
    // Start is called before the first frame update
    void Start()
    {
        stage01 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy = GameObject.Find("Enemy");
        //script_cm01 = Enemy.GetComponent<CPU_move1>();

        //NPC���S�[��������V�[����ύX����
        if (script_cm01.goal == true)
        {
            stage01 = true;
            SceneManager.LoadScene("Clear_CPU", LoadSceneMode.Single);
        }
    }
}
