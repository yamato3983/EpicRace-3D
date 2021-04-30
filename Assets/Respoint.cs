using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("êGÇÍÇΩ");
            PlayerPrefs.SetFloat("Px", other.transform.position.x);
            PlayerPrefs.SetFloat("Py", other.transform.position.y);
            PlayerPrefs.SetFloat("Pz", other.transform.position.z);
            PlayerPrefs.Save();
        }
        float myx = PlayerPrefs.GetFloat("Px");
        float myy = PlayerPrefs.GetFloat("Py");
        float myz = PlayerPrefs.GetFloat("Pz");
        Debug.Log("myx" + myx + "myy" + myy + "myz" + myz);
    }
}