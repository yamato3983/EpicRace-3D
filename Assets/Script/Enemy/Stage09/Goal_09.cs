using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class Goal_09 : MonoBehaviour
{
    //NPC�̃X�N���v�g
    GameObject Enemy;
    public move09 script_cm09;

    public bool stage09;

    // Start is called before the first frame update
    void Start()
    {
        stage09 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy = GameObject.Find("Enemy09");
        //script_cm01 = Enemy.GetComponent<CPU_move1>();

        //NPC���S�[��������V�[����ύX����
        if (script_cm09.goal == true)
        {
            stage09 = true;
            SceneManager.LoadScene("Clear_CPU09", LoadSceneMode.Single);
        }
    }
}
