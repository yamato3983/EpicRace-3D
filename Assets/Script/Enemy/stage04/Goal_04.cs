using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class Goal_04 : MonoBehaviour
{
    //NPC�̃X�N���v�g
    GameObject Enemy04;
    public CPU_move04 script_cm04;

    public bool stage04;

    // Start is called before the first frame update
    void Start()
    {
        stage04 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy04 = GameObject.Find("Enemy04");
        script_cm04 = Enemy04.GetComponent<CPU_move04>();

        //NPC���S�[��������V�[����ύX����
        if (script_cm04.goal == true)
        {
            stage04 = true;
            SceneManager.LoadScene("Clear_CPU04", LoadSceneMode.Single);
        }
    }
}
