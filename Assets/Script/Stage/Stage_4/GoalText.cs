using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalText : MonoBehaviour
{
 
    public GameObject gameclear_player;�@//�N���A�e�L�X�g(Player)
    public GameObject gameclear_cpu;     //�N���A�e�L�X�g(CPU)
    public GameObject player;            //�v���C���[
    public GameObject cpu;               //CPU

    private void OnTriggerEnter(Collider other)
    {
        
        //�����S�[�����C���Ƀv���C���[���ڐG������
        if(other.gameObject.tag == "Player")
        {
            //�X�e�[�W�N���A�e�L�X�g��\��
            gameclear_player.GetComponent<Text>();
            gameclear_player.SetActive(true);
        }

        //�����S�[�����C����CPU���ڐG������
        if(other.gameObject.tag == "CPU")
        {
            //�X�e�[�W�N���A�e�L�X�g��\��
            gameclear_cpu.GetComponent<Text>();
            gameclear_cpu.SetActive(true);
        }
    }
}
