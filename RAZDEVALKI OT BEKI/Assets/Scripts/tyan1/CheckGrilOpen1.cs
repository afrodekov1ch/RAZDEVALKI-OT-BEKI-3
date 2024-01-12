using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrilOpen1 : MonoBehaviour
{
    [SerializeField] private GameObject[] obj;
    [SerializeField] private GameObject[] button;
    private int girl;

    private void Update()
    {
        girl = PlayerPrefs.GetInt("girl1");
        if(girl == 0)
        {
            obj[0].SetActive(false);

            obj[1].SetActive(true);
            button[0].SetActive(true);
        }
        else
        {
            obj[0].SetActive(true);

            obj[1].SetActive(false);
            button[0].SetActive(false);
        }
    }
}
