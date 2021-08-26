using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*public class CPU_move04 : MonoBehaviour
{
    private CharacterController enemyController;
    private Animator animator;

    //　目的地
    private Vector3 destination;
    [SerializeField]
    private float walkSpeed = 3.0f;

    [SerializeField]
    private float jumpPower = 5f;

    //　速度
    private Vector3 velocity;
    //　移動方向
    private Vector3 direction;

    //カウントダウン用
    GameObject GemeObject;
    public Countdown script_t1;

    public GameObject Enemy;

    //リスポーン
    public GameObject rp1;
    public GameObject rp2;

    //リジッドボディ
    [SerializeField]
    public Rigidbody rb;

    Vector3 pos1, pos2;

    internal State GetState()
    {
        throw new System.NotImplementedException();
    }****/

    /*****ロープ処理*****/
    /*public enum State
    {
        normal,
        catchRope,
        releaseRope
    }

    private State state;

    //	ロープを掴んだ時の主人公の角度
    private Quaternion preRotation;
    //　ロープが進んでいる向き
    [SerializeField]
    private float xDirection;
    //　ロープの所定の位置に動いているか？
    private bool moveFlag = false;
    //　CatchTheRopeスクリプト
    private CatchTheRope rope;
    //　ロープを動かすスクリプト
    private RopeMove moveRope;
    //　ロープの所定の位置までのスピード
    [SerializeField]
    private float speedToRope = 5f;

    //　IKのウエイト
    private float weight = 0f;*/

    /********************/

    /*private bool isRespon = false;

    public bool dead;

    //NPCがゴールをしたかどうか
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

        //リスポーン
        rp1 = GameObject.Find("RespawnCPU");
        rp2 = GameObject.Find("RespawnCPU2");
        pos1 = rp1.transform.position;
        pos2 = rp2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //　通常時だけ移動やジャンプが出来る
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

                //　ジャンプ
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
            //　到達点に移動させる処理やIKのウエイトの処理
        }

        else if (state == State.releaseRope)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, preRotation, speedToRope * Time.deltaTime);

            //　ロープの動いている速度を取得 releasePower
            Vector3 velocityXZ = (moveRope.transform.right * xDirection * 5);

            //　Y軸方向は重力に任せる為0にする
            velocityXZ.y = 0f;

            //　ロープを離した時のロープが動いている速度と重力を足して全体の速度を計算
            velocity = velocityXZ + new Vector3(0f, velocity.y, 0f);

            //　移動値を減少させる dampingTime
            xDirection = Mathf.Lerp(xDirection, 0f, 5 * Time.deltaTime);

            //　重力を働かせる
            velocity.y += Physics.gravity.y * Time.deltaTime;
            enemyController.Move(velocity * Time.deltaTime);

            //　着地したらノーマル状態にする
            if (enemyController.isGrounded)
            {
                //　先にロープのキャラクター状態をノーマルに
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
        //カウントダウン中はストップしてる
        if (script_t1.startflg == false)
        {
            animator.SetFloat("Speed", 0.0f);
        }

        //とりあえず4秒にしてるけど変更するかも
        yield return new WaitForSeconds(3.0f);

        //カウントダウンが0のときに走り出す
        if (script_t1.startflg == true)
        {
            animator.SetFloat("Speed", 5.0f);
        }
    }***/

    /*********ロープ関連************/
    /*public void SetState(State sta, CatchTheRope catchTheRope = null)
    {
        state = sta;
        if (state == State.catchRope)
        {
            //　現在の角度を保持しておく
            preRotation = transform.rotation;

            animator.SetFloat("Speed", 0f);

            velocity = Vector3.zero;

            //　移動値等の初期化
            var rot = transform.localEulerAngles.y;

            //　角度を設定し直す
            transform.localRotation = Quaternion.Euler(0f, rot, 0f);
            //　キャラクターを到達点に動かすフラグオン
            moveFlag = true;

            SetCatchTheRope(catchTheRope);
        }
        else if (state == State.releaseRope)
        {
            transform.SetParent(null);
            weight = 0f;

            //　ロープを離した時の向きを保持
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
        //　CatchTheRopeとMoveRopeスクリプトの取得
        this.rope = rope;
        moveRope = this.rope.GetComponent<RopeMove>();
    }*/
    /********************************************/

    /*void OnAnimatorIK()
    {
        //　ロープを掴んだ状態
        if (state == State.catchRope)
        {
            //　右手、左手、右ひじ、左ひじの位置ウエイトを設定
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, weight);
            animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, weight);
            animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, weight);

            //　右手、左手の角度ウエイトを設定
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, weight);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, weight);

            //　右手、左手、右ひじ、左ひじの位置を設定
            animator.SetIKPosition(AvatarIKGoal.RightHand, rope.GetRightHand().position);
            animator.SetIKPosition(AvatarIKGoal.LeftHand, rope.GetLeftHand().position);
            animator.SetIKHintPosition(AvatarIKHint.RightElbow, rope.GetRightElbow().position);
            animator.SetIKHintPosition(AvatarIKHint.LeftElbow, rope.GetLeftElbow().position);

            //　右手、左手の角度を設定
            animator.SetIKRotation(AvatarIKGoal.RightHand, rope.GetRightHand().rotation);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, rope.GetLeftHand().rotation);
        }
    }

    //タグの判定
    private void OnTriggerEnter(Collider other)
    {
        //死亡ゾーンに入った時の処理(ギミックの1番目)
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
            Debug.Log("ジャンプ");

            rb.isKinematic = false;
            //ジャンプする力
            Vector3 force = new Vector3(0.0f, 20f, 5f);

            rb.AddForce(force, ForceMode.Impulse);
        }
    }

    //タグがすり抜けたらジャンプ
    private void OnTriggerStay(Collider other)
    {
        rb = GetComponent<Rigidbody>();
        //if (other.tag != "jump")
        //{
            //rb.isKinematic = true;
        //}
    }
}*/
