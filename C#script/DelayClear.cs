using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayClear : MonoBehaviour
{
    public float SecondClear = 0.15f;
    float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime >= SecondClear)
        {
            Destroy(this.gameObject);
        }
    }
}
