using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class move09 : MonoBehaviour
{
    //private CharacterController enemyController;
    //private Animator animator;

    public GameObject target;
    public GameObject target2;
    public GameObject target3;
    [SerializeField] float speed;

    //�@�ړI�n
    //private Vector3 destination;
    //[SerializeField]
    //private float walkSpeed = 7f;
    //�@���x
    private Vector3 velocity;
    //�@�ړ�����
    private Vector3 direction;

    //�J�E���g�_�E���p
    GameObject GemeObject;
    public Countdown script_t1;

    // ���g��Transform
    [SerializeField] private Transform Boat_CPU;
    //public GameObject Boat_CPU;

    //���X�|�[��
    //public GameObject rp1;
   // public GameObject rp2;

    //Vector3 pos1, pos2;

    private bool isRespon = false;

    public bool dead;

    //NPC���S�[�����������ǂ���
    public bool goal;

    private bool conflag;

    private bool juage;

    private bool juage2;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 tmp = GameObject.Find("GoalLine_CPU").transform.position;
       // GameObject.Find("GoalLine_CPU").transform.position = new Vector3(tmp.x, tmp.y, tmp.z);

       // enemyController = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
        //destination = new Vector3(tmp.x, tmp.y, tmp.z);
        //velocity = Vector3.zero;

        //���X�|�[��
        //rp1 = GameObject.Find("RespawnCPU");
        //rp2 = GameObject.Find("RespawnCPU2");

        //pos1 = rp1.transform.position;
       // pos2 = rp2.transform.position;

        juage = false;
        juage2 = false;
        //���S�t���O
        dead = false;

        Boat_CPU.Rotate(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        //�����̈ʒu�A�^�[�Q�b�g�A���x
        if (juage == false && juage2 == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
        if (juage == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, speed);
        }

        if (juage2 == true && juage == false)
        {
            juage = false;
            Boat_CPU.position = Vector3.MoveTowards(transform.position, target3.transform.position, speed);
        }
        // velocity.y += Physics.gravity.y * Time.deltaTime;
        //enemyController.Move(velocity * Time.deltaTime);

    }

    private IEnumerator Dush()
    {
        //�J�E���g�_�E�����̓X�g�b�v���Ă�
        if (script_t1.startflg == false)
        {
            //animator.SetFloat("Speed", 0.0f);
        }

        //�Ƃ肠����4�b�ɂ��Ă邯�ǕύX���邩��
        yield return new WaitForSeconds(2.0f);

        //�J�E���g�_�E����0�̂Ƃ��ɑ���o��
        if (script_t1.startflg == true)
        {
            //animator.SetFloat("Speed", 1.0f);
        }

        //if (walkSpeed == 0)
        //{
            //animator.SetFloat("Speed", 0.0f);
        //}
    }

    //�^�O�̔���
    private void OnTriggerEnter(Collider other)
    {

        //1�Ԗڂ̖ړI�n
        if (other.tag == "judge")
        {
            juage = true;
            Boat_CPU.Rotate(new Vector3(0, 90, 0));
        }

        //2�Ԗڂ̖ړI�n
        if (other.tag == "judge2")
        {
            Boat_CPU.Rotate(new Vector3(0, 270, 0));
            juage2 = true;
            juage = false;
        }



        /*//2�Ԗڂ̃M�~�b�N
        if (other.tag == "judge2")
        {
            walkSpeed = 0;
            //2�b���Call�֐������s����
            Invoke("Call", 1.1f);

        }

        if (other.tag == "judge3")
        {
            //4�p�^�[���̏���(0�`4)
            int value = Random.Range(0, 3);
            switch (value)
            {
                //�~�߂�
                case 0:

                    walkSpeed = 0;
                    //2�b���Call�֐������s����
                    Invoke("Call", 1.0f);

                    break;

                case 1:

                    walkSpeed = 0;
                    Invoke("Call", 2.0f);

                    break;

                case 2:

                    walkSpeed = 7;
                    break;
            }
        }

        if (other.tag == "judge4")
        {
            int value = Random.Range(0, 3);
            switch (value)
            {
                //�~�߂�
                case 0:

                    walkSpeed = 0;
                    //2�b���Call�֐������s����
                    Invoke("Call", 1.0f);

                    break;

                case 1:

                    walkSpeed = 0;
                    Invoke("Call", 2.0f);

                    break;

                case 2:

                    walkSpeed = 7;
                    break;
            }
        }

        //���S�]�[���ɓ��������̏���(�M�~�b�N��1�Ԗ�)
        if (other.tag == "Yokoari")
        {
            dead = true;
            Enemy.SetActive(false);
            Invoke("CallRespawn1", 0.9f);
        }
        else
        {
            dead = false;
        }

        if (other.tag == "Goal")
        {
            goal = true;
            walkSpeed = 0f;
        }*/
    }


    //���b�ォ�ɌĂяo�����߂̏���
    void Call()
    {
        //�����o��
       // walkSpeed = 7;
    }

    void CallRespawn1()
    {
        //Enemy.SetActive(true);
        //transform.position = new Vector3(pos1.x, pos1.y, pos1.z);
    }

    void CallRespawn2()
    {
        //Enemy.SetActive(true);
        //transform.position = new Vector3(pos2.x, pos2.y, pos2.z);
    }

    public void Speed()
    {
       // walkSpeed = 7;
    }
}
