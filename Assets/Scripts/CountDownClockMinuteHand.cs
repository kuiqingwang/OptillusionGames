using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownClockMinuteHand : MonoBehaviour
{
    public AudioSource levelfinish;
    public void minutehandwin(){
        levelfinish.Play();
    }
}

