using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Respawn : MonoBehaviour
{
    public GameObject Player;
    public bool isDead = false;

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Dead")
        {
            Destroy(this.gameObject);
            Debug.Log("���ɂ܂���");
            isDead = true;
        }
       
        if (isDead == true)
        {
            Debug.Log("isDead��true�ɂȂ�܂���");
            GameObject obj = (GameObject)Resources.Load("Player");

            // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
            GameObject instance = (GameObject)Instantiate(obj,
                                                          new Vector3(9.2f, 3.2f, 1.0f),
                                                          Quaternion.identity);
            isDead = false;
        }
    }
}
