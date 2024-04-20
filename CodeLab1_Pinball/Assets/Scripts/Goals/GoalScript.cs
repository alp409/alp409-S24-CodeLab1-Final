using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : ObstacleScript
{
    public float catchCount;
    
    public override void ObstacleCollision(Collision collision)
    {
        //base.ObstacleCollision(collision);
        Debug.Log("Goal Hit!");
    }
}
