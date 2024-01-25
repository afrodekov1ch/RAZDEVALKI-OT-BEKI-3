using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGirl1 : MonoBehaviour
{
    [SerializeField] private GameObject[] obj;
    public int score;

    private void Update()
    {
        score = PlayerPrefs.GetInt("Score+");
    }
    public void Open(int girl)
    {
        if(score >= 4000)
        {
            Debug.LogWarning("Открыт");
            score -= 4000;
            obj[0].SetActive(true);
            PlayerPrefs.SetInt("girl1", 1);
            PlayerPrefs.SetInt("Score+", score);
        }
        
    }
}
