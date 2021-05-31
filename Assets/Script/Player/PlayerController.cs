using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
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
    int flg = 0;      //�i�ނ��~�܂邩�̃t���O
    Vector3 tmp,tmp2;//���X�|�[���|�C���g�̍��W������ϐ�
    public Rigidbody rb;

    public bool Dead = false;

    //[SerializeField] NavMeshAgent nav_mesh_agent;
    //public bool Dead = false;


    void Start()
    {
        Player = GameObject.Find("unitychan");

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

        agent = GetComponent<NavMeshAgent>();

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

            //Navmesh��Rigidody��Kinematic��ON
            agentRigidbody.isKinematic = true;
            agent.enabled = true;
        }

        if (other.tag == "Goal")
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.isStopped = true;
            Debug.Log("�S�[�[�[��");
        }
    }

    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Wait����Run�ɑJ�ڂ���
            this.animator.SetBool(key_isRun, true);
            flg = 1;
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            // Run����Wait�ɑJ�ڂ���
            this.animator.SetBool(key_isRun, false);
            flg = 0;
        }

        if (flg == 1)
        {
            agent.GetComponent<NavMeshAgent>().isStopped = false;
            agent.SetDestination(GoalLine_PL.transform.position);
        }
        else if (flg == 0)
        {
            agent.GetComponent<NavMeshAgent>().isStopped = true;
        }

        if (Player == null)
        {

        }

    }
}