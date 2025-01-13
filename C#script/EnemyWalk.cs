using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public Transform leftCheck;
    public Transform rightCheck;
    public float speed;
    private bool movingLeft;
    public Transform enemyBody;
    private Vector3 initScale;



    // Start is called before the first frame update
    void Start()
    {
        initScale = enemyBody.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingLeft == true)
        {
            if(enemyBody.transform.position.x >= leftCheck.position.x)
            {
                MoveInDirection(-1);
            }
        else
        {
            // change direction
            DirectionChande();
        }
        }
        else
        {
            // so
            if(enemyBody.transform.position.x <= rightCheck.position.x)
            {
                MoveInDirection(1);
            }
        else
        {
            // chang direction
            DirectionChande();
        }

        }
    }

    private void DirectionChande()
    {
        movingLeft = !movingLeft;

    }
    private void MoveInDirection(int direction)
    {
        enemyBody.transform.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);
        enemyBody.transform.position = new Vector3(enemyBody.transform.position.x + Time.deltaTime * direction * speed, 
        enemyBody.transform.position.y, enemyBody.transform.position.z);
    }

}
