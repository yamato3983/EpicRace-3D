using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Respawn3 : MonoBehaviour
{
    GameObject Player3;
    PlayerController3 PLScript3;
    private float time2 = 0.0f;
    Rigidbody rb3;

    // Start is called before the first frame update
    void Start()
    {
        Player3 = GameObject.Find("unitychan");
        PLScript3 = Player3.GetComponent<PlayerController3>();
        rb3 = PLScript3.rb;
    }

    // Update is called once per frame
    void Update()
    {
        //bool PDead = PLScript.Dead;
        if (PLScript3.Dead == true)
        {
            time2 += Time.deltaTime;
            if (time2 >= 3.0f)
            {
                time2 = 0.0f;
                PLScript3.agent.enabled = true;
                Player3.gameObject.SetActive(true);
                //PDead = false;
                PLScript3.Dead = false;
            }
        }


    }
}
