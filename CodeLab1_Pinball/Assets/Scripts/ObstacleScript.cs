using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public AudioClip bounceSound;
    public ParticleSystem bounceParticle;
    public Color startColor;
    
    // put things that all obstacles have:
    // audio clip, particle system, start color
    void Start()
    {
        
    }

    void Update()
    {
        // increment the score after collisions (in ball script),
        // use score modifier for different bumpers/goals?
    }
}
