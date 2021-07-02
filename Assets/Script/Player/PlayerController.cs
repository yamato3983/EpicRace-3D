using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
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
    PivotAngle_Bridge_A PB_A_Script; //PivotAngle_Bridge_A������ϐ�
    PivotAngle_Bridge_B PB_B_Script; //PivotAngle_Bridge_B������ϐ�

    //PivotRoll������ϐ�
    GameObject PR_A;
    GameObject PR_B;
    PivotAngle_Roll_A PR_A_Script;
    PivotAngle_Roll_B PR_B_Script;

    [SerializeField]
    GameObject GoalLine_PL;	// �ړ��\��n�̃I�u�W�F�N�g
    //public Transform target = GameObject.Find("GoalLine_PL").transform;
    public NavMeshAgent agent;
    int flg = 1;      //�i�ނ��~�܂邩�̃t���O

    Vector3 tmp, tmp2;//���X�|�[���|�C���g�̍��W������ϐ�
    public Rigidbody rb;

    public bool Gflg = false;
    public bool Dead = false;
    public bool Cflg = false;

    public GameObject timer;
    public Countdown t1;
    private float timeToEnableInputs;

    //[SerializeField] NavMeshAgent nav_mesh_agent;
    //public bool Dead = false;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = 4.0f;
        HP = GameObject.Find("HP");
        gaugeCtrl = HP.GetComponent<Image>();
        gaugeCtrl.fillAmount = 1.0f;

        //�J�����̃t���O�����̓��C���̈�false
        Cflg = false;

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
        tmp = RP.transform.position;
        tmp2 = RP2.transform.position;

        //�X�e�[�W�M�~�b�N����f�[�^���󂯎��
        PB_A = GameObject.Find("PivotBridge_A");
        PB_A_Script = PB_A.GetComponent<PivotAngle_Bridge_A>();
        PB_B = GameObject.Find("PivotBridge_B");
        PB_B_Script = PB_B.GetComponent<PivotAngle_Bridge_B>();

        PR_A = GameObject.Find("PivotRoll_A");
        PR_A_Script = PR_A.GetComponent<PivotAngle_Roll_A>();
        PR_B = GameObject.Find("PivotRoll_B");
        PR_B_Script = PR_B.GetComponent<PivotAngle_Roll_B>();

        var agentRigidbody = agent.GetComponent<Rigidbody>();
        //Rigidody��Kinematic���X�^�[�g����ON�ɂ���
        agentRigidbody.isKinematic = true;
    }

    private void OnTriggerStay(Collider other)
    {
        //���̃M�~�b�N�̃t���O����
        bool bridgeAflg = PB_A_Script.gimmickFlag_Bridge;
        bool bridgeBflg = PB_B_Script.gimmickFlag_Bridge;

        //��]�M�~�b�N�̃t���O����
        bool rollAflg = PR_A_Script.gimmickFlag_Roll;
        bool rollBflg = PR_B_Script.gimmickFlag_Roll;

        var agentRigidbody = agent.GetComponent<Rigidbody>();

        if (other.tag == "Gimmick_Bridge" && bridgeBflg == false || other.tag == "Gimmick_Roll" && rollBflg == false)
        {
            Debug.Log("������I�I");
            //Cflg = false;

            //Navmesh��Rigidody��Kinematic��OFF
            agent.enabled = false;
            agentRigidbody.isKinematic = false;
            flg = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var agentRigidbody = agent.GetComponent<Rigidbody>();

        if (other.gameObject.tag == "Dead")
        {
            Debug.Log("���񂾁I�I");
            this.gameObject.SetActive(false);
            agent.Warp(new Vector3(tmp.x, tmp.y, tmp.z));
            Dead = true;
            flg = 0;

            //Navmesh��Rigidody��Kinematic��ON
            agentRigidbody.isKinematic = true;
            agent.enabled = true;
        }

        if (other.gameObject.tag == "Dead_02")
        {
            Debug.Log("���񂾁I�I(��]");
            this.gameObject.SetActive(false);
            agent.Warp(new Vector3(tmp2.x, tmp2.y, tmp2.z));
            Dead = true;
            flg = 0;


            //Navmesh��Rigidody��Kinematic��ON
            agentRigidbody.isKinematic = true;
            agent.enabled = true;
        }

        if (other.tag == "Goal")
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.isStopped = true;
            Debug.Log("�S�[�[�[��");
            Gflg = true;
        }

        if (other.gameObject.tag == "Respawn2")
        {
            Debug.Log("Respawn2�ɂӂꂽ");
            Cflg = true;
        }

        if (other.gameObject.tag == "EndGimmick")
        {
            Debug.Log("EndGimmick�ɂӂꂽ");
            Cflg = false;
        }
    }

    void Update()
    {

        if (Time.time >= this.timeToEnableInputs)
        {
            if (Gflg == false && Dead == false)
            {
                if (gaugeCtrl.fillAmount > 0.0f)
                {
                    if (Input.GetMouseButton(0))
                    {
                        gaugeCtrl.fillAmount -= 0.0005f;
                        flg = 0;
                    }

                    else
                    {
                        // Run����Wait�ɑJ�ڂ���
                        //this.animator.SetBool(key_isRun, false);
                        flg = 1;
                    }
                }
                else if (gaugeCtrl.fillAmount == 0.0f)
                {
                    flg = 1;
                }
                if (flg == 1)
                {
                    // Wait����Run�ɑJ�ڂ���
                    this.animator.SetBool(key_isRun, true);
                    agent.GetComponent<NavMeshAgent>().isStopped = false;
                    agent.SetDestination(GoalLine_PL.transform.position);
                }
                else if (flg == 0)
                {
                    // Run����Wait�ɑJ�ڂ���
                    this.animator.SetBool(key_isRun, false);
                    agent.velocity = Vector3.zero;
                    agent.GetComponent<NavMeshAgent>().isStopped = true;
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