using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_Roll_s5 : MonoBehaviour
{

    [SerializeField]
    private Vector3 speed;          //ç¿ïW
 
    private void Start()
    {

    }

    void Update()
    {

        transform.Rotate(speed, Space.Self);
    }
}

