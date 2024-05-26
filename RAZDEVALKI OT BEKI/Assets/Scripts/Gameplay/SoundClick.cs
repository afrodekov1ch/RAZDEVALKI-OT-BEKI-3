using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClick : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip clickFx;

    public void ClickSound(int random)
    {
        random = Random.Range(1, random);
        if(random == 1)
        {
            myFx.PlayOneShot(clickFx);
        }
    }
}