using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CPU_move1 : MonoBehaviour
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

    //�J�E���g�_�E���p
    GameObject GemeObject;
    public Countdown script_t1;

    public GameObject Enemy;

    //���X�|�[��
    public GameObject rp1;
    public GameObject rp2;

    Vector3 pos1, pos2;


    // �I�u�W�F�N�g����~����^�[�Q�b�g�I�u�W�F�N�g�Ƃ̋������i�[����ϐ�
    public float stopDistance;
    // �I�u�W�F�N�g���^�[�Q�b�g�Ɍ������Ĉړ����J�n���鋗�����i�[����ϐ�
    public float moveDistance;

    // �^�[�Q�b�g�I�u�W�F�N�g�� Transform�R���|�[�l���g���i�[����ϐ�
    public Transform target;


    private bool isRespon = false;

    public bool dead;

    //NPC���S�[�����������ǂ���
    public bool goal;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

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

        // �ϐ� targetPos ���쐬���ă^�[�Q�b�g�I�u�W�F�N�g�̍��W���i�[
        //Vector3 targetPos = target.position;

        //float current_speed = animator.GetFloat("Speed");

        // ���[�V�����؂�ւ���10�b�Ŋ���������
        //animator.SetFloat("Speed", current_speed + Time.deltaTime * 0.1f);

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

        if (walkSpeed == 0)
        {
            animator.SetFloat("Speed", 0.0f);
        }
    }

    /*private void Respawn()
    {
        if (GameObject.Find("RespawnCPU2"))
        {
            if (CPU_Script.dead == true)
            {
                time += Time.deltaTime;
                if (time >= 1.0f)
                {
                    time = 0.0f;
                    CPU_Script.agent.enabled = true;
                    Enemy.gameObject.SetActive(true);
                    CPU_Script1.dead = false;
                }
            }
        }
    }*/

    //�^�O�̔���
    private void OnTriggerEnter(Collider other)
    {
        //�M�~�b�N�̒ʉߔ���
        if (other.tag == "judge")
        {
            //2�p�^�[���̏���(0�`9)
            int value = Random.Range(0, 5);

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
                case 3:
               
                    walkSpeed = 0;
                    //2�b���Call�֐������s����
                    Invoke("Call", 3.5f);

                    break;

                //�i�s����
                case 4:
                    walkSpeed = 7;

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

        if (other.tag == "Dead_02")
        {
            dead = true;
            Enemy.SetActive(false);
            Invoke("CallRespawn2", 2f);

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

    //ObjectDistance�p�̊֐�
    public void Speed()
    {
        walkSpeed = 9;
    }
}
