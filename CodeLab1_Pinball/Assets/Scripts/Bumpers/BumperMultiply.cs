using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperMultiply : ObstacleScript
{
    public GameObject ballPrefab;
    public AudioClip multiballSound;
    public AudioClip multiballMusic;
    public override void ObstacleCollision(Collision collision)
    {
        Debug.Log("ObstacleCollision - BumperMultiply");
        Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        if (multiballSound != null)
        {
            AudioSource.PlayClipAtPoint(multiballSound, transform.position);
            AudioSource.PlayClipAtPoint(multiballMusic, transform.position);
        }
    }
}
