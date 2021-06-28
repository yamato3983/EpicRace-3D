using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class ObjectController : MonoBehaviour
{
    [SerializeField]
    private Transform[] m_targets = null;
    [SerializeField]
    private float m_destinationThreshold = 0.0f;

    protected NavMeshAgent m_navAgent = null;

    private int m_targetIndex = 0;

    private Vector3 CurretTargetPosition
    {
        get
        {
            if (m_targets == null || m_targets.Length <= m_targetIndex)
            {
                return Vector3.zero;
            }

            return m_targets[m_targetIndex].position;
        }
    }

    protected virtual void Start()
    {
        m_navAgent = GetComponent<NavMeshAgent>();
        m_navAgent.destination = CurretTargetPosition;

        StartCoroutine(UpdateOffMeshLink());
    }

    private void Update()
    {
        if (m_navAgent.remainingDistance <= m_destinationThreshold)
        {
            m_targetIndex = (m_targetIndex + 1) % m_targets.Length;

            m_navAgent.destination = CurretTargetPosition;
        }
    }

    private IEnumerator UpdateOffMeshLink()
    {
        // �I�t���b�V�������N�̋������������[�h�̏ꍇ�́A���̏����͍s��Ȃ��B
        if (m_navAgent.autoTraverseOffMeshLink)
        {
            yield break;
        }

        while (true)
        {
            // �I�t���b�V�������N�ɏ��܂őҋ@�B
            while (!m_navAgent.isOnOffMeshLink)
            {
                yield return null;
            }

            // NavMesh�̋������~�߂܂��B
            // Stop()��Obsolete�ɂȂ����悤�Ȃ̂Ŏg��Ȃ���B
            m_navAgent.isStopped = true;

            // �I�t���b�V�������N�ƍ����ɍ�������̂ŁA������Ɣ������B
            OffMeshLinkData offMeshLinkData = m_navAgent.currentOffMeshLinkData;
            Vector3 targetPos = offMeshLinkData.endPos;
            targetPos.y += transform.position.y - offMeshLinkData.startPos.y;

            yield return OffMeshLinkProcess(targetPos);

            // �I�t���b�V�������N�̌v�Z����������B
            m_navAgent.CompleteOffMeshLink();

            // NavMesh�̋������ĊJ����B
            // Resume()��Obsolete�ɂȂ����悤�Ȃ̂Ŏg��Ȃ���B
            m_navAgent.isStopped = false;
        }
    }

    protected virtual IEnumerator OffMeshLinkProcess(Vector3 i_targetPos)
    {
        yield return null;
    }

} // class ObjectController