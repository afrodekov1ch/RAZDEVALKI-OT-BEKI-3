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
    public int power = 1;

    public int score;
    public Text clicText;
    void Awake()
    {
        Debug.Log("НАЧАЛО!");
    }


    void Update()
    {
        if (power == 0)
        {
            power = 1;
            PlayerPrefs.SetInt("power", power);
        }


        score = PlayerPrefs.GetInt("Score+");
        power = PlayerPrefs.GetInt("power");


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
    public void PowerUp()
    {
        if(score >= 25)
        {
            score -= 15;
            PlayerPrefs.SetInt("Score+", score);
            power += 1;
            PlayerPrefs.SetInt("power", power);
        }
    }
}
