using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class ObjectJumpController : ObjectController
{
    [SerializeField]
    private float m_jumpTime = 0.0f;

    private Rigidbody m_rigidbody = null;

    protected override void Start()
    {
        base.Start();

        // 放物線の挙動のためにRigidbodyを使う。
        // NavMeshAgentを使っているときは使いたくないので、
        // isKinematicを有効にしてRigidbodyの無効化する。
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.isKinematic = true;
    }

    protected override IEnumerator OffMeshLinkProcess(Vector3 i_targetPos)
    {
        m_rigidbody.isKinematic = false;
        m_rigidbody.velocity = Vector3.zero;

        ShootFixedTime(i_targetPos, m_jumpTime);

        yield return new WaitForSeconds(m_jumpTime);

        transform.position = i_targetPos;

        m_rigidbody.isKinematic = true;
        m_rigidbody.velocity = Vector3.zero;
    }

    private void ShootFixedTime(Vector3 i_targetPosition, float i_time)
    {
        float speedVec = ComputeVectorFromTime(i_targetPosition, i_time);
        float angle = ComputeAngleFromTime(i_targetPosition, i_time);

        if (speedVec <= 0.0f)
        {
            // その位置に着地させることは不可能のようだ！
            Debug.LogWarning("!!");
            return;
        }

        Vector3 vec = ConvertVectorToVector3(speedVec, angle, i_targetPosition);
        SetRigidbody(vec);
    }

    private Vector3 ConvertVectorToVector3(float i_v0, float i_angle, Vector3 i_targetPosition)
    {
        Vector3 startPos = transform.position;
        Vector3 targetPos = i_targetPosition;
        startPos.y = 0.0f;
        targetPos.y = 0.0f;

        Vector3 dir = (targetPos - startPos).normalized;
        Quaternion yawRot = Quaternion.FromToRotation(Vector3.right, dir);
        Vector3 vec = i_v0 * Vector3.right;

        vec = yawRot * Quaternion.AngleAxis(i_angle, Vector3.forward) * vec;

        return vec;
    }

    private float ComputeVectorFromTime(Vector3 i_targetPosition, float i_time)
    {
        Vector2 vec = ComputeVectorXYFromTime(i_targetPosition, i_time);

        float v_x = vec.x;
        float v_y = vec.y;

        float v0Square = v_x * v_x + v_y * v_y;
        // 負数を平方根計算すると虚数になってしまう。
        // 虚数はfloatでは表現できない。
        // こういう場合はこれ以上の計算は打ち切ろう。
        if (v0Square <= 0.0f)
        {
            return 0.0f;
        }

        float v0 = Mathf.Sqrt(v0Square);

        return v0;
    }

    private float ComputeAngleFromTime(Vector3 i_targetPosition, float i_time)
    {
        Vector2 vec = ComputeVectorXYFromTime(i_targetPosition, i_time);

        float v_x = vec.x;
        float v_y = vec.y;

        float rad = Mathf.Atan2(v_y, v_x);
        float angle = rad * Mathf.Rad2Deg;

        return angle;
    }

    private Vector2 ComputeVectorXYFromTime(Vector3 i_targetPosition, float i_time)
    {
        // 瞬間移動はちょっと……。
        if (i_time <= 0.0f)
        {
            return Vector2.zero;
        }


        // xz平面の距離を計算。
        Vector2 startPos = new Vector2(transform.position.x, transform.position.z);
        Vector2 targetPos = new Vector2(i_targetPosition.x, i_targetPosition.z);
        float distance = Vector2.Distance(targetPos, startPos);

        float x = distance;
        // な、なぜ重力を反転せねばならないのだ...
        float g = -Physics.gravity.y;
        float y0 = transform.position.y;
        float y = i_targetPosition.y;
        float t = i_time;

        float v_x = x / t;
        float v_y = (y - y0) / t + (g * t) / 2;

        return new Vector2(v_x, v_y);
    }

    private void SetRigidbody(Vector3 i_shootVector)
    {
        // 速さベクトルのままAddForce()を渡してはいけないぞ。力(速さ×重さ)に変換するんだ
        Vector3 force = i_shootVector * m_rigidbody.mass;

        m_rigidbody.AddForce(force, ForceMode.Impulse);
    }

} // class ObjectJumpController