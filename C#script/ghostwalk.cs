using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostwalk : MonoBehaviour
{
   public float walkSpeed = 1.0f;
   public float walkRight,walkLeft = 0.2f;
   public float walkDirection = 0.5f;
   public GameObject Explode;
   Vector3 walkAmount;

   void Update()
   {
    walkAmount.x = (walkDirection * walkSpeed) * Time.deltaTime;
    if(walkDirection > 0.0f && transform.position.x >= walkRight)
    {
        walkDirection = -1.0f;
    }
    else if(walkDirection < 0.0f && transform.position.x <= walkLeft)
    {
        walkDirection = 1.0f;
    }
        transform.Translate(walkAmount);
   }
}
