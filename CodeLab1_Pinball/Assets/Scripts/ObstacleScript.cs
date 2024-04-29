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
    
    // private Queue<GameObject> hitQueue = new Queue<GameObject>(); // TODO: get rid of this?
    
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
        
        // build queue of game objects as they are hit // TODO: get rid of this?
        // hitQueue.Enqueue(gameObject); 
        // Debug.Log(hitQueue);  // print to console
        
        // call IncrementScore in GameManager which applies each bumpers unique modifier
        GameManager.instance.IncrementScore(1, scoreMod);
        
        Rigidbody ballRB = collision.rigidbody;
        
        // AddExplosionForce is using the bounceForce to push from the point at which 
        // the ballRB and the bumper touch, adjust explosion radius as needed
        ballRB.AddExplosionForce(bounceForce, collision.contacts[0].point, 5);
        
        // if there is an audio clip in bounceSound, play the clip
        // (this helped me avoid issues if I forgot or hadn't added a sound clip yet)
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
