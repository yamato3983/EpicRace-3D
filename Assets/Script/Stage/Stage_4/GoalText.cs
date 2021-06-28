using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalText : MonoBehaviour
{
 
    public GameObject gameclear_player;　//クリアテキスト(Player)
    public GameObject gameclear_cpu;     //クリアテキスト(CPU)
    public GameObject player;            //プレイヤー
    public GameObject cpu;               //CPU

    private void OnTriggerEnter(Collider other)
    {
        
        //もしゴールラインにプレイヤーが接触した時
        if(other.gameObject.tag == "Player")
        {
            //ステージクリアテキストを表示
            gameclear_player.GetComponent<Text>();
            gameclear_player.SetActive(true);
        }

        //もしゴールラインにCPUが接触した時
        if(other.gameObject.tag == "CPU")
        {
            //ステージクリアテキストを表示
            gameclear_cpu.GetComponent<Text>();
            gameclear_cpu.SetActive(true);
        }
    }
}
