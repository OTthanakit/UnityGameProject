using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostWalk1 : MonoBehaviour
{
    public GameObject rightCheck;
    public GameObject leftCheck;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = leftCheck.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == leftCheck.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.75f && currentPoint == leftCheck.transform)
        {
            currentPoint = rightCheck.transform;
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.75f && currentPoint == rightCheck.transform)
        {
            currentPoint = leftCheck.transform;
        }
        
    }
}
