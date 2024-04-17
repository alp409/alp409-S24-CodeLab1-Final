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
    public ParticleSystem bounceParticle;
    public Color startColor;
    
    void Start()
    {
        
    }

    void Update()
    {
        // send score info to game manager for high score board
    }

    private void OnCollisionEnter(Collision other)
    {
        // TODO: fix this
        GameManager.instance.Score++;
    }
}
