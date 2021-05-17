using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ResPawn_PL : MonoBehaviour
{
    /*
    public GameObject PL;
    PlayerController PLScript;
    public bool Dead = false;
    public float cnt = 3f;
    Vector3 tmp;

    // Use this for initialization
    void Start()
    {
        PL = GameObject.Find("Player");
        tmp=PL.transform.position;


        PLScript =PL.GetComponent<PlayerController>();

    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dead")
        {
            Dead = true;
        }

    }
    */

        /*
    // Update is called once per frame
    void Update()
    {

        if (Dead == true)
        {
            Vector3 tmp = GameObject.Find("Player").transform.position;
            GameObject.Find("Player").transform.position = new Vector3(tmp.x + 100, tmp.y, tmp.z);
            PL.SetActive(false);
            cnt -= Time.deltaTime;
            
        }

        if (cnt <= 0)
        {
            Dead = false;
            cnt = 3f;
            PL.SetActive(true);

        }

    }
    */
}
