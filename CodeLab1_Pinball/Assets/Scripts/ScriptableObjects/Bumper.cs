
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu
  (
    fileName = "New Bumper",
    menuName = "New Bumper",
    order = 0)
]

public class Bumper : ScriptableObject
{
  public string bumperStyle;
  public ParticleSystem bumperParticle;
  public float particleDuration = 2f;
  
  // could put audio tracks here instead?
}
