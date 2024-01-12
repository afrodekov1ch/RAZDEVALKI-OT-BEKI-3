using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGirl : MonoBehaviour
{
    [SerializeField] private GameObject[] obj;
    public int score;

    private void Update()
    {
        score = PlayerPrefs.GetInt("Score+");
    }
    public void Open(int girl)
    {
        if(score >= 500)
        {
            Debug.LogWarning("Открыт");
            score -= 500;
            obj[0].SetActive(true);
            PlayerPrefs.SetInt("girl", 1);
            PlayerPrefs.SetInt("Score+", score);
        }
        
    }
}
