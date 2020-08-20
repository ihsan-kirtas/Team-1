using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AC_SavePlayerName : MonoBehaviour
{
    public InputField textBox;
    

    public void clickSaveNameButton()
    {
        PlayerPrefs.SetString("name", textBox.text);

        Debug.Log("your name is" + PlayerPrefs.GetString("name"));
    }

   


}
