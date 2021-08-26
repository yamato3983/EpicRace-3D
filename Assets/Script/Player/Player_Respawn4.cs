using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Respawn4 : MonoBehaviour
{
    GameObject Player4;
    PlayerController4 PLScript4;
    private float time2 = 0.0f;
    Rigidbody rb4;

    // Start is called before the first frame update
    void Start()
    {
        Player4 = GameObject.Find("unitychan");
        PLScript4 = Player4.GetComponent<PlayerController4>();
        rb4 = PLScript4.rb;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PLScript4.Dead == true)
        {
            time2 += Time.deltaTime;
            if (time2 >= 3.0f)
            {
                time2 = 0.0f;
                
                Player4.gameObject.SetActive(true);
                
                PLScript4.Dead = false;
            }
        }


    }
}
