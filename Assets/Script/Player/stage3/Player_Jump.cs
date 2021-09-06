using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    // �W�����v����́i������̗́j���`
    [SerializeField] private float jumpForce;

    /// <summary>
    /// Collider�����̃g���K�[�ɓ��������ɌĂяo�����
    /// </summary>
    /// <param name="other">������������̃I�u�W�F�N�g</param>
    private void OnTriggerEnter(Collider other)
    {
        // ������������̃^�O��Player�������ꍇ
        if (other.gameObject.CompareTag("Player"))
        {
            // �������������Rigidbody�R���|�[�l���g���擾���āA������̗͂�������
            other.gameObject.GetComponent<Rigidbody>().AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }
}
