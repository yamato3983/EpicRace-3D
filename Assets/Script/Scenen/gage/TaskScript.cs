using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskScript : MonoBehaviour
{
    public bool isInProgress; // �i�s�����ǂ���
    public float Progress { get; private set; } = 0f; // �i�s�x
    public float difficulty = 0.001f; // �i�s���x

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInProgress)
        {
            Progress = 1f;
            isInProgress = false;
        }
    }
}
