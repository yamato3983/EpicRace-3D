using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public GameObject player;
    public GameObject goal;
   
    Slider goalSlider;

    void Start()
    {
        goalSlider = GetComponent<Slider>();
        float maxnum = 140f;
        float nownum = 140f;

        goalSlider.maxValue = maxnum;
        goalSlider.value = nownum;
    }

    void Update()
    {
        goalSlider = GetComponent<Slider>();

        Vector3 posA = player.transform.position;
        Vector3 posB = goal.transform.position;
        float dis = Vector3.Distance(posA, posB);
        Debug.Log("‹——£ : " + dis);

        goalSlider.value = dis;
    }
}
