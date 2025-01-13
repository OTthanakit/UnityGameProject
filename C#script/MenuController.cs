using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public AudioSource startsound;
    public void LoadScene(string sceneName)
    {
        startsound.Play();
        StartCoroutine(waitForSeconds(2.0f, sceneName));
    }

    public IEnumerator waitForSeconds(float t, string sceneName)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(sceneName);

    }
}