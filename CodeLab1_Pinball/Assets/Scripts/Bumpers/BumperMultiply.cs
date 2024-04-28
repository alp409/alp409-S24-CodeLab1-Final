using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperMultiply : ObstacleScript
{
    public GameObject ballPrefab;
    public override void ObstacleCollision(Collision collision)
    {
        Debug.Log("ObstacleCollision - BumperMultiply");
        Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
