using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Respawn5 : MonoBehaviour
{
    GameObject Player5;
    PlayerController5 PLScript5;
    private float time2 = 0.0f;
    Rigidbody rb4;

    // Start is called before the first frame update
    void Start()
    {
        Player5 = GameObject.Find("unitychan");
        PLScript5 = Player5.GetComponent<PlayerController5>();
        rb4 = PLScript5.rb;
    }

    // Update is called once per frame
    void Update()
    {

        if (PLScript5.Dead == true)
        {
            time2 += Time.deltaTime;
            if (time2 >= 0.5f)
            {
                time2 = 0.0f;

                Player5.gameObject.SetActive(true);

                PLScript5.Dead = false;
            }
        }


    }
}
