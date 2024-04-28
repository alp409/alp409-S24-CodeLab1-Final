
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BumperSticky : ObstacleScript
{
    private Rigidbody rb;  // TODO: how to grab rigidbody of the ball that collided, not the original ball
    
    public float freezeTime;
    public float launceForce;
    public ParticleSystem holdParticle;  // particle effect for holding the ball
    [FormerlySerializedAs("launceSound")] public AudioClip launchSound;
    
    private bool freezeCooldown = false;
    
    void Start()
    {
        //holdParticle.gameObject.SetActive(false);
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        rb = ball.GetComponent<Rigidbody>();
    }

    public override void ObstacleCollision(Collision collision)
    {
        Debug.Log("ObstacleCollision - BumperSticky");
        
        //base.ObstacleCollision(collision);
        //var emission = holdParticle.emission;
        
        if (rb != null && freezeCooldown == false) 
        {
            // freeze the ball
            rb.isKinematic = true;
            freezeCooldown = true;

            // TODO: fix it, particle system not activating
            //emission.enabled = true;
            //holdParticle.Play();
            //holdParticle.gameObject.SetActive(true);
            
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
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, 0f);
        randomDirection.Normalize(); 
        rb.AddForce(randomDirection * launceForce, ForceMode.Impulse);
        
        freezeCooldown = false;
        
        if (launchSound != null)
        {
            AudioSource.PlayClipAtPoint(launchSound, transform.position);
        }
    }
}
