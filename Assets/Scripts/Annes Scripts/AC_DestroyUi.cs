using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AC_DestroyUi : MonoBehaviour
{
    public GameObject uiText;
    public GameObject uiTextField;
    public GameObject uiSubmitButton;
    public GameObject uiMainMenuButton;
    public GameObject resultsText;
    

    public void Start()
    {
        uiMainMenuButton.SetActive(false);
        resultsText.SetActive(false);
    }

    public void DisableTextBox()
    {
        uiText.SetActive(false);
        uiTextField.SetActive(false);
        uiSubmitButton.SetActive(false);
        uiMainMenuButton.SetActive(true);
        resultsText.SetActive(true);
        

     

    }




}
