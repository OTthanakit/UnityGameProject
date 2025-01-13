using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{

    private Vector3 LocationA;
    private Vector3 LocationB;
    private Vector3 nextLocation;
    [SerializeField]private Transform platform;
    [SerializeField]private Transform MovingToLocation;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        LocationA = platform.localScale;
        LocationB = MovingToLocation.localPosition;
        nextLocation = LocationB;
    }

    // Update is called once per frame
    void Update()
    {
       Move();
    }

    private void Move()
    {
        platform.localPosition = Vector3.MoveTowards(platform.localPosition, nextLocation, speed * Time.deltaTime);
        if(Vector3.Distance(platform.localPosition,nextLocation) <= 0.1)
        {
            ChangePosition();
        }
    }
    private void ChangePosition()
    {
        nextLocation = nextLocation != LocationA ? LocationA : LocationB;
    }
}
