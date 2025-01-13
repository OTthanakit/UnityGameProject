using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource jumpSound;
    public AudioSource coinSound;
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
        jumpSound.Play();
    }
    public void playcoinSound()
    {
       coinSound.Play();
    }
}
