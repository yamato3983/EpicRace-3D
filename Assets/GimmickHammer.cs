using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickHammer : MonoBehaviour
{
    [SerializeField] Transform pivot; //‰ñ“]’†S
    [SerializeField] Transform bob;   //U‚èŽq

    float angularVelocity;
    float angularAcceleration;
    float angularAccelerationValue;

    public Vector3 GetCurrentVelocity()
    {
        float r = Vector3.Distance(pivot.position, bob.position);
        Vector3 dir = bob.position - pivot.position;
        Vector3 velocityDir = new Vector3(-dir.y, dir.x);
        velocityDir.Normalize();
        return (r * angularVelocity * velocityDir);
    }

    void FixedUpdate()
    {
        angularVelocity += angularAcceleration * Time.deltaTime;
        bob.RotateAround(pivot.position, Vector3.forward, angularVelocity);
        if (bob.position.x > pivot.position.x)
        {
            angularAcceleration = -angularAccelerationValue;
        }
        else
        {
            angularAcceleration = angularAccelerationValue;
        }
    }
}
