using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_Conveyer : MonoBehaviour
{
    [SerializeField]
    private float m_uvSpeed = 1.0f;
    [SerializeField]
    private float m_movePower = 500.0f;
    [SerializeField]
    private float m_speedUpPower = 100.0f;
    [SerializeField]
    private float m_speedUpTime = 3.0f;

    private Renderer m_render = null;

    private List<Rigidbody> m_hitObjects = new List<Rigidbody>();

    void Awake()
    {
        m_render = GetComponent<Renderer>();
    }

    void Start()
    {
        StartCoroutine(SpeedUp(m_speedUpTime));
    }

    void Update()
    {
        ScrollUV();
    }

    void OnCollisionEnter(Collision other)
    {
        var body = other.gameObject.GetComponent<Rigidbody>();
        if (body != null)
        {
            Vector3 addPower = transform.forward * m_movePower;
            body.AddForce(addPower, ForceMode.Acceleration);

            m_hitObjects.Add(body);
        }
    }

    void OnCollisionExit(Collision other)
    {
        var body = other.gameObject.GetComponent<Rigidbody>();
        if (body != null)
        {
            Vector3 addPower = transform.forward * m_movePower;
            body.AddForce(-addPower, ForceMode.Acceleration);

            m_hitObjects.Remove(body);
        }
    }

    /// <summary>
    /// �e�N�X�`����UV�l���X�N���[�������āA�x���g�R���x�A�̌����ڂ�\������
    /// </summary>
    void ScrollUV()
    {
        var material = m_render.material;
        Vector2 offset = material.mainTextureOffset;
        offset += Vector2.up * m_uvSpeed * Time.deltaTime;
        material.mainTextureOffset = offset;
    }

    IEnumerator SpeedUp(float i_time)
    {
        while (true)
        {
            // ��莞�Ԃ��ƂɃX�s�[�h�A�b�v
            yield return new WaitForSeconds(i_time);
            m_movePower += m_speedUpPower;

            // ���ݏ���Ă���I�u�W�F�N�g�ɑ΂��ăX�s�[�h�A�b�v���͂�������
            Vector3 addPower = transform.forward * m_speedUpPower;
            foreach (var body in m_hitObjects)
            {
                if (body != null)
                {
                    body.AddForce(addPower, ForceMode.Acceleration);
                }
            }
        }
    }

}
