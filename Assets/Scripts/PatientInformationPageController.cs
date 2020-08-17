using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PatientInformationPageController : MonoBehaviour
{
    private Patient_Data pd;
    public GameObject player;

    //public Text patientname;
    public Text patientInformation;
    public Text ample;
    public Text ambulancebayhandover;


    private void Start()
    {
        //player = GameObject.Find("Player");     // Link player

        //patientInformation.text = "";
        //ample.text = "";
        //ambulancebayhandover.text = "";
        //Debug.Log(">>> player info Text WIPED<<<");
    }




    // Call me whenever you display patient Information page
    public void UpdatePatientInformationPage()
    {
        //Debug.Log("Update patient Info");

        // Update current patient Data
        pd = player.GetComponent<DialogManager>().currentPatient;

        // If there is a patient in range, set text
        if (pd != null)
        {
            patientInformation.text = BuildPatientInfoText();
            ample.text = BuildAMPLEText();
            ambulancebayhandover.text = pd.uiambohandover;
            //Debug.Log(">>> player info Text UPDATED<<<");
        }
        else
        {
            Debug.Log("NO PATIENT DATA FOUND");
            // No Patient close by - this shouldnt be possible but just in case
            patientInformation.text = "";
            ambulancebayhandover.text = "";
            ample.text = "";
        }
    }

    public string BuildPatientInfoText()
    {
        string returnString =
            "Name: " + pd.name + "\n" +
            "Age: " + pd.name.ToString() + "\n" +
            "Sex: " + pd.name + "\n" +
            "Overall Health: " + pd.overallHealth + "\n" +
            "Additional Notes: " + pd.additionalNotes + "\n";
        return returnString;
    }

    public string BuildAMPLEText()
    {
        string returnString =
            "A - Allergies: " + PSL(pd.allergies) + "\n" +
            "M - Medications: " + PSL(pd.medicationList) + "\n" +
            "P - Past Medical History: " + PSL(pd.medicalHistoryList) + "\n" +
            "L - Last Meal Time: " + pd.lastMealTime + "\n" +
            "E - Medications: " + pd.leadingEvents + "\n";
        return returnString;
    }


    // Prints the list to a string.
    // Print String List
    public string PSL(List<string> stringList)
    {
        string returnString = "";
        if(stringList.Count > 0)
        {
            foreach (string str in stringList)
            {
                // Append new string 
                if (returnString == "")
                {
                    returnString = str;
                }
                else
                {
                    returnString = returnString + ", " + str;
                }
            }
        }
        else
        {
            returnString = "NA";
        }
        return returnString;
    }

}
