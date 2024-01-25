using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGirl3 : MonoBehaviour
{
    [SerializeField] private GameObject[] obj;
    public int score;

    private void Update()
    {
        score = PlayerPrefs.GetInt("Score+");
    }
    public void Open(int girl)
    {
        if(score >= 8000)
        {
            Debug.LogWarning("Открыт");
            score -= 8000;
            obj[0].SetActive(true);
            PlayerPrefs.SetInt("girl3", 1);
            PlayerPrefs.SetInt("Score+", score);
        }
        
    }
}
