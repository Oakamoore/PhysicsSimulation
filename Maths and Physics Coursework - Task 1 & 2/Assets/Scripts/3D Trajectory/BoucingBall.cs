using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoucingBall : MonoBehaviour
{

    public Vector3 initialVelocity;

    private Vector3 velocity;
    private Vector3 position;
    private Vector3 gravity = new Vector3(0.0f, -9.81f, 0.0f);
    private float coefficientOfRestitution = 0.7f;

    void Start()
    {
        position = this.transform.position;
        velocity = initialVelocity;
    }

    void FixedUpdate()
    {
        //Updates the sphere's position every step
        position = position + velocity * Time.deltaTime;

        //Update the sphere's velocity every step
        velocity = velocity + gravity * Time.deltaTime;

        this.transform.position = position;

        if (this.transform.position.y < 0.5)
        {
            //Modifies the velocity when the sphere hits the plane
            this.velocity = initialVelocity * coefficientOfRestitution;
            //Reduces the bounciness of the ball until it comes to a stop
            if (coefficientOfRestitution > 0)
            {
                coefficientOfRestitution -= 0.1f;
            }
        }
    }
}
