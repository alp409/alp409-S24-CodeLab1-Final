using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(
    fileName = "New Bumper",
    menuName = "ScriptableObjects/Bumper",
    order = 0
    )
]
///////// PHASED THIS OUT?? //////////////
public class BumperScriptableObject : ScriptableObject
{
    // add more properties here 
    public int bumpForce = 10;
    public AudioClip bumpSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
