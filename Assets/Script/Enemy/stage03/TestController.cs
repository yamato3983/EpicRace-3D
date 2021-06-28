using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestController : MonoBehaviour
{

    //　アニメータコントローラ
    private Animator animator;
    //　レイを飛ばす距離
    private float rayRange;
    //　移動する位置
    private Vector3 targetPosition;
    //　マウスクリックで位置を決めるか
    [SerializeField]
    private bool isMouseDownMode;
    //　ナビゲーションエージェント
    private UnityEngine.AI.NavMeshAgent agent;
    //　再生秒数
    private float normalizedTime = 0f;
    //　オフメッシュリンクをジャンプ中かどうか
    private bool useLinkJump = false;
    //　リンクジャンプ中のY座標の値
    private float offsetY;
    //　ジャンプアニメーションカーブ
    [SerializeField]
    private AnimationCurve animCurve;
    //　ジャンプアニメーションの再生時間
    private float animationTime;
    //　オフメッシュリンクデータ
    private UnityEngine.AI.OffMeshLinkData offMeshLinkData;
    //　オフメッシュリンクのスタート位置
    private Vector3 startPos;
    //　オフメッシュリンクのエンド位置
    private Vector3 endPos;

    void Start()
    {
        animator = GetComponent<Animator>();
        rayRange = 1000f;
        targetPosition = transform.position;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoTraverseOffMeshLink = false;

        // LinkJump状態に設定したアニメーションクリップ名からアニメーションの長さを取得
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
        //　マウスクリックまたはmouseDownModeがOffの時マウスの位置を移動する位置にする
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
        //　オフメッシュリンクを使用中
        if (agent.isOnOffMeshLink)
        {

            if (!useLinkJump)
            {
                //　エージェントの現在のオフメッシュリンクデータを取得
                offMeshLinkData = agent.currentOffMeshLinkData;
                //　オフメッシュリンクのスタート位置
                startPos = offMeshLinkData.startPos;
                //　オフメッシュリンクのエンド位置
                endPos = offMeshLinkData.endPos;

                //　オフメッシュリンクのタイプがジャンプして飛ぶタイプの時ジャンプアニメーション再生
                if (offMeshLinkData.linkType == UnityEngine.AI.OffMeshLinkType.LinkTypeJumpAcross || offMeshLinkData.linkType == UnityEngine.AI.OffMeshLinkType.LinkTypeManual)
                {
                    animator.SetBool("LinkJump", true);
                }
                useLinkJump = true;

                normalizedTime = 0f;
            }

            //　オフメッシュリンクを使用した時は飛ぶ先の方向を向かせる
            transform.LookAt(new Vector3(endPos.x, transform.position.y, endPos.z));

            normalizedTime += Time.deltaTime;
            //　アニメーションカーブの横軸から縦軸を取得
            offsetY = animCurve.Evaluate(normalizedTime * (1f / animationTime));

            //　アニメーション終了時にジャンプ終了
            if (normalizedTime * (1f / animationTime) >= 1f)
            {
                agent.CompleteOffMeshLink();
                useLinkJump = false;
                animator.SetBool("LinkJump", false);
            }

            //　エージェントの位置をセット
            agent.transform.position = Vector3.Lerp(startPos, endPos, normalizedTime * (1f / animationTime)) + offsetY * Vector3.up;
        }
        else
        {
            //　オフメッシュリンクのエンド位置に着いたらオフメッシュリンク移動が完了
            if (useLinkJump)
            {
                agent.CompleteOffMeshLink();
                useLinkJump = false;
                animator.SetBool("LinkJump", false);
            }
            else
            {
                //　目的地に近付いたら走るアニメーションをやめる
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
