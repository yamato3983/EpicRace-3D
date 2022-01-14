using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickStels : MonoBehaviour
{

    //���ԃJ�E���g
    private float timeCount;

    public GameObject Stels01;
    public GameObject Stels02;
    public GameObject Stels03;
    public GameObject Stels04;
    public GameObject Stels05;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z

        // transform���擾
        Transform myTransform = this.transform;
        // ���[�J�����W�ł̍��W���擾
        Vector3 localPos = myTransform.localPosition;

        if (timeCount >= 0 && timeCount <= 1.0f)
        {
            Stels01.SetActive(false);
            Stels02.SetActive(false);
            Stels03.SetActive(false);
            Stels04.SetActive(false);
            Stels05.SetActive(false);
        }
        if (timeCount >= 1.0f && timeCount <= 2.0f)
        {
            Stels01.SetActive(true);
            Stels02.SetActive(true);
            Stels03.SetActive(true);
            Stels04.SetActive(true);
            Stels05.SetActive(true);

        }
        if(timeCount >= 2.0f)
        {
            timeCount = 0;
        }
    }
}
