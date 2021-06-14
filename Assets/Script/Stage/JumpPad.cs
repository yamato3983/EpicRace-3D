using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JumpPad : MonoBehaviour
{

    public Material[] _material;   //���蓖�Ă�}�e���A��.
    private float step;           //���x����������
    private Vector3 scale;        //�傫��
    private float timeCount;      //���ԃJ�E���g
    private float timelimit;      //�������N�����J�E���g

    [SerializeField]
    public bool Gimmick_Jump;     //�W�����v��̃t���O

    private JumpColor color;            //�}�e���A���̔ԍ�

    enum JumpColor
    {
        Jump_ON,  //�W�����v ON
        Jump_OFF    //�W�����v OFF
    }

    void Start()
    {
        color = 0;  //��
        Gimmick_Jump = false;
        timeCount = 0f;
        timelimit = 5f;


    }

    void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount < (timelimit / 2))
        {
            //�W�����v��̐F��
            this.GetComponent<Renderer>().material.color = Color.white;

            //�W�����v�t���OOFF
            Gimmick_Jump = false;
        }
        if((timelimit / 2) < timeCount)
        {
            //�W�����v��̐F���
            //�}�e���A���ύX
            this.GetComponent<Renderer>().material.color = Color.blue;
        }
        if(timeCount > 5f)
        {
            //�J�E���g���Z�b�g
            timeCount = 0f;

            //�W�����v�t���OON
            Gimmick_Jump = true;
           
        }

  
    }
}