using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskScript : MonoBehaviour
{
    public bool isInProgress; // 進行中かどうか
    public float Progress { get; private set; } = 0f; // 進行度
    public float difficulty = 0.001f; // 進行速度

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
