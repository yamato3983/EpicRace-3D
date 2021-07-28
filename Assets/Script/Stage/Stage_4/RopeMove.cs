using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMove : MonoBehaviour
{

    //�i�ޕ���
    private int direction = 1;

    //Z���̊p�x
    private float angle = 0f;

    //�����n�߂鎞��
    private float startTime;

    //�h�ꓮ���Ԋu�H���ԁH
    [SerializeField]
    private float duration = 5f;

    //�U��q������p�x
    [SerializeField]
    private float limitAngle = 90f;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        //�o�ߎ��Ԃɍ��킹���������v�Z
        float t = (Time.time - startTime) / duration;

        //�X���[�Y�Ȋp�x���v�Z
        angle = Mathf.SmoothStep(angle, direction * limitAngle, t);

        //�p�x�ύX
        transform.eulerAngles = new Vector3(angle, 0f, 0f);

        //�p�x���w�肵���p�x��1�x�̍��ɂȂ����甽�]
        if (Mathf.Abs(Mathf.DeltaAngle(angle, direction * limitAngle)) < 1f)
        {
            direction *= -1;
            startTime = Time.time;
        }

    }

    //�i��ł������
    public int GetDirection()
    {
        return direction;
    }
}
