using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*public class CPU_move04 : MonoBehaviour
{
    private CharacterController enemyController;
    private Animator animator;

    //�@�ړI�n
    private Vector3 destination;
    [SerializeField]
    private float walkSpeed = 3.0f;

    [SerializeField]
    private float jumpPower = 5f;

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

    //���W�b�h�{�f�B
    [SerializeField]
    public Rigidbody rb;

    Vector3 pos1, pos2;

    internal State GetState()
    {
        throw new System.NotImplementedException();
    }****/

    /*****���[�v����*****/
    /*public enum State
    {
        normal,
        catchRope,
        releaseRope
    }

    private State state;

    //	���[�v��͂񂾎��̎�l���̊p�x
    private Quaternion preRotation;
    //�@���[�v���i��ł������
    [SerializeField]
    private float xDirection;
    //�@���[�v�̏���̈ʒu�ɓ����Ă��邩�H
    private bool moveFlag = false;
    //�@CatchTheRope�X�N���v�g
    private CatchTheRope rope;
    //�@���[�v�𓮂����X�N���v�g
    private RopeMove moveRope;
    //�@���[�v�̏���̈ʒu�܂ł̃X�s�[�h
    [SerializeField]
    private float speedToRope = 5f;

    //�@IK�̃E�G�C�g
    private float weight = 0f;*/

    /********************/

    /*private bool isRespon = false;

    public bool dead;

    //NPC���S�[�����������ǂ���
    public bool goal;

    // Start is called before the first frame update
    void Start()
    {
        state = State.normal;

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
        //�@�ʏ펞�����ړ���W�����v���o����
        if (state == State.normal)
        {
            if (enemyController.isGrounded)
            {
                velocity = Vector3.zero;
                velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
                Stop();
                Dush();
                direction = (destination - transform.position).normalized;
                transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
                velocity = direction * walkSpeed;
                Debug.Log(destination);

                //�@�W�����v
                if (Input.GetButtonDown("Jump")
                    && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump")
                       && !animator.IsInTransition(0))
                {
                    velocity.y += jumpPower;
                }
            }
        }


        else if (state == State.catchRope)
        {
            if (Input.GetButtonDown("Jump"))
            {
                SetState(State.releaseRope);
            }
            //�@���B�_�Ɉړ������鏈����IK�̃E�G�C�g�̏���
        }

        else if (state == State.releaseRope)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, preRotation, speedToRope * Time.deltaTime);

            //�@���[�v�̓����Ă��鑬�x���擾 releasePower
            Vector3 velocityXZ = (moveRope.transform.right * xDirection * 5);

            //�@Y�������͏d�͂ɔC�����0�ɂ���
            velocityXZ.y = 0f;

            //�@���[�v�𗣂������̃��[�v�������Ă��鑬�x�Əd�͂𑫂��đS�̂̑��x���v�Z
            velocity = velocityXZ + new Vector3(0f, velocity.y, 0f);

            //�@�ړ��l������������ dampingTime
            xDirection = Mathf.Lerp(xDirection, 0f, 5 * Time.deltaTime);

            //�@�d�͂𓭂�����
            velocity.y += Physics.gravity.y * Time.deltaTime;
            enemyController.Move(velocity * Time.deltaTime);

            //�@���n������m�[�}����Ԃɂ���
            if (enemyController.isGrounded)
            {
                //�@��Ƀ��[�v�̃L�����N�^�[��Ԃ��m�[�}����
                SetState(State.normal);
            }
        }
    
         velocity.y += Physics.gravity.y * Time.deltaTime;
         enemyController.Move(velocity * Time.deltaTime);

        dead = false;
    }

    private void Stop()
    {



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
    }***/

    /*********���[�v�֘A************/
    /*public void SetState(State sta, CatchTheRope catchTheRope = null)
    {
        state = sta;
        if (state == State.catchRope)
        {
            //�@���݂̊p�x��ێ����Ă���
            preRotation = transform.rotation;

            animator.SetFloat("Speed", 0f);

            velocity = Vector3.zero;

            //�@�ړ��l���̏�����
            var rot = transform.localEulerAngles.y;

            //�@�p�x��ݒ肵����
            transform.localRotation = Quaternion.Euler(0f, rot, 0f);
            //�@�L�����N�^�[�𓞒B�_�ɓ������t���O�I��
            moveFlag = true;

            SetCatchTheRope(catchTheRope);
        }
        else if (state == State.releaseRope)
        {
            transform.SetParent(null);
            weight = 0f;

            //�@���[�v�𗣂������̌�����ێ�
            if (moveRope.GetDirection() == 1)
            {
                xDirection = 1;
            }
            else
            {
                xDirection = -1;
            }

            //moveRope.SetMoveFlag(false);

        }
        else if (state == State.normal)
        {
            rope = null;
            moveFlag = true;
            transform.rotation = preRotation;
        }
    }

    public void SetCatchTheRope(CatchTheRope rope)
    {
        //�@CatchTheRope��MoveRope�X�N���v�g�̎擾
        this.rope = rope;
        moveRope = this.rope.GetComponent<RopeMove>();
    }*/
    /********************************************/

    /*void OnAnimatorIK()
    {
        //�@���[�v��͂񂾏��
        if (state == State.catchRope)
        {
            //�@�E��A����A�E�Ђ��A���Ђ��̈ʒu�E�G�C�g��ݒ�
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, weight);
            animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, weight);
            animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, weight);

            //�@�E��A����̊p�x�E�G�C�g��ݒ�
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, weight);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, weight);

            //�@�E��A����A�E�Ђ��A���Ђ��̈ʒu��ݒ�
            animator.SetIKPosition(AvatarIKGoal.RightHand, rope.GetRightHand().position);
            animator.SetIKPosition(AvatarIKGoal.LeftHand, rope.GetLeftHand().position);
            animator.SetIKHintPosition(AvatarIKHint.RightElbow, rope.GetRightElbow().position);
            animator.SetIKHintPosition(AvatarIKHint.LeftElbow, rope.GetLeftElbow().position);

            //�@�E��A����̊p�x��ݒ�
            animator.SetIKRotation(AvatarIKGoal.RightHand, rope.GetRightHand().rotation);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, rope.GetLeftHand().rotation);
        }
    }

    //�^�O�̔���
    private void OnTriggerEnter(Collider other)
    {
        //���S�]�[���ɓ��������̏���(�M�~�b�N��1�Ԗ�)
        if (other.tag == "Dead")
        {

            dead = true;
            transform.position = new Vector3(pos1.x, pos1.y, pos1.z);

        }

        if (other.tag == "Dead2")
        {
            dead = true;
            transform.position = new Vector3(pos2.x, pos2.y, pos2.z);

        }

        if (other.tag == "Goal")
        {
            animator.SetFloat("Speed", 0.0f);
        }

        rb = GetComponent<Rigidbody>();
        if (other.tag == "jump")
        {
            Debug.Log("�W�����v");

            rb.isKinematic = false;
            //�W�����v�����
            Vector3 force = new Vector3(0.0f, 20f, 5f);

            rb.AddForce(force, ForceMode.Impulse);
        }
    }

    //�^�O�����蔲������W�����v
    private void OnTriggerStay(Collider other)
    {
        rb = GetComponent<Rigidbody>();
        //if (other.tag != "jump")
        //{
            //rb.isKinematic = true;
        //}
    }
}*/
