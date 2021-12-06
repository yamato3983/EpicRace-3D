using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCPU : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "CPU")
        {
            col.gameObject.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "CPU")
        {
            col.gameObject.transform.SetParent(null);
        }
    }
}
