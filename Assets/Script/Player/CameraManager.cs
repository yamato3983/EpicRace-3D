using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    GameObject player;
    PlayerController pscript;

   // private GameObject mainCamera;      //���C���J�����i�[�p
    //private GameObject subCamera;       //�T�u�J�����i�[�p 

    [SerializeField]
    Camera MainCamera;

    [SerializeField]
    Camera SubCamera;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("unitychan");
        pscript = player.GetComponent<PlayerController>();

        MainCamera.depth = 1;
        SubCamera.depth = 0;

        //���C���J�����ƃT�u�J���������ꂼ��擾
        //mainCamera = GameObject.Find("MainCamera ");
        //subCamera = GameObject.Find("SubCamera");

    }

    // Update is called once per frame
    void Update()
    {
        bool cflg = pscript.Cflg;
        if (cflg == true)
        {
            MainCamera.depth = 0;
            SubCamera.depth = 1;
            //�T�u�J�������A�N�e�B�u�ɐݒ�
            //mainCamera.SetActive(false);
            //subCamera.SetActive(true);
        }
        else if (cflg == false)
        {
            MainCamera.depth = 1;
            SubCamera.depth = 0;
            //���C���J�������A�N�e�B�u�ɐݒ�
            //subCamera.SetActive(false);
            //mainCamera.SetActive(true);
        }

    }
}