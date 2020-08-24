using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AC_ShowPlayerData : MonoBehaviour
{
    public Text nameBox;
    public Text dateTimeBox;

    //public string name;



    // Start is called before the first frame update
    void Start()
    {
        
        nameBox.text = PlayerPrefs.GetString("name");
        dateTimeBox.text = PlayerPrefs.GetString("Date and Time");
        Debug.Log("player name is updated");
    }

    
}
