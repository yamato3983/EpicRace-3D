using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private CharacterController enemyController;
    private Animator animator;
    //�@�ړI�n
    private Vector3 destination;
    [SerializeField]
    private float walkSpeed = 1.0f;
    //�@���x
    private Vector3 velocity;
    //�@�ړ�����
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 tmp = GameObject.Find("GoalLine_CPU").transform.position;
        GameObject.Find("GoalLine_CPU").transform.position = new Vector3(tmp.x, tmp.y, tmp.z);

        enemyController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        destination = new Vector3(tmp.x, tmp.y, tmp.z);
        Debug.Log("aaa" + new Vector3(tmp.x, tmp.y, tmp.z));
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyController.isGrounded)
        {
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 2.0f);
            direction = (destination - transform.position).normalized;
            transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
            velocity = direction * walkSpeed;
            Debug.Log(destination);
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        enemyController.Move(velocity * Time.deltaTime);
    }
}
