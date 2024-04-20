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

    // TODO: use these 
    public AudioClip bounceSound;
    public ParticleSystem bounceParticle;
    public Color startColor;
    public float scoreMod;
    public float bounceForce; // move to bumper regular??
    
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
        // put things that happen in every collision here
    }

    public virtual void ObstacleCollision(Collision collision)
    {
        Debug.Log("Hit (obstacle script)");
        Rigidbody ballRB = collision.rigidbody;
        
        // AddExplosionForce is using the bounceForce to push from the point at which 
        // the ball rb and the bumper rb touch, adjust explosion radius as needed
        ballRB.AddExplosionForce(bounceForce, collision.contacts[0].point, 5);
        
        // TODO: fix this
        GameManager.instance.Score++;
    }
}
