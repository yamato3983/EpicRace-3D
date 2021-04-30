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
            Debug.Log("死にました");
            isDead = true;
        }
       
        if (isDead == true)
        {
            Debug.Log("isDeadがtrueになりました");
            GameObject obj = (GameObject)Resources.Load("Player");

            // プレハブを元にオブジェクトを生成する
            GameObject instance = (GameObject)Instantiate(obj,
                                                          new Vector3(9.2f, 3.2f, 1.0f),
                                                          Quaternion.identity);
            isDead = false;
        }
    }
}
