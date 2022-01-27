using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Respawn7 : MonoBehaviour
{
    GameObject Player6;
    PlayerController7 PLScript6;
    private float time2 = 0.0f;
    Rigidbody rb4;

    // Start is called before the first frame update
    void Start()
    {
        Player6 = GameObject.Find("unitychan");
        PLScript6 = Player6.GetComponent<PlayerController7>();
        rb4 = PLScript6.rb;
    }

    // Update is called once per frame
    void Update()
    {

        if (PLScript6.Dead == true)
        {
            time2 += Time.deltaTime;
            if (time2 >= 0.5f)
            {
                time2 = 0.0f;

                Player6.gameObject.SetActive(true);

                PLScript6.Dead = false;
            }
        }
        if (PLScript6.Rag == true)
        {
            time2 += Time.deltaTime;
            if (time2 >= 2.0f)
            {
                time2 = 0.0f;

                Player6.gameObject.SetActive(true);

                PLScript6.Dead = false;
                PLScript6.Rag = false;
            }
        }

    }
}
