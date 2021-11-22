using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;


public class PlayerController5 : MonoBehaviour
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
    //public NavMeshAgent agent;
    int flg = 1;      //�i�ނ��~�܂邩�̃t���O

    Vector3 tmp, tmp2;//���X�|�[���|�C���g�̍��W������ϐ�
    public Rigidbody rb;

    public bool Gflg = false;
    public bool Dead = false;
    public bool Cflg = false;

    private float timeToEnableInputs;

    float speed;

    Rigidbody[] ragdollRigidbodies;

    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();

        speed = 7.0f;
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
        tmp = RP.transform.position;
        tmp2 = RP2.transform.position;

        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        
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

        if (collision.gameObject.tag == "Roller")
        {
            Debug.Log("���񂾁I�I1");
            this.gameObject.SetActive(false);
            Player.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
            Dead = true;
            flg = 0;
        }
        if (collision.gameObject.tag == "BlockBar")
        {
            Debug.Log("Hit BlockBar");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var agentRigidbody = GetComponent<Rigidbody>();

        if (other.gameObject.tag == "Dead")
        {
            Debug.Log("���񂾁I");
            this.gameObject.SetActive(false);
            Player.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
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
            tmp = tmp2;
        }

        if (other.gameObject.tag == "jump")
        {
            Debug.Log("jump�ɐG�ꂽ");
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

                        //gaugeCtrl.fillAmount -= 0.0065f;
                        flg = 0;
                    }

                    else
                    {
                        //�}�E�X��������Ă��Ȃ��Ƃ��̓Q�[�W�̉�
                        gaugeCtrl.fillAmount += 0.0005f;
                        // Run����Wait�ɑJ�ڂ���
                        flg = 1;
                    }
                }
                else if (gaugeCtrl.fillAmount == 0.0f)
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
                    //agent.GetComponent<NavMeshAgent>().isStopped = false;
                    //agent.SetDestination(GoalLine_PL.transform.position);
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
