using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickHammer : MonoBehaviour
{
    [SerializeField] Transform pivot; //âÒì]íÜêS
    [SerializeField] Transform bob;   //êUÇËéq

    float gravity = 0.3f;
    float rad = -0.5f * Mathf.PI;
    float R = 220f;
    float angularVelocity = 1.0f;         //äpë¨ìx
    float angularAcceleration = 1.0f;      //äpâ¡ë¨ìx
    float angularAccelerationValue = 0f;

    public Vector3 GetCurrentVelocity()
    {
        float r = Vector2.Distance(pivot.position, bob.position);
        Vector2 dir = bob.position - pivot.position;
        Vector2 velocityDir = new Vector2(dir.y, dir.x);
        velocityDir.Normalize();
        return (r * angularVelocity * velocityDir);
    }

    void FixedUpdate()
    {

        //angularAccelerationValue = (-1 * gravity / R) * Mathf.Sin(rad);

        angularVelocity += angularAcceleration * Time.deltaTime;

        bob.RotateAround(pivot.position, Vector3.forward, angularVelocity);

        if (bob.position.x < pivot.position.x)
        {
            angularAcceleration = -angularAccelerationValue;
        }
        else if (bob.position.x > pivot.position.x)
        {
            angularAcceleration = angularAccelerationValue;
        }


    }

}
    
