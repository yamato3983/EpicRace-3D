using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class RagdollController : MonoBehaviour
{
    Animator animator;
    Rigidbody[] ragdollRigidbodies;
    void Start()
    {
        animator = GetComponent<Animator>();
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        StartCoroutine(Test());
    }
    void SetRagdoll(bool isEnabled)
    {
        foreach (Rigidbody rigidbody in ragdollRigidbodies)
        {
            rigidbody.isKinematic = !isEnabled;
            animator.enabled = !isEnabled;
        }
    }
    IEnumerator Test()
    {
        SetRagdoll(false);
        yield return new WaitForSeconds(3);
        SetRagdoll(true);
    }
}
