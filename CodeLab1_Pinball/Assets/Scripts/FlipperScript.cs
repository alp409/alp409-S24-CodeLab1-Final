using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    public Rigidbody leftRigidbody;
    public Rigidbody rightRigidbody;
    public float flipperForce;
    
    public AudioClip leftFlipperSound;
    public AudioClip rightFlipperSound;
    
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            leftRigidbody.AddForce(flipperForce * Vector3.forward);
            // play leftFlipperSound here
            PlayFlipperSound(leftFlipperSound);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rightRigidbody.AddForce(flipperForce * Vector3.forward);
            // play rightFlipperSound here
            PlayFlipperSound(rightFlipperSound);
        }
    }

    void PlayFlipperSound(AudioClip soundFile)
    {
        if (soundFile != null)
        {
            AudioSource.PlayClipAtPoint(soundFile, transform.position);
        }
    }
}
