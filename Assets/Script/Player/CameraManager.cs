using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    GameObject player;
    PlayerController pscript;

   // private GameObject mainCamera;      //メインカメラ格納用
    //private GameObject subCamera;       //サブカメラ格納用 

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

        //メインカメラとサブカメラをそれぞれ取得
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
            //サブカメラをアクティブに設定
            //mainCamera.SetActive(false);
            //subCamera.SetActive(true);
        }
        else if (cflg == false)
        {
            MainCamera.depth = 1;
            SubCamera.depth = 0;
            //メインカメラをアクティブに設定
            //subCamera.SetActive(false);
            //mainCamera.SetActive(true);
        }

    }
}