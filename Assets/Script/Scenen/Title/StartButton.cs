using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PC�p�̏���
       // gameObject.GetComponent<Button>().onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        //�^�b�v�p����
       // if(Input.GetMouseButtonDown(0))
        //{
          //  SceneManager.LoadScene("Stage01");
       // }
    }

    public void OnClickStartButton()
    {
        //NPC���S�[��������V�[����ύX����

        //SceneManager.LoadScene("Level");

          SceneManager.LoadScene("SelectStage");
        }

    }

    /*void StartGame()
    {
        //�^�b�v�p����
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Stage01");
        }

        // GameScene�����[�h
        //SceneManager.LoadScene("Stage01");
        //SceneManager.LoadScene("urabe01");
    }*/


