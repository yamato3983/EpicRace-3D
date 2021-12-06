using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.transform.SetParent(null);
        }
    }
}
