using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Respawn2 : MonoBehaviour
{
    GameObject Player2;
    PlayerController2 PLScript2;
    private float time2 = 0.0f;
    Rigidbody rb2;

    // Start is called before the first frame update
    void Start()
    {
        Player2 = GameObject.Find("unitychan");
        PLScript2 = Player2.GetComponent<PlayerController2>();
        rb2 = PLScript2.rb;
    }

    // Update is called once per frame
    void Update()
    {
        //bool PDead = PLScript.Dead;
        if (PLScript2.Dead == true)
        {
            time2 += Time.deltaTime;
            if (time2 >= 1.0f)
            {
                time2 = 0.0f;
                PLScript2.agent.enabled = true;
                Player2.gameObject.SetActive(true);
                //PDead = false;
                PLScript2.Dead = false;
            }
        }


    }
}

