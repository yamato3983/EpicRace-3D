using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotChange : MonoBehaviour
{

    /*********
    Gizmo�Ƃ́A�C�ӂ̃I�u�W�F�N�g����������@�\
    **********/

    //���_�}�[�N�̃T�C�Y
    public float gizmosize = 0.2f;

    //���_�}�[�N�̐F
    public Color pivotColor = Color.yellow;

    // Update is called once per frame
    void OnDrawGizmos()
    {
        //�M�Y���ɐF��t����
        Gizmos.color = pivotColor;

        //�ۂ��_�Ƃ��ĉ���������
        Gizmos.DrawWireSphere(transform.position, gizmosize);
    }
}
