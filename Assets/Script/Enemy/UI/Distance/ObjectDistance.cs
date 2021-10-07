using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDistance : MonoBehaviour
{
    public GameObject objA;
    public GameObject objB;

    void Update()
    {
        Vector3 unitychan = objA.transform.position;
        Vector3 Enemy = objB.transform.position;
        float dis = Vector3.Distance(unitychan, Enemy);

        if (dis > 10.0f)
        {
            objB.GetComponent<CPU_move1>().Speed();
        }
    }
}