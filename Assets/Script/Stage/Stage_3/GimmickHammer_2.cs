using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickHammer_2 : MonoBehaviour
{
    [SerializeField] Transform pivot; //��]���S

    [SerializeField] Transform bob;   //�U��q

    float gravity = 0.5f;
    float rad = -0.3f * Mathf.PI;
    float R = 180f;
    float angularVelocity = 1.0f;         //�p���x
    float angularAcceleration = 8.0f;      //�p�����x
    float angularAccelerationValue = 1.0f;

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

        angularVelocity -= angularAcceleration * Time.deltaTime;

        //(���S,��]��,��]�p�x)
        bob.RotateAround(pivot.position, Vector3.forward, angularVelocity);

        if (bob.position.x > pivot.position.x)
        {
            angularAcceleration = 5.0f;
        }
        else if (bob.position.x < pivot.position.x)
        {
            angularAcceleration = -5.0f;
        }


    }

}

