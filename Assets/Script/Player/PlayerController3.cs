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

    [SerializeField]
    private float m_jumpTime = 0.0f;

    [SerializeField]
    private Transform jumpPoint = null;

    [SerializeField]
    private Transform j_target = null;

    public bool j_flg;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = 5.0f;
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

        j_flg = false;

        var agentRigidbody = agent.GetComponent<Rigidbody>();
        //Rigidody��Kinematic���X�^�[�g����ON�ɂ���
        agentRigidbody.isKinematic = true;
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

        if (other.gameObject.tag == "Hammer")
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

    private void OnTriggerStay(Collider other)
    {
        //if (other.tag == "jump")
        //{
        //    agent.autoTraverseOffMeshLink = false;
        //    agent.isStopped = true;

        //    Debug.Log("�W�����v");

        //    rb.isKinematic = false;

        //    Jump(j_target.position);
        //    j_flg = true;
        //}
    }

    private void Jump(Vector3 i_targetPos)
    {
        ShootFixedTime(i_targetPos, m_jumpTime);
    }

    private void ShootFixedTime(Vector3 i_targetPosition, float i_time)
    {
        float speedVec = ComputeVectorFromTime(i_targetPosition, i_time);
        float angle = ComputeAngleFromTime(i_targetPosition, i_time);

        if (speedVec <= 0.0f)
        {
            // ���̈ʒu�ɒ��n�����邱�Ƃ͕s�\�̂悤���I
            Debug.LogWarning("!!");
            return;
        }

        Vector3 vec = ConvertVectorToVector3(speedVec, angle, i_targetPosition);
        SetRigidbody(vec);
    }

    private Vector3 ConvertVectorToVector3(float i_v0, float i_angle, Vector3 i_targetPosition)
    {
        Vector3 startPos = transform.position;
        Vector3 targetPos = i_targetPosition;
        startPos.y = 0.0f;
        targetPos.y = 0.0f;

        Vector3 dir = (targetPos - startPos).normalized;
        Quaternion yawRot = Quaternion.FromToRotation(Vector3.right, dir);
        Vector3 vec = i_v0 * Vector3.right;

        vec = yawRot * Quaternion.AngleAxis(i_angle, Vector3.forward) * vec;

        return vec;
    }

    private float ComputeVectorFromTime(Vector3 i_targetPosition, float i_time)
    {
        Vector2 vec = ComputeVectorXYFromTime(i_targetPosition, i_time);

        float v_x = vec.x;
        float v_y = vec.y;

        float v0Square = v_x * v_x + v_y * v_y;
        // �����𕽕����v�Z����Ƌ����ɂȂ��Ă��܂��B

        if (v0Square <= 0.0f)
        {
            return 0.0f;
        }

        float v0 = Mathf.Sqrt(v0Square);

        return v0;
    }

    private float ComputeAngleFromTime(Vector3 i_targetPosition, float i_time)
    {
        Vector2 vec = ComputeVectorXYFromTime(i_targetPosition, i_time);

        float v_x = vec.x;
        float v_y = vec.y;

        float rad = Mathf.Atan2(v_y, v_x);
        float angle = rad * Mathf.Rad2Deg;

        return angle;
    }

    private Vector2 ComputeVectorXYFromTime(Vector3 i_targetPosition, float i_time)
    {
        // �u�Ԉړ��͂�����Ɓc�c�B
        if (i_time <= 0.0f)
        {
            return Vector2.zero;
        }


        // xz���ʂ̋������v�Z�B
        Vector2 startPos = new Vector2(transform.position.x, transform.position.z);
        Vector2 targetPos = new Vector2(i_targetPosition.x, i_targetPosition.z);
        float distance = Vector2.Distance(targetPos, startPos);

        float x = distance;

        float g = -Physics.gravity.y;
        float y0 = transform.position.y;
        float y = i_targetPosition.y;
        float t = i_time;

        float v_x = x / t;
        float v_y = (y - y0) / t + (g * t) / 2;

        return new Vector2(v_x, v_y);
    }

    private void SetRigidbody(Vector3 i_shootVector)
    {
        // �����x�N�g���̂܂�AddForce()��n���Ă͂����Ȃ����B��(�����~�d��)�ɕϊ������
        Vector3 force = new Vector3(0.0f, 0.56f, 0.18f);  //�^�����;

        rb.AddForce(force, ForceMode.Impulse);
    }

    void Update()
    {
        var agentRigidbody = agent.GetComponent<Rigidbody>();

        if (Time.time >= this.timeToEnableInputs)
        {
            if (Gflg == false && Dead == false && j_flg == false)
            {
                if (gaugeCtrl.fillAmount > 0.0f)
                {
                    if (Input.GetMouseButton(0))
                    {
                        gaugeCtrl.fillAmount -= 0.0013f;
                        flg = 0;
                    }

                    else
                    {
                        gaugeCtrl.fillAmount += 0.0005f;
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


            /*
            //�@�I�t���b�V�������N�g�p���Ɏ����ňړ��𐧌�
            if (agent.isOnOffMeshLink)
            {
                isUseOffmeshLink = true;
                agent.isKinematic = false;
                agent.isStopped = true;
                OffMeshLinkProcess(JumpPos);
            }
            */

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