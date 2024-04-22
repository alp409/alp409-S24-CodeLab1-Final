using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    public Rigidbody leftRigidbody;
    public Rigidbody rightRigidbody;
    public float flipperForce;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: make this feel better
        if (Input.GetKeyDown(KeyCode.A))
        {
            leftRigidbody.AddForce(flipperForce * Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rightRigidbody.AddForce(flipperForce * Vector3.forward);
        }
    }
}
