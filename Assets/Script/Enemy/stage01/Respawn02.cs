using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn02 : MonoBehaviour
{
    GameObject Enemy;
    CPU_move01 CPU_Script;
    private float time = 0.0f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.Find("Enemy");
        CPU_Script = Enemy.GetComponent<CPU_move01>();
        rb = CPU_Script.rb;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("RespawnCPU2"))
        {

            if (CPU_Script.dead == true)
            {
                time += Time.deltaTime;
                if (time >= 1.0f)
                {
                    time = 0.0f;
                    CPU_Script.agent.enabled = true;
                    Enemy.gameObject.SetActive(true);
                    CPU_Script.dead = false;
                }
            }
        }
    }
}