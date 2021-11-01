using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yokoari_Respawn3 : MonoBehaviour
{
    GameObject Player3;
    YokoariController3 PLScript3;
    private float time2 = 0.0f;
    Rigidbody rb3;

    // Start is called before the first frame update
    void Start()
    {
        Player3 = GameObject.Find("yokoaridance");
        PLScript3 = Player3.GetComponent<YokoariController3>();
        rb3 = PLScript3.rb;
    }

    // Update is called once per frame
    void Update()
    {
        //bool PDead = PLScript.Dead;
        if (PLScript3.Dead == true)
        {
            time2 += Time.deltaTime;
            if (time2 >= 0.5f)
            {
                time2 = 0.0f;
                //PLScript3.agent.enabled = true;
                Player3.gameObject.SetActive(true);
                //PDead = false;
                PLScript3.Dead = false;
            }
        }


    }
}
