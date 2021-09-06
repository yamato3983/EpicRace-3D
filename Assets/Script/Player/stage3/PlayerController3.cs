using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;

public class PlayerController3 : MonoBehaviour
{
    GameObject HP;
    //image�̃R���|�[�l���g
    Image gaugeCtrl;

    // Animator �R���|�[�l���g
    private Animator animator;

    // Animator�̐ݒ肵���t���O�̖��O
    private const string key_isRun = "isRun";

    private float time = 0.0f;

    public GameObject RP;
    public GameObject RP2;

    GameObject Player;

    //PivotBridge������ϐ�
    GameObject PB_A;
    GameObject PB_B;
    GameObject jumpend;

    PivotAngle_Bridge_A PB_A_Script; //PivotAngle_Bridge_A������ϐ�
    PivotAngle_Bridge_B PB_B_Script; //PivotAngle_Bridge_B������ϐ�

    [SerializeField]
    GameObject GoalLine_PL;	// �ړ��\��n�̃I�u�W�F�N�g
    //public Transform target = GameObject.Find("GoalLine_PL").transform;
    //public NavMeshAgent agent;
    int flg = 1;      //�i�ނ��~�܂邩�̃t���O

    Vector3 tmp, tmp2;//���X�|�[���|�C���g�̍��W������ϐ�
    Vector3 jp;
    public Rigidbody rb;

    public bool Gflg = false;
    public bool Dead = false;
    public bool Cflg = false;


    public GameObject timer;
    public Countdown t1;
    private float timeToEnableInputs;

    float speed;

    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();

        speed = 5.0f;
        HP = GameObject.Find("HP");
        gaugeCtrl = HP.GetComponent<Image>();
        gaugeCtrl.fillAmount = 1.0f;

        //�J�����̃t���O�����̓��C���̈�false
        Cflg = true;

        Player = GameObject.Find("unitychan");

        //timer = GameObject.Find("Timer");
        //t1 = timer.GetComponent<Countdown>();
        this.timeToEnableInputs = Time.time + 3.0f;


        // �����ɐݒ肳��Ă���Animator�R���|�[�l���g���K������
        this.animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        //���X�|�[����|�C���g�̃f�[�^���󂯎��
        RP = GameObject.Find("RespawnPoint");
        RP2 = GameObject.Find("RespawnPoint2");
        jumpend = GameObject.Find("Jump_End");
        jp = jumpend.transform.position;
        tmp = RP.transform.position;
        tmp2 = RP2.transform.position;

        var agentRigidbody = GetComponent<Rigidbody>();
        //Rigidody��Kinematic���X�^�[�g����OFF�ɂ���
        agentRigidbody.isKinematic = false;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        var agentRigidbody = GetComponent<Rigidbody>();
        if (collision.gameObject.tag == "Dead" || collision.gameObject.tag == "Hammer")
        {
            Debug.Log("���񂾁I�I");
            this.gameObject.SetActive(false);
            Player.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
            Dead = true;
            flg = 0;
        }
        if (collision.gameObject.tag == "Dead_02")
        {
            Debug.Log("���񂾁I�I");
            this.gameObject.SetActive(false);
            Player.transform.position = new Vector3(tmp2.x, tmp2.y, tmp2.z);
            Dead = true;
            flg = 0;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var agentRigidbody = GetComponent<Rigidbody>();

        if (other.tag == "Goal")
        {
            //NavMeshAgent agent = GetComponent<NavMeshAgent>();
            //agent.isStopped = true;
            Debug.Log("�S�[�[�[��");
            Gflg = true;
        }
        
    }

    

    void Update()
    {
        var agentRigidbody = GetComponent<Rigidbody>();

        if (Time.time >= this.timeToEnableInputs)
        {
            if (Gflg == false && Dead == false)
            {
                Cflg = false;
                if (gaugeCtrl.fillAmount > 0.0f)
                {

                    if (Input.GetMouseButton(0))
                    {
                        //�}�E�X��������Ă���Ƃ��̓Q�[�W�����炵�~�܂�
                        gaugeCtrl.fillAmount -= 0.0013f;
                        flg = 0;
                    }

                    else
                    {
                        //�}�E�X��������Ă��Ȃ��Ƃ��̓Q�[�W�̉�
                        gaugeCtrl.fillAmount += 0.0005f;         
                        flg = 1;
                    }
                }
                else if (gaugeCtrl.fillAmount <= 0.0f)
                {
                    //�}�E�X��������Ă��Ȃ��Ƃ��̓Q�[�W�̉�
                    gaugeCtrl.fillAmount += 0.0005f;
                    flg = 1;
                }
                if (flg == 1)
                {
                    // Wait����Run�ɑJ�ڂ���
                    this.animator.SetBool(key_isRun, true);
                    Player.transform.position += transform.forward * speed * Time.deltaTime;
                    
                }
                else if (flg == 0)
                {
                    // Run����Wait�ɑJ�ڂ���
                    this.animator.SetBool(key_isRun, false);
                    
                }
            }
            if (Dead == true)
            {
                // Run����Wait�ɑJ�ڂ���
                this.animator.SetBool(key_isRun, false);
            }
            if (Gflg == true)
            {
                // Run����Wait�ɑJ�ڂ���
                this.animator.SetBool(key_isRun, false);

            }
        }
    }
}
