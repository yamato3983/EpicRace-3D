using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    GameObject HP;
    //image�̃R���|�[�l���g
    Image gaugeCtrl;

    // Animator �R���|�[�l���g
    private Animator animator;

    // Animator�̐ݒ肵���t���O�̖��O
    private const string key_isRun = "isRun";

    private float time = 0.0f;

    //���X�|�[���|�C���g���i�[����ϐ�
    public GameObject RP;
    public GameObject RP2;

    //�v���C���[���i�[����ϐ�
    GameObject Player;

    GameObject PB;//���M�~�b�N���i�[����ϐ�
    PivotAngle_Box PB_Script;//PivotAngle_Box������ϐ�

    [SerializeField]
    GameObject GoalLine_PL;	// �ړ��\��n�̃I�u�W�F�N�g

    //public NavMeshAgent agent;

    int flg = 1;      //�i�ނ��~�܂邩�̃t���O

    Vector3 tmp, tmp2;//���X�|�[���|�C���g�̍��W������ϐ�
    public Rigidbody rb;

    public bool Gflg = false;
    public bool Dead = false;
    public bool Cflg = false;

    public GameObject timer;
    public Countdown t1;
    private float timeToEnableInputs;

    //navmesh�Ȃ��ł�邽�߂̕ϐ�
    float speed;

    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();

        //agent.speed = 5.0f;
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
        //tmp2 = RP2.transform.position;

        PB = GameObject.Find("PivotBox");
        PB_Script = PB.GetComponent<PivotAngle_Box>();

        var agentRigidbody = GetComponent<Rigidbody>();
        //Rigidody��Kinematic���X�^�[�g����ON�ɂ���
        agentRigidbody.isKinematic = false;

        speed = 5.0f;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        var agentRigidbody = GetComponent<Rigidbody>();

        if (other.gameObject.tag == "Dead")
        {
            Debug.Log("���񂾁I�I");
            this.gameObject.SetActive(false);
            Player.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
            Dead = true;
            flg = 0;

            //Navmesh��Rigidody��Kinematic��ON
            agentRigidbody.isKinematic = true;
            //agent.enabled = true;
        }

        if (other.gameObject.tag == "Dead_02")
        {
            Debug.Log("���񂾁I�I(��]");
            this.gameObject.SetActive(false);
            Player.transform.position = new Vector3(tmp2.x, tmp2.y, tmp2.z);
            Dead = true;
            flg = 0;


            //Navmesh��Rigidody��Kinematic��ON
            agentRigidbody.isKinematic = true;
            //agent.enabled = true;
        }

        if (other.tag == "Goal")
        {
            //NavMeshAgent agent = GetComponent<NavMeshAgent>();
            //agent.isStopped = true;
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

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Gimmick_Conveyer")
        {
            speed = 3.0f;
        }
        else
        {
            speed = 5.0f;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        var agentRigidbody = GetComponent<Rigidbody>();
        if (collision.gameObject.tag == "Dead")
        {
            Debug.Log("���񂾁I�I1");
            this.gameObject.SetActive(false);
            Player.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
            Dead = true;
            flg = 0;
        }

        if (collision.gameObject.tag == "Dead_02")
        {
            Debug.Log("���񂾁I�I3");
            this.gameObject.SetActive(false);
            Player.transform.position = new Vector3(tmp2.x, tmp2.y, tmp2.z);
            Dead = true;
            flg = 0;
        }
    }

    void Update()
    {
        var agentRigidbody = GetComponent<Rigidbody>();

        if (Time.time >= this.timeToEnableInputs)
        {
            if (Gflg == false && Dead == false)
            {
                if (gaugeCtrl.fillAmount > 0.0f)
                {
                    if (Input.GetMouseButton(0))
                    {
                        //gaugeCtrl.fillAmount -= 0.0013f;
                        gaugeCtrl.fillAmount -= 0.0065f;
                        flg = 0;
                    }

                    else
                    {
                        //gaugeCtrl.fillAmount += 0.0005f;
                        gaugeCtrl.fillAmount += 0.0025f;
                        flg = 1;
                    }
                }
                else if (gaugeCtrl.fillAmount == 0.0f)
                {
                    //gaugeCtrl.fillAmount += 0.0005f;
                    gaugeCtrl.fillAmount += 0.0025f;
                    flg = 1;
                }
                if (flg == 1)
                {
                    // Wait����Run�ɑJ�ڂ���
                    this.animator.SetBool(key_isRun, true);
                    transform.position += transform.forward * speed * Time.deltaTime;
                    
                }
                else if (flg == 0)
                {
                    // Run����Wait�ɑJ�ڂ���
                    this.animator.SetBool(key_isRun, false);
                    //agentRigidbody.velocity = Vector3.zero;
                    //agent.GetComponent<NavMeshAgent>().isStopped = true;
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
