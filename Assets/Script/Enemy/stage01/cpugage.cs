using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cpugage : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector3(0,0,2);
        this.transform.position = target.position + offset;
    }
}
