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

	//�@CatchTheRope�X�N���v�g
	private CatchTheRope rope;
	//�@���[�v�𓮂����X�N���v�g
	private RopeMove moveRope;

	//	���[�v��͂񂾎��̎�l���̊p�x
	private Quaternion preRotation;

	//�@���[�v�̏���̈ʒu�܂ł̃X�s�[�h

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

		//�@�L�����N�^�[�R���C�_���ڒn
		if (cCon.isGrounded)
		{
			//�@�n�ʂɐڒn���Ă鎞�͏�����
			velocity = Vector3.zero;

			input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

			//�@�����L�[������������Ă���
			if (input.magnitude > 0f)
			{
				animator.SetFloat("Speed", input.magnitude);
				transform.LookAt(transform.position + input);
				velocity += input * walkSpeed;
				//�@�L�[�̉���������������ꍇ�͈ړ����Ȃ�
			}
			else
			{
				animator.SetFloat("Speed", 0);
			}

			//�@�W�����v
			if (Input.GetButtonDown("Jump")
				&& !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump")
				   && !animator.IsInTransition(0))
			{
				velocity.y += jumpPower;
			}
		}

		//�@�ʏ펞�����ړ���W�����v���o����
		if (state == State.normal)
		{
			//�@�L�����N�^�[�R���C�_���ڒn�A�܂��̓��C���n�ʂɓ��B���Ă���ꍇ
			if (cCon.isGrounded)
			{
				//�L�����N�^�[�̈ړ���W�����v���̏���
			}
		}
		else if (state == State.catchRope)
		{
			if (moveFlag)
			{
				if (transform.localPosition != rope.GetArrivalPoint())
				{
					//�@���炩�Ɍ��߂�ꂽ�ʒu�Ɉړ�������
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
	}

	public void SetCatchTheRope(CatchTheRope rope)
	{
		//�@CatchTheRope��MoveRope�X�N���v�g�̎擾
		this.rope = rope;
		moveRope = this.rope.GetComponent<RopeMove>();
	}

}