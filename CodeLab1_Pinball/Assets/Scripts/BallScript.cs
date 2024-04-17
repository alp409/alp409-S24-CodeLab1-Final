using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // private Rigidbody rb;
    // public float velocity;
    
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // OnTriggerEnter destroy gameobject when ball enters trigger of BallEnd object
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bumper"))
        {
            // check for score modifiers depending on what was collided with?
            Debug.Log("Hit Bumper");
        } 
    }
}
