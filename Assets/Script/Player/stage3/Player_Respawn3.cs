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
        if (PLScript3.Dead == true)
        {
            time2 += Time.deltaTime;
            if (time2 >= 0.5f)
            {
                time2 = 0.0f;

                Player3.gameObject.SetActive(true);

                PLScript3.Dead = false;
            }
        }
        if (PLScript3.Rag == true)
        {
            time2 += Time.deltaTime;
            if (time2 >= 2.0f)
            {
                time2 = 0.0f;

                Player3.gameObject.SetActive(true);

                PLScript3.Dead = false;
                PLScript3.Rag = false;
            }
        }
    }
}
