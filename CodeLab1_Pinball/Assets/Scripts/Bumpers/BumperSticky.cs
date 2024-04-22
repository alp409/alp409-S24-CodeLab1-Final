
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperSticky : ObstacleScript
{
    private Rigidbody rb;
    public float freezeTime;
    public float launceForce;
    public ParticleSystem holdParticle;  // particle effect specifically for holding the ball

    private bool freezeCooldown = false;
    
    void Start()
    {
        holdParticle.gameObject.SetActive(false);
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

            // TODO: fix it, particle system not activating
            holdParticle.gameObject.SetActive(true);
            
            // invoke Unfreeze after (freezeTime) number of seconds
            Invoke("Unfreeze", freezeTime);
        }
    }

    void Unfreeze() // releases the ball from isKinematic, invokes Shoot ball after .15 seconds
    {
        if (rb != null)
        {
            rb.isKinematic = false;
            //freezeCooldown = false;  // freezeCooldown must stay FALSE so that the ball doesn't get stuck

            Invoke("ShootBall", .15f);
        }
    }

    void ShootBall()    // ball is already free from kinematic, ball is shot in random direction
                        // freezeCooldown reset so the ball will stick again if it hits
    {
        //rb.isKinematic = false;
        
        Vector3 randomDirection = Random.insideUnitSphere;
        rb.AddForce(randomDirection* launceForce, ForceMode.Impulse);

        freezeCooldown = false;
    }
}
