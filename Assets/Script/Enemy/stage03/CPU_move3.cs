using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CPU_move3 : MonoBehaviour
{
    private CharacterController enemyController;
    private Animator animator;


    //�@�ړI�n
    private Vector3 destination;
    [SerializeField]
    private float walkSpeed = 4.0f;
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
        pos2 = rp2.transform.position;
        pos3 = rp3.transform.position;
       
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
            animator.SetFloat("Speed", 4.0f);
        }
    }

    //�^�O�̔���(Stay)
    private void OnTriggerStay(Collider other)
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

        if(other.tag == "Dead_02")
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

    //���b�ォ�ɌĂяo�����߂̏���
    void Call()
    {
        walkSpeed = 5.0f;
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
