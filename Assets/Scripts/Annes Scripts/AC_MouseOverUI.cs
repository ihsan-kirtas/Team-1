using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AC_MouseOverUI : MonoBehaviour
{
    public string gameObjectName;
    public Text gameObjectText;
    public bool displayInfo;

   

    public void Update()
    {
        FadeText();
               
    }

    private void OnMouseOver()
    {
        displayInfo = true;
        
    }

    private void OnMouseExit()
    {
        displayInfo = false;
    }

    void FadeText()
    {
        if (displayInfo)
        {
            gameObjectText.text = gameObjectName;
            gameObjectText.GetComponent<Text>().enabled = true;
        }

        else
        {
            gameObjectText.GetComponent<Text>().enabled = false;
        }
    }
}
