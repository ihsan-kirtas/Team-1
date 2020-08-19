using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AC_SavePlayerName : MonoBehaviour
{
    public InputField inputText;
     string playerName;

    private void Start()
    {
        playerName = PlayerPrefs.GetString("playernametext");
        inputText.text = playerName;
    }

    public void SavePlayerName()
    {
        playerName = inputText.text;
        PlayerPrefs.SetString("playernametext", playerName);
        Debug.Log("player name being shown");
    }


}
