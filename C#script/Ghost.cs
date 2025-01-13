using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float walkSpeed = 2;
    int dir = 1;

    public Transform rightCheck;
    public Transform leftCheck;

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * walkSpeed * dir * Time.fixedDeltaTime);
        if(Physics2D.Raycast(rightCheck.position, Vector2.down,2) == false)
            dir = -1;
        if(Physics2D.Raycast(leftCheck.position, Vector2.down,2) == false)
            dir = 1;
    }
}
