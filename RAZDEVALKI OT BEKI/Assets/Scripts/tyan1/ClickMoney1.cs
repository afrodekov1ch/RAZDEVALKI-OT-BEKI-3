using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickMoney1 : MonoBehaviour
{
    public Text[] tyanScoreTxt;
    public int[] tyanScore;

    public Text autoText;
    public int auto;

    public Text powerText;
    public int power = 1;

    public int score;
    public Text clicText;

    public GameObject effect;
    [SerializeField] private Camera mainCam;
    void Awake()
    {
        Debug.Log("НАЧАЛО!");
        StartCoroutine(AutoCLicking());
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
        auto = PlayerPrefs.GetInt("auto");


        if (score >= tyanScore[1])
        {
            tyanScoreTxt[0].text = "Открыть";
        }
        else
        {
            tyanScoreTxt[0].text = "" + tyanScore[1] + "$";
        }


        autoText.text = "+" + auto + "$ автоклик";

        powerText.text = "+" + power + "$ за клик";

        clicText.text = "" + score + "$";
    }
    public void clicerScore()
    {
        Vector3 pos = new Vector3(mainCam.ScreenToWorldPoint(Input.mousePosition).x, mainCam.ScreenToWorldPoint(Input.mousePosition).y, 0);
        score += power;
        PlayerPrefs.SetInt("Score+", score);
        Instantiate(effect, pos, Quaternion.identity);
    }
    public void PowerUp()
    {
        if(score >= 25)
        {
            score -= 25;
            PlayerPrefs.SetInt("Score+", score);
            power += 1;
            PlayerPrefs.SetInt("power", power);
        }
    }
    public void AutoUp()
    {
        if (score >= 100)
        {
            score -= 100;
            PlayerPrefs.SetInt("Score+", score);
            auto += 1;
            PlayerPrefs.SetInt("auto", auto);
        }
    }
    IEnumerator AutoCLicking()
    {
        yield return new WaitForSeconds(1);
        score += auto;
        PlayerPrefs.SetInt("Score+", score);
        StartCoroutine(AutoCLicking());
    }
}
