using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CPU_move05 : MonoBehaviour
{
    private CharacterController enemyController;
    private Animator animator;


    //�@�ړI�n
    private Vector3 destination;
    [SerializeField]
    private float walkSpeed = 7.0f;
    //�@���x
    private Vector3 velocity;

    //�@�W�����v��
    [SerializeField]
    private float jumpPower = 2.0f;

    //�@�ړ�����
    private Vector3 direction;

    [SerializeField]
    public Rigidbody rb;


    //�W�����v��p�̃X�N���v�g
    GameObject JumpPad;
    public JumpPad jump_script;

    public bool j_flg;

    public float upForce = 50f; //������ɂ������

    GameObject GimmickElevator;
    public GimmickElevator el1;

    //�J�E���g�_�E���p
    GameObject GemeObject;
    public Countdown script_t1;

    public GameObject Enemy;

    //���X�|�[��
    public GameObject rp1;
    public GameObject rp2;
    public GameObject rp3;


    Vector3 pos1, pos2, pos3;

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
        rp2 = GameObject.Find("RespawnCPU2");
        rp3 = GameObject.Find("RespawnCPU3");

        pos1 = rp1.transform.position;
        //pos2 = rp2.transform.position;
        //pos3 = rp3.transform.position;

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

        j_flg = false;
        dead = false;
        Debug.Log("abc" + el1.LiftFlag);
    }

    private IEnumerator Dush()
    {
        //�J�E���g�_�E�����̓X�g�b�v���Ă�
        if (script_t1.startflg == false)
        {
            animator.SetFloat("Speed", 0.0f);
        }

        //�Ƃ肠����4�b�ɂ��Ă邯�ǕύX���邩��
        yield return new WaitForSeconds(2.0f);

        //�J�E���g�_�E����0�̂Ƃ��ɑ���o��
        if (script_t1.startflg == true)
        {
            animator.SetFloat("Speed", 1.0f);
        }

        if (walkSpeed == 0)
        {
            animator.SetFloat("Speed", 0.0f);
        }
    }

    //�^�O�̔���(Stay)
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "jump")
        {
            if (jump_script.Gimmick_Jump == true)
            {
                velocity.y += jumpPower;
            }
        }

        //���S�]�[���ɓ��������̏���(�M�~�b�N��1�Ԗ�)
        if (other.tag == "Dead")
        {
            dead = true;
            j_flg = false;
            Enemy.SetActive(false);
            //1�b���CallRespawn2�֐������s����
            Invoke("CallRespawn2", 2f);
        }

        if (other.tag == "Dead_02")
        {
            dead = true;
            j_flg = false;
            Enemy.SetActive(false);
            Invoke("CallRespawn3", 2f);
        }


        if (other.tag == "Hammer")
        {
            dead = true;
            Enemy.SetActive(false);
            //1�b���CallRespawn1�֐������s����
            Invoke("CallRespawn1", 2f);

        }


        if (other.tag == "Goal")
        {
            goal = true;
            walkSpeed = 0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //2�p�^�[���̏���(0�`1)
        int value = Random.Range(0, 3);
        //�M�~�b�N�̒ʉߔ���
        if (other.tag == "judge")
        {
            switch (value)
            {
                //�~�߂�
                case 0:

                    walkSpeed = 0;
                    //�Z�b���Call�֐������s����
                    Invoke("Call", 6f);

                    break;

                //�i�s����
                case 1:
                    walkSpeed = 7;
                    break;

                case 2:
                    walkSpeed = 0;
                    Invoke("Call", 2f);
                    break;
            }
        }
        //���t�g�̒ʉߔ���
        if (other.tag == "judge2")
        {
            switch (el1.LiftFlag)
            {
                case false:
                    walkSpeed = 4f;

                    break;

                case true:
                    walkSpeed = 0;

                    break;
            }
        }
        //2�p�^�[���̏���(0�`1)
        int value1 = 0;//Random.Range(0, 3);
        //�M�~�b�N�̒ʉߔ���
        if (other.tag == "judge3")
        {
            switch (value1)
            {
                //�~�߂�
                case 0:

                    walkSpeed = 0;
                    //�Z�b���Call�֐������s����
                    Invoke("Call", 6.5f);

                    break;

                //�i�s����
                case 1:
                    walkSpeed = 0;
                    Invoke("Call", 0.5f);
                    break;

                case 2:
                    walkSpeed = 0;
                    Invoke("Call", 3.5f);
                    break;
            }
        }
        
        //���t�g���㏸���Ă�Ƃ�
        if (other.tag == "up" && el1.LiftFlag == true)
        {
            walkSpeed = 3f;
        }
        if (other.tag == "up" && el1.LiftFlag == false)
        {
            walkSpeed = 0;
        }
    }

    //���b�ォ�ɌĂяo�����߂̏���
    void Call()
    {
        walkSpeed = 7.0f;
    }

    //�����̂��߂̃N�[���^�C���p
    void CallRespawn1()
    {
        Enemy.SetActive(true);
        transform.position = new Vector3(pos1.x, pos1.y, pos1.z);
    }

    void CallRespawn2()
    {
        Enemy.SetActive(true);
        transform.position = new Vector3(pos2.x, pos2.y, pos2.z);
    }

    void CallRespawn3()
    {
        Enemy.SetActive(true);
        transform.position = new Vector3(pos3.x, pos3.y, pos3.z);
    }
}
