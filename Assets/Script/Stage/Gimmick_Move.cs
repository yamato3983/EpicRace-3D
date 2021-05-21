using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_Move : MonoBehaviour
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

    private void Start()
    {
        //�����̐��K��
        ConveyerDirection = ConveyerDirection.normalized;
    }

    private void FixedUpdate()
    {
        if (isActive == true)
        {
           // _convSpeed = isActive;
        }
    }
}
