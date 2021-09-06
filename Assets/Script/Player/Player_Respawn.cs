using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Respawn : MonoBehaviour
{
    GameObject Player;
    PlayerController PLScript;
    private float time = 0.0f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("unitychan");
        PLScript = Player.GetComponent<PlayerController>();
        rb = PLScript.rb;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("RespawnPoint"))
        {
            //bool PDead = PLScript.Dead;
            if (PLScript.Dead == true)
            {
                time += Time.deltaTime;
                if (time >= 0.5f)
                {
                    time = 0.0f;
                    //PLScript.agent.enabled = true;
                    Player.gameObject.SetActive(true);
                    //PDead = false;
                    PLScript.Dead = false;
                }
            }
        }


    }
}
