using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class Goal08 : MonoBehaviour
{
    //NPC�̃X�N���v�g
    GameObject Enemy;
    public CPU_move08 script_cm08;

    public bool stage08;

    // Start is called before the first frame update
    void Start()
    {
        stage08 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy = GameObject.Find("Enemy08");
        //script_cm01 = Enemy.GetComponent<CPU_move1>();

        //NPC���S�[��������V�[����ύX����
        if (script_cm08.goal == true)
        {
            stage08 = true;
            SceneManager.LoadScene("Clear_CPU08", LoadSceneMode.Single);
        }
    }
}
