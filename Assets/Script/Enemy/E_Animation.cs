using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Animation : MonoBehaviour
{
    private Animation animation;
    //フラグの名前
    private const string auto_isRun = "isRun";

    // Start is called before the first frame update
    void Start()
    {
        //Animationの設定した名前
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
