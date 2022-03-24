using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{

    public Transform[] wayPoints;

    public float speed = 0;

    private float slowedSpeed;

    private Vector3 oldPos;

    int i = 0;

    void Start()
    {
        slowedSpeed = speed / 3;
    }

    void FixedUpdate()
    {
        oldPos = this.transform.position;

        //The direction from the sphere's current position to the next waypoint
        Vector3 direction = wayPoints[i].position - oldPos;

        //Normalising the direction vector to find the unit vector, then multiplying by speed 
        Vector3 nextDestination = direction.normalized * speed;

        //Moves the ball towards the next waypoint at a constant velocity
        this.transform.position = oldPos + nextDestination * Time.deltaTime;

        posVectorsNearlyEqual(this.transform.position, wayPoints[i].position);

    }

    void posVectorsNearlyEqual(Vector3 vec1, Vector3 vec2)
    {
        float distance = Vector3.Distance(this.transform.position, wayPoints[i].position);

        if (Mathf.Abs(distance) < 5)
        {
            //Slows down the sphere when nears a waypoint
            speed = slowedSpeed;

            if (Mathf.Abs(distance) < 1)
            {
                //Moves onto the next waypoint 
                i++;

                //Speeds up the sphere 
                speed = slowedSpeed * 3;

                //Switches to the first waypoint when the last waypoint is reached
                if (i == 4)
                {
                    i = 0;
                }
            }

        }
    }

}
