using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithVelocityWithParametrableVelocity : MoveWithVelocity
{
   public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
