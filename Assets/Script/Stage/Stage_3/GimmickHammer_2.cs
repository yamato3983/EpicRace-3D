using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickHammer_2 : MonoBehaviour
{
    [SerializeField] Transform pivot; //‰ñ“]’†S

    [SerializeField] Transform bob;   //U‚èŽq

    float gravity = 0.5f;
    float rad = -0.3f * Mathf.PI;
    float R = 180f;
    float angularVelocity = 1.0f;         //Šp‘¬“x
    float angularAcceleration = 8.0f;      //Šp‰Á‘¬“x
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

        //(’†S,‰ñ“]Ž²,‰ñ“]Šp“x)
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

