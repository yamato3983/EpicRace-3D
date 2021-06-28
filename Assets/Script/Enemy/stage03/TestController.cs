using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestController : MonoBehaviour
{

    //�@�A�j���[�^�R���g���[��
    private Animator animator;
    //�@���C���΂�����
    private float rayRange;
    //�@�ړ�����ʒu
    private Vector3 targetPosition;
    //�@�}�E�X�N���b�N�ňʒu�����߂邩
    [SerializeField]
    private bool isMouseDownMode;
    //�@�i�r�Q�[�V�����G�[�W�F���g
    private UnityEngine.AI.NavMeshAgent agent;
    //�@�Đ��b��
    private float normalizedTime = 0f;
    //�@�I�t���b�V�������N���W�����v�����ǂ���
    private bool useLinkJump = false;
    //�@�����N�W�����v����Y���W�̒l
    private float offsetY;
    //�@�W�����v�A�j���[�V�����J�[�u
    [SerializeField]
    private AnimationCurve animCurve;
    //�@�W�����v�A�j���[�V�����̍Đ�����
    private float animationTime;
    //�@�I�t���b�V�������N�f�[�^
    private UnityEngine.AI.OffMeshLinkData offMeshLinkData;
    //�@�I�t���b�V�������N�̃X�^�[�g�ʒu
    private Vector3 startPos;
    //�@�I�t���b�V�������N�̃G���h�ʒu
    private Vector3 endPos;

    void Start()
    {
        animator = GetComponent<Animator>();
        rayRange = 1000f;
        targetPosition = transform.position;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoTraverseOffMeshLink = false;

        // LinkJump��Ԃɐݒ肵���A�j���[�V�����N���b�v������A�j���[�V�����̒������擾
        foreach (var item in animator.runtimeAnimatorController.animationClips)
        {
            if (item.name == "LinkJump4")
            {
                animationTime = item.length;
            }
        }
    }

    void Update()
    {
        //�@�}�E�X�N���b�N�܂���mouseDownMode��Off�̎��}�E�X�̈ʒu���ړ�����ʒu�ɂ���
        if (Input.GetButtonDown("Fire1") || !isMouseDownMode)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayRange, LayerMask.GetMask("Field")))
            {
                targetPosition = hit.point;
                agent.SetDestination(targetPosition);
            }
        }
        //�@�I�t���b�V�������N���g�p��
        if (agent.isOnOffMeshLink)
        {

            if (!useLinkJump)
            {
                //�@�G�[�W�F���g�̌��݂̃I�t���b�V�������N�f�[�^���擾
                offMeshLinkData = agent.currentOffMeshLinkData;
                //�@�I�t���b�V�������N�̃X�^�[�g�ʒu
                startPos = offMeshLinkData.startPos;
                //�@�I�t���b�V�������N�̃G���h�ʒu
                endPos = offMeshLinkData.endPos;

                //�@�I�t���b�V�������N�̃^�C�v���W�����v���Ĕ�ԃ^�C�v�̎��W�����v�A�j���[�V�����Đ�
                if (offMeshLinkData.linkType == UnityEngine.AI.OffMeshLinkType.LinkTypeJumpAcross || offMeshLinkData.linkType == UnityEngine.AI.OffMeshLinkType.LinkTypeManual)
                {
                    animator.SetBool("LinkJump", true);
                }
                useLinkJump = true;

                normalizedTime = 0f;
            }

            //�@�I�t���b�V�������N���g�p�������͔�Ԑ�̕�������������
            transform.LookAt(new Vector3(endPos.x, transform.position.y, endPos.z));

            normalizedTime += Time.deltaTime;
            //�@�A�j���[�V�����J�[�u�̉�������c�����擾
            offsetY = animCurve.Evaluate(normalizedTime * (1f / animationTime));

            //�@�A�j���[�V�����I�����ɃW�����v�I��
            if (normalizedTime * (1f / animationTime) >= 1f)
            {
                agent.CompleteOffMeshLink();
                useLinkJump = false;
                animator.SetBool("LinkJump", false);
            }

            //�@�G�[�W�F���g�̈ʒu���Z�b�g
            agent.transform.position = Vector3.Lerp(startPos, endPos, normalizedTime * (1f / animationTime)) + offsetY * Vector3.up;
        }
        else
        {
            //�@�I�t���b�V�������N�̃G���h�ʒu�ɒ�������I�t���b�V�������N�ړ�������
            if (useLinkJump)
            {
                agent.CompleteOffMeshLink();
                useLinkJump = false;
                animator.SetBool("LinkJump", false);
            }
            else
            {
                //�@�ړI�n�ɋߕt�����瑖��A�j���[�V��������߂�
                if (agent.remainingDistance < 0.1f)
                {
                    animator.SetFloat("Speed", 0f);
                }
                else
                {
                    animator.SetFloat("Speed", agent.desiredVelocity.magnitude);
                }
            }
        }
    }
}
