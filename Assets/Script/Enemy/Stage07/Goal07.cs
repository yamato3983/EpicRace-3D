using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class Goal07 : MonoBehaviour
{
    //NPC�̃X�N���v�g
    GameObject Enemy;
    public CPU_move07 script_cm07;

    public bool stage06;

    // Start is called before the first frame update
    void Start()
    {
        stage06 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy = GameObject.Find("Enemy07");
        //script_cm01 = Enemy.GetComponent<CPU_move1>();

        //NPC���S�[��������V�[����ύX����
        if (script_cm07.goal == true)
        {
            stage06 = true;
            SceneManager.LoadScene("Clear_CPU07", LoadSceneMode.Single);
        }
    }
}
