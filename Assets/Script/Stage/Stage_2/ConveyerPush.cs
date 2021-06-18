using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerPush : MonoBehaviour
{
    // �ړ��ɗ^�����
    [SerializeField]
    private float m_movePower = 500.0f;

    // �O��^�����ړ��̗�
    private Vector3 m_prevVelocity = Vector3.zero;

    void Update()
    {
        var body = GetComponent<Rigidbody>();

        // �O��^�����͂̋t�����̗͂�^���đ��E
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

        // �^�����͂�ۑ�
        m_prevVelocity = velocity;
    }
}
