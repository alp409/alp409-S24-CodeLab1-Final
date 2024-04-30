
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class BumperSticky : ObstacleScript
{

    public Rigidbody rb;
    public float freezeTime;
    public float launceForce;
    // public ParticleSystem holdParticle;  // particle effect for holding the ball (not working right now)
    [FormerlySerializedAs("launceSound")] public AudioClip launchSound;
    
    // private bool freezeCooldown = false;     // this isn't needed anymore because of the shiny new queue (stickyOrder)
                                                // that Sienna helped me add.  <3 Thanks Sienna + Code Help Desk

    private Queue<Rigidbody> StickyOrder = new Queue<Rigidbody>();
    
    void Start()
    {
        //holdParticle.gameObject.SetActive(false);
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        rb = ball.GetComponent<Rigidbody>();
        //Debug.Log(rb);
    }

    public override void ObstacleCollision(Collision collision)
    {
        Debug.Log("ObstacleCollision - BumperSticky");
        
        Rigidbody currentRd = collision.rigidbody;
        
        //Debug.Log(rb);
        // foreach (Rigidbody rd in StickyOrder){
        //     if (rd.gameObject == currentRd.gameObject)
        //     {
        //         return;
        //     }
        //
        // }
        if (!StickyOrder.Contains(currentRd))
        {
            StickyOrder.Enqueue(currentRd);
            currentRd.isKinematic = true;
            Invoke("Unfreeze", freezeTime);
        }

        //Debug.Log(currentRd);
        //Debug.Log(rb);
        // if (currentRd.gameObject != rb.gameObject) 
        // {
        //     
        //     // freeze the ball
        //     currentRd.isKinematic = true;
        //     // freezeCooldown = true;
        //     
        //     // invoke Unfreeze after (freezeTime) number of seconds
        //     Invoke("Unfreeze", freezeTime);
        // }
    }

    void Unfreeze() // releases the ball from isKinematic, invokes Shoot ball after .15 seconds
    {
        Rigidbody currentRd = StickyOrder.Peek();
        currentRd.isKinematic = false;
        Debug.Log("unfreeze" + StickyOrder.Count);
        Invoke("ShootBall", .15f);
    }

    void ShootBall()    //
    {
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, 0f);
        randomDirection.Normalize(); 
        Rigidbody currentRd = StickyOrder.Dequeue();
        currentRd.AddForce(randomDirection * launceForce, ForceMode.Impulse);
        Debug.Log("shoot" + StickyOrder.Count);
        //freezeCooldown = false;
        
        if (launchSound != null)
        {
            AudioSource.PlayClipAtPoint(launchSound, transform.position);
        }
    }
}
