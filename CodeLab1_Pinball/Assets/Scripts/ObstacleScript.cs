using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    // super mom obstacle class
    // will have some lil babies
    // ...later
    // babies: bumpers, goals

    public AudioClip bounceSound;
    //public ParticleSystem bounceParticle;
    public float scoreMod = 1f;
    public float bounceForce; 
    
    private Queue<GameObject> hitQueue = new Queue<GameObject>();
    
    void Start()
    {
        
    }

    void Update()
    {
        // send score info to game manager for high score board
    }

    void OnCollisionEnter(Collision collision)
    {
        ObstacleCollision(collision);
        // TODO: put things that happen in every collision here using variables above
        
        // build queue of game objects as they are hit
        hitQueue.Enqueue(gameObject); 
        // Debug.Log(hitQueue);  // print to console
        
        // GameManager.instance.Score++;  // replaced this below
        // call IncrementScore in GameManager which applies each bumpers unique modifier
        GameManager.instance.IncrementScore(1, scoreMod);
        
        //Debug.Log("Hit (obstacle script)");
        Rigidbody ballRB = collision.rigidbody;
        
        // AddExplosionForce is using the bounceForce to push from the point at which 
        // the ball rb and the bumper rb touch, adjust explosion radius as needed
        ballRB.AddExplosionForce(bounceForce, collision.contacts[0].point, 5);
        
        if (bounceSound != null)
        {
            AudioSource.PlayClipAtPoint(bounceSound, transform.position);
        }
    }
    
    public virtual void ObstacleCollision(Collision collision)
    {
        Debug.Log("ObstacleCollision - ObstacleScript");
    }
}
