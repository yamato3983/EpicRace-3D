using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CPU_move08 : MonoBehaviour
{
    private CharacterController enemyController;
    private Animator animator;

    //�@�ړI�n
    private Vector3 destination;
    [SerializeField]
    private float walkSpeed = 7f;
    //�@���x
    private Vector3 velocity;
    //�@�ړ�����
    private Vector3 direction;

    //�J�E���g�_�E���p
    GameObject GemeObject;
    public Countdown script_t1;

    public GameObject Enemy;

    //�J�E���g�_�E���p
    GameObject StelsManager;
    public GimmickStels script_s1;

    //���X�|�[��
    public GameObject rp1;
    public GameObject rp2;

    Vector3 pos1, pos2;

    private bool isRespon = false;

    public bool dead;

    //NPC���S�[�����������ǂ���
    public bool goal;

    private bool conflag;
    private bool stelsflg;

    private bool judge;
    private bool judge2;
    private bool judge3;

    // Start is called before the first frame update
    void Start()
    {
        judge = false;
        //���S�t���O
        dead = false;

        stelsflg = true;

        Vector3 tmp = GameObject.Find("judge").transform.position;
        GameObject.Find("judge").transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
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
            if (judge == true)
            {
                Vector3 tmp = GameObject.Find("judge1").transform.position;
                GameObject.Find("judge1").transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
                enemyController = GetComponent<CharacterController>();
                animator = GetComponent<Animator>();
                destination = new Vector3(tmp.x, tmp.y, tmp.z);
                
            }

            if(judge2 == true)
            {
                Vector3 tmp = GameObject.Find("judge2").transform.position;
                GameObject.Find("judge2").transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
                enemyController = GetComponent<CharacterController>();
                animator = GetComponent<Animator>();
                destination = new Vector3(tmp.x, tmp.y, tmp.z);
                
            }

            if(judge3 == true)
            {
                Vector3 tmp = GameObject.Find("GoalLine_CPU").transform.position;
                GameObject.Find("GoalLine_CPU").transform.position = new Vector3(tmp.x, tmp.y, tmp.z);

                enemyController = GetComponent<CharacterController>();
                animator = GetComponent<Animator>();
                destination = new Vector3(tmp.x, tmp.y, tmp.z);
                
            }

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

    //�^�O�̔���
    private void OnTriggerStay(Collider other)
    {
        //1�Ԗ�
        if (other.tag == "judge")
        {
            judge = true;
        }

        //2�Ԗ�
        if(other.tag == "judge2")
        {
            judge2 = true;
        }

        if(other.tag == "judge3")
        {
            judge3 = true;
        }

        //���R�A�����[��
        if (other.tag == "judgeBrigge")
        {
            //4�p�^�[���̏���(0�`4)
            int value = 0;// Random.Range(0, 3);
            switch (value)
            {
                //�~�߂�
                case 0: 
                    
                    walkSpeed = 0;
                    //2�b���Call�֐������s����
                    Invoke("Call", 2f);
              
                    break;

                case 1:

                    walkSpeed = 0;
                    Invoke("Call", 2.2f);

                    break;

                case 2:

                    walkSpeed = 7;
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //���S�]�[���ɓ��������̏���(�M�~�b�N��1�Ԗ�)
        if (other.tag == "Dead")
        {
            dead = true;
            Enemy.SetActive(false);
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
        //�����o��
        walkSpeed = 7;
    }

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

    public void Speed()
    {
        walkSpeed = 7;
    }
}
