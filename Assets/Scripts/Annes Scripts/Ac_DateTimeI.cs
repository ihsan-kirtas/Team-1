using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Ac_DateTimeI : MonoBehaviour
{
    
      

    public void SaveDateTime()
    {
        
        PlayerPrefs.SetString("Date and Time", System.DateTime.Now.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerPrefs.GetString("Date and Time"));
    }


}
