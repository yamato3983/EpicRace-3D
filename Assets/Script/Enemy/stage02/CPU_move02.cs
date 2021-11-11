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
    private float walkSpeed = 7f;
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
    public GameObject rp2;

    Vector3 pos1, pos2;

    private bool isRespon = false;

    public bool dead;

    //NPC���S�[�����������ǂ���
    public bool goal;

    private bool conflag;

    private bool juage;

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
       
        pos1 = rp1.transform.position;
        pos2 = rp2.transform.position;

        juage = false;
        //���S�t���O
        dead = false;
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

        //�R���x�A�[�p
        if(conflag == true)
        {
            walkSpeed = 3.0f;
        }
        if(juage == true && conflag == false)
        {
            //walkSpeed = 7.0f;

        }
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
            animator.SetFloat("Speed", 1.0f);
        }

        if (walkSpeed == 0)
        {
            animator.SetFloat("Speed", 0.0f);
        }
    }

    //�^�O�̔���
    private void OnTriggerEnter(Collider other)
    {

        //�M�~�b�N�̒ʉߔ���
        if (other.tag == "judge")
        {
            //juage = true;
            //2�p�^�[���̏���(0�`5)
            int value = Random.Range(0, 3);
            switch (value)
            {
                //�~�߂�
                case 0:

                    walkSpeed = 0;
                    //2�b���Call�֐������s����
                    Invoke("Call", 2f);

                    break;

                //�i�s���Ȃ�
                case 1:
                    walkSpeed = 0;
                    //2�b���Call�֐������s����
                    Invoke("Call", 2.5f);
                    break;

                //�i�s���Ȃ�
                case 2:

                    walkSpeed = 0;
                    //3�b���Call�֐������s����
                    Invoke("Call", 3f);

                    break;

                //�i�s���Ȃ�
                /*case 3:
                
                    walkSpeed = 0;
                    //2�b���Call�֐������s����
                    Invoke("Call", 3.5f);

                    break;


                //�i�s����
                case 4:
               
                    walkSpeed = 7;

                    break;*/
            }
        }

        //���S�]�[���ɓ��������̏���(�M�~�b�N��1�Ԗ�)�ȒP
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
            Invoke("CallRespawn2", 2f);
        }

        if(other.tag == "Gimmick_Conveyer")
        {
            conflag = true;
            walkSpeed = 3.0f;
        }

        if (other.tag != "Gimmick_Conveyer")
        {
            conflag = false;
           // walkSpeed = 5.0f;
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
