
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperSticky : ObstacleScript
{
    private Rigidbody rb;
    public float freezeTime;

    private bool freezeCooldown = false;
    
    void Start()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        rb = ball.GetComponent<Rigidbody>();
    }

    public override void ObstacleCollision(Collision collision)
    {
        //base.ObstacleCollision(collision);
        Debug.Log("Sticky bumper hit!");

        if (rb != null && freezeCooldown == false)
        {
            // freeze the ball
            rb.isKinematic = true;
            freezeCooldown = true;
            
            // invoke Unfreeze after (freezeTime) number of seconds
            Invoke("Unfreeze", freezeTime);
        }
    }

    void Unfreeze()
    {
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }
}
