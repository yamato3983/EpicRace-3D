using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Animation : MonoBehaviour
{
    private Animation animation;
    //�t���O�̖��O
    private const string auto_isRun = "isRun";

    // Start is called before the first frame update
    void Start()
    {
        //Animation�̐ݒ肵�����O
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
