using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Ac_DateTimeI : MonoBehaviour
{
    //public string time;
    //public float timespeed = 1f;
    //private float currenttime;

    //private void Start()
    //{
    //    time = System.DateTime.Now.ToString("hh:mm:ss");
        
    //}

    public void SaveDateTime()
    {
        
        PlayerPrefs.SetString("Date and Time", System.DateTime.Now.ToString());
        Debug.Log("date and time" + PlayerPrefs.GetString("Date and Time"));
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //Debug.Log(PlayerPrefs.GetString("Date and Time"));
    //}


}
