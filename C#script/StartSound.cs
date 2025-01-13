using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSound : MonoBehaviour
{
    public AudioSource startsound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playjumpSound()
    {
        startsound.Play();
        StartCoroutine(waitForSound());
    }

    IEnumerator waitForSound()
    {
        while(startsound.isPlaying)
        {
            yield return null;
        }
    }
}
