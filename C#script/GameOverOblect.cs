using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOblect : MonoBehaviour
{
    public string LoadScene;
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("GameOver");
    }

}