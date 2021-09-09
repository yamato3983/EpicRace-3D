using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CPU_move02 : MonoBehaviour
{
    private CharacterController enemyController;
    private Animator animator;

    //�@�ړI�n
    private Vector3 destination;
    [SerializeField]
    private float walkSpeed = 5f;
    //�@���x
    private Vector3 velocity;
    //�@�ړ�����
    private Vector3 direction;

    //�J�E���g�_�E���p
    GameObject GemeObject;
    public Countdown script_t1;

    public GameObject Enemy;

    //���X�|�[��
    public GameObject rp1;
 

    Vector3 pos1, pos2;

    private bool isRespon = false;

    public bool dead;

    //NPC���S�[�����������ǂ���
    public bool goal;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 tmp = GameObject.Find("GoalLine_CPU").transform.position;
        GameObject.Find("GoalLine_CPU").transform.position = new Vector3(tmp.x, tmp.y, tmp.z);

        enemyController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        destination = new Vector3(tmp.x, tmp.y, tmp.z);
        velocity = Vector3.zero;

        //���X�|�[��
        rp1 = GameObject.Find("RespawnCPU");
       
        pos1 = rp1.transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyController.isGrounded)
        {
            velocity = Vector3.zero;
            transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
            direction = (destination - transform.position).normalized;
            StartCoroutine("Dush");
            if (script_t1.startflg == true)
            {
                velocity = direction * walkSpeed;
            }
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        enemyController.Move(velocity * Time.deltaTime);

        dead = false;
    }

    private IEnumerator Dush()
    {
        //�J�E���g�_�E�����̓X�g�b�v���Ă�
        if (script_t1.startflg == false)
        {
            animator.SetFloat("Speed", 0.0f);
        }

        //�Ƃ肠����4�b�ɂ��Ă邯�ǕύX���邩��
        yield return new WaitForSeconds(3.0f);

        //�J�E���g�_�E����0�̂Ƃ��ɑ���o��
        if (script_t1.startflg == true)
        {
            animator.SetFloat("Speed", 5.0f);
        }
    }

    //�^�O�̔���
    private void OnTriggerEnter(Collider other)
    {
        //�M�~�b�N�̒ʉߔ���
        if (other.tag == "judge")
        {
            //2�p�^�[���̏���(0�`6)
            int value = Random.Range(0, 6);

            switch (value)
            {
                //�~�߂�
                case 0:
                case 1:

                    walkSpeed = 0;
                    //4�b���Call�֐������s����
                    Invoke("Call", 4f);

                    break;

                case 2:
                case 3:

                    walkSpeed = 0;
                    //2�b���Call�֐������s����
                    Invoke("Call", 2f);

                    break;

                //�i�s����
                case 4:
                case 5:
                    walkSpeed = 5;

                    break;
            }
        }

        //���S�]�[���ɓ��������̏���(�M�~�b�N��1�Ԗ�)
        if (other.tag == "Dead")
        {
            dead = true;
            Enemy.SetActive(false);
            Invoke("CallRespawn1", 2f);
        }

        if (other.tag == "Dead2")
        {
            dead = true;
            transform.position = new Vector3(pos2.x, pos2.y, pos2.z);

        }

        if(other.tag == "Gimmick_Conveyer")
        {
            walkSpeed = 3.0f;
        }

        if (other.tag != "Gimmick_Conveyer")
        {
            walkSpeed = 4.5f;
        }

        if (other.tag == "Goal")
        {
            goal = true;
            animator.SetFloat("Speed", 0.0f);
        }
    }

    //���b�ォ�ɌĂяo�����߂̏���
    void Call()
    {
        //�����o��
        walkSpeed = 5;
    }

    void CallRespawn1()
    {
        Enemy.SetActive(true);
        transform.position = new Vector3(pos1.x, pos1.y, pos1.z);
    }
}
