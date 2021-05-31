using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_Conveyer : MonoBehaviour
{
    //�R���x�A�������Ă��邩
    public bool isActive = false;

    //�R���x�A�̏����ݒ葬�x
    public float convSpeed = 3.0f;

    //���݂̃R���x�A�̑��x
    public float ConveyerSpeed { get { return _convSpeed; } }

    private float _convSpeed = 0;

    //�R���x�A�̓�������
    public Vector3 ConveyerDirection = Vector3.forward;

    //�R���x�A�������^�ԗ�(������)
    [SerializeField]
    private float pushPower = 50f;

    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();

    //UV�X�N���[�����x
    [SerializeField]
    private float m_uvSpeed = 0.5f;

    private void Start()
    {
        //�����̐��K��
        ConveyerDirection = ConveyerDirection.normalized;
    }

    private void FixedUpdate()
    {
        //�E�B���E�B��
        ScrollUV();

        if (isActive == true)
        {
            convSpeed = 0;
        }

        //���ł����I�u�W�F�N�g�͍폜
        _rigidbodies.RemoveAll(r => r == null);

        foreach (var r in _rigidbodies)
        {
            //���̂̈ړ����x�̃x���g�R���x�A�����̐����������o��
            var objectSpeed = Vector3.Dot(r.velocity, ConveyerDirection);

            //�ڕW�l�ȉ��Ȃ��������
            if (objectSpeed < Mathf.Abs(convSpeed))
            {
                r.AddForce(ConveyerDirection * pushPower, ForceMode.Acceleration);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //���������z��RigifBody���Ԃ�����ł�邺������������
        var rigidBody = collision.gameObject.GetComponent<Rigidbody>();
        _rigidbodies.Add(rigidBody);
    }

    void OnCollisionExit(Collision collision)
    {
        //����Ă�RigidBody���Ԃ�����ł�邺����������
        //�܂���������Ă���S�R�Ӗ��Ȃ���ł����ǁc
        var rigidBody = collision.gameObject.GetComponent<Rigidbody>();
        _rigidbodies.Remove(rigidBody);
    }

    //�e�N�X�`����UV�l���X�N���[�������āA�x���g�R���x�A�̌����ڂ�\������B
    void ScrollUV()
    {
        //�A�^�b�`����Ă�}�e���A���e�N�X�`�����Am_uvSpeed�ƃ^�C�����|���ē�����
        var material = GetComponent<Renderer>().material;
        Vector2 offset = material.mainTextureOffset;

        //�E��(�v���C���[�̐i�s�����Ƌt�����ɓ�����)
        offset += Vector2.right * m_uvSpeed * Time.deltaTime;

        material.mainTextureOffset = offset;

       
    }

}
