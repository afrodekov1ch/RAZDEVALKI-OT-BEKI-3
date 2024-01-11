using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrilOpen : MonoBehaviour
{
    [SerializeField] private GameObject[] obj;
    private int girl;

    private void Update()
    {
        girl = PlayerPrefs.GetInt("girl");
        if(girl == 0)
        {
            obj[0].SetActive(false);
        }
        else
        {
            obj[0].SetActive(true);
        }
    }
}
