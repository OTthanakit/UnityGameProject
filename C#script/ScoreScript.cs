using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text MyscoreText;
    private int ScoreNum;
    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "COIN : " + ScoreNum;
    }

    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if(Coin.tag == "Mycoin")
        {
            ScoreNum += 1;
            Destroy(Coin.gameObject);
            MyscoreText.text = "COIN : " + ScoreNum;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
