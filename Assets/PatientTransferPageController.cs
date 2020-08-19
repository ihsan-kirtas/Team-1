using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientTransferPageController : MonoBehaviour
{
    private Patient_Data currentPatientData;
    public GameObject player;

    //public Text patientname;
    public Text initialObsText;


    private void Start()
    {
        //player = GameObject.Find("Player");     // Link player

        //initialObsText.text = "";
    }

    public void UpdatePatientTransferPage()
    {
        Debug.Log("Update patient transfer Page");

        // Update current patient Data
        currentPatientData = player.GetComponent<DialogManager>().currentPatient;

        if (currentPatientData != null)
        {
            // Set Text
            //initialObsText.text = currentPatientData.uiambohandover;

        }
        else
        {
            initialObsText.text = "";
        }
    }

    public void SaveDateTime()
    {
        // Gets the current date time stored in player prefs, if nothing set to ""
        string originalString = PlayerPrefs.GetString("DateTime", "").ToString();

        // If empty 
        if (originalString == "")
            // just set the datetime
            PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
        else
            // else if there is already values then add a ","
            PlayerPrefs.SetString("DateTime", originalString + "\n" + System.DateTime.Now.ToString());
    }
}
