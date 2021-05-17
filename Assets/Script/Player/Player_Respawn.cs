using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Respawn : MonoBehaviour
{
    GameObject Player;
    PlayerController PLScript;
    private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        PLScript = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool PDead = PLScript.Dead;
        if (PDead == true)
        {
            time += Time.deltaTime;
            if (time >= 3.0f)
            {
                time = 0.0f;
                PLScript.agent.updatePosition = true;
                Player.gameObject.SetActive(true);
                PDead = false;
            }
        }


    }
}
