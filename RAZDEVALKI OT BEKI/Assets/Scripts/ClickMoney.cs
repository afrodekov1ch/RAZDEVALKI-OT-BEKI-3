using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickMoney : MonoBehaviour
{
    public Text[] tyanScoreTxt;
    public int[] tyanScore;
    public Text autoText;
    public int auto;
    public Text powerText;
    public int power;
    public int score;
    public Text clicText;
    void Start()
    {
        score = 0;
    }


    void Update()
    {
        score = PlayerPrefs.GetInt("Score+", score);
        if (score <= tyanScore[1])
        {
            tyanScore[0] = tyanScore[1] - score;
        }
        else{
            tyanScore[0] = 0;
        }
        tyanScoreTxt[0].text = "Монет: " + tyanScore[0] + "";
        autoText.text = "+" + auto + " автоклик";
        powerText.text = "+" + power + " за клик";
        clicText.text = "Монет: " + score;
    }
    public void clicerScore()
    {
        score += power;
        PlayerPrefs.SetInt("Score+", score);
    }
}
