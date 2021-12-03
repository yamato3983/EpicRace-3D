using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;
[RequireComponent(typeof(Animator))]

public class PlayerController4 : MonoBehaviour
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
    public GameObject RP3;

    GameObject Player;

    [SerializeField]
    GameObject GoalLine_PL;	// �ړ��\��n�̃I�u�W�F�N�g
    
    int flg = 1;      //�i�ނ��~�܂邩�̃t���O

    Vector3 tmp, tmp2, tmp3;//���X�|�[���|�C���g�̍��W������ϐ�
    public Rigidbody rb;

    public bool Gflg = false;
    public bool Dead = false;
    public bool Cflg = false;
    public bool Rag =false;

    public GameObject timer;
    public Countdown t1;
    private float timeToEnableInputs;

    float speed;

    Rigidbody[] ragdollRigidbodies;

    void Start()
    {
        speed = 7.0f;
        HP = GameObject.Find("HP");
        gaugeCtrl = HP.GetComponent<Image>();
        gaugeCtrl.fillAmount = 1.0f;

        //�J�����̃t���O�����̓��C���̈�false
        Cflg = true;

        Player = GameObject.Find("unitychan");

        this.timeToEnableInputs = Time.time + 3.0f;

        // �����ɐݒ肳��Ă���Animator�R���|�[�l���g���K������
        this.animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        //���X�|�[����|�C���g�̃f�[�^���󂯎��
        RP = GameObject.Find("RespawnPoint");
        RP2 = GameObject.Find("RespawnPoint2");
        RP3 = GameObject.Find("RespawnPoint3");
        tmp = RP.transform.position;
        tmp2 = RP2.transform.position;
        tmp3 = RP3.transform.position;

        var agentRigidbody = GetComponent<Rigidbody>();
        //Rigidody��Kinematic���X�^�[�g����OFF�ɂ���
        agentRigidbody.isKinematic = false;

        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        SetRagdoll(false);
    }

    void SetRagdoll(bool isEnabled)
    {
        foreach (Rigidbody rigidbody in ragdollRigidbodies)
        {
            //rigidbody.isKinematic = !isEnabled;
            animator.enabled = !isEnabled;
        }
    }
    private IEnumerator Test()
    {
        Rag = true;
        SetRagdoll(true);
        yield return new WaitForSeconds(1.0f);
        SetRagdoll(false);
        animator.enabled = true;
        this.gameObject.SetActive(false);
        Player.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
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
            SetRagdoll(false);
        }
        
        if (collision.gameObject.tag == "Dead_02")
        {
            Debug.Log("���񂾁I�I3");
            this.gameObject.SetActive(false);
            Player.transform.position = new Vector3(tmp3.x, tmp3.y, tmp3.z);
            Dead = true;
            flg = 0;
        }

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

        }
        if (other.gameObject.tag == "Hammer")
        {
            Debug.Log("���񂾁I�IHammer");
            StartCoroutine(Test());
        }

        if (other.gameObject.tag == "Dead_02")
        {
            Debug.Log("���񂾁I�I(��]");
            this.gameObject.SetActive(false);
            Player.transform.position = new Vector3(tmp2.x, tmp2.y, tmp2.z);
            Dead = true;
            flg = 0;
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
                    if (Rag == true)
                    {
                        flg = 0;
                    }
                }
                else if (gaugeCtrl.fillAmount <= 0.0f)
                {
                    //�}�E�X��������Ă��Ȃ��Ƃ��̓Q�[�W�̉�
                    //gaugeCtrl.fillAmount += 0.0005f;
                    gaugeCtrl.fillAmount += 0.0025f;
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
