using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickMoney : MonoBehaviour
{
    public int score;
    public Text clicText;
    void Start()
    {
        score = 0;
        score = PlayerPrefs.GetInt("Score+", score);
    }


    void Update()
    {
        clicText.text = score.ToString();
    }
    public void clicerScore()
    {
        score++;
        PlayerPrefs.SetInt("Score+", score);
    }
}
