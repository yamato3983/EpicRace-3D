using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerPush : MonoBehaviour
{
    // ˆÚ“®‚É—^‚¦‚é—Í
    [SerializeField]
    private float m_movePower = 500.0f;

    // ‘O‰ñ—^‚¦‚½ˆÚ“®‚Ì—Í
    private Vector3 m_prevVelocity = Vector3.zero;

    void Update()
    {
        var body = GetComponent<Rigidbody>();

        // ‘O‰ñ—^‚¦‚½—Í‚Ì‹t•ûŒü‚Ì—Í‚ð—^‚¦‚Ä‘ŠŽE
        body.AddForce(-m_prevVelocity);

        var velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity += Vector3.back;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += Vector3.right;
        }

        velocity *= m_movePower;
        body.AddForce(velocity);

        // —^‚¦‚½—Í‚ð•Û‘¶
        m_prevVelocity = velocity;
    }
}
