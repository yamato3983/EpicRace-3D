using UnityEngine;
using System.Collections;

public class JumpToRopeChara : MonoBehaviour
{
	public enum State
	{
		normal,
		catchRope,
	}

	private State state;

	private Animator animator;
	private CharacterController cCon;
	private Vector3 velocity;
	[SerializeField]
	private float jumpPower = 5f;

    private Vector3 input;
	[SerializeField]
	private float walkSpeed = 2f;

	private bool moveFlag = false;

	//　CatchTheRopeスクリプト
	private CatchTheRope rope;
	//　ロープを動かすスクリプト
	private RopeMove moveRope;

	//	ロープを掴んだ時の主人公の角度
	private Quaternion preRotation;

	//　ロープの所定の位置までのスピード

	[SerializeField]
	private float speedToRope = 5f;

	void Start()
	{
		animator = GetComponent<Animator>();
		cCon = GetComponent<CharacterController>();
		velocity = Vector3.zero;
		state = State.normal;
	}

	void Update()
	{

		//　キャラクターコライダが接地
		if (cCon.isGrounded)
		{
			//　地面に接地してる時は初期化
			velocity = Vector3.zero;

			input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

			//　方向キーが多少押されている
			if (input.magnitude > 0f)
			{
				animator.SetFloat("Speed", input.magnitude);
				transform.LookAt(transform.position + input);
				velocity += input * walkSpeed;
				//　キーの押しが小さすぎる場合は移動しない
			}
			else
			{
				animator.SetFloat("Speed", 0);
			}

			//　ジャンプ
			if (Input.GetButtonDown("Jump")
				&& !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump")
				   && !animator.IsInTransition(0))
			{
				velocity.y += jumpPower;
			}
		}

		//　通常時だけ移動やジャンプが出来る
		if (state == State.normal)
		{
			//　キャラクターコライダが接地、またはレイが地面に到達している場合
			if (cCon.isGrounded)
			{
				//キャラクターの移動やジャンプ等の処理
			}
		}
		else if (state == State.catchRope)
		{
			if (moveFlag)
			{
				if (transform.localPosition != rope.GetArrivalPoint())
				{
					//　滑らかに決められた位置に移動させる
					transform.localPosition = Vector3.Lerp(transform.localPosition, rope.GetArrivalPoint(), speedToRope * Time.deltaTime);
				}
				else
				{
					moveFlag = false;
				}
			}
		}

		velocity.y += Physics.gravity.y * Time.deltaTime;
		cCon.Move(velocity * Time.deltaTime);

	}

	public void SetState(State sta, CatchTheRope catchTheRope = null)
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
	}

	public void SetCatchTheRope(CatchTheRope rope)
	{
		//　CatchTheRopeとMoveRopeスクリプトの取得
		this.rope = rope;
		moveRope = this.rope.GetComponent<RopeMove>();
	}

}