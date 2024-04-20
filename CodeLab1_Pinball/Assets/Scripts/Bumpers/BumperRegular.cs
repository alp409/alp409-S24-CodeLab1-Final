using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperRegular : ObstacleScript
{
    public override void ObstacleCollision(Collision collision)
    {
        //base.ObstacleCollision(collision);
        Debug.Log("Bumper Regular");
    }
}
