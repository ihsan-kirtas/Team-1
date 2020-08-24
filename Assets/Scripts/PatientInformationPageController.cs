using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

// Script contributors: James Siebert

public class PatientInformationPageController : MonoBehaviour
{
    private Patient_Data pd;
    public GameObject player;

    public Text patientInformation;
    public Text ample;
    public Text ambulancebayhandover;


    // Call me whenever you display patient Information page
    public void UpdatePatientInformationPage()
    {
        // Update current patient Data
        pd = player.GetComponent<DialogManager>().currentPatient;

        // If there is a patient in range, set text
        if (pd != null)
        {
            patientInformation.text = BuildPatientInfoText();
            ample.text = BuildAMPLEText();
            ambulancebayhandover.text = pd.uiambohandover;
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
            "Age: " + pd.age.ToString() + "\n" +
            "Sex: " + pd.gender + "\n" +
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
            "E - Events Leading to Hospital Presentation: " + pd.leadingEvents + "\n";
        return returnString;
    }


    // Print String List - string builder
    public string PSL(List<string> stringList)
    {
        string returnString = "";                               // Set initial return string
        if (stringList.Count > 0)                               // If there is data to display
        {
            foreach (string str in stringList)                  // For all items in list
            {
                if (returnString == "")                         // If this is the first entry
                    returnString = str;                         // Just add the string
                else
                    returnString = returnString + ", " + str;   // Add the string plus a ","
            }
        }
        else
            returnString = "NA";                                // If list was empty return "NA"
        return returnString;                                    // If list had values return them as a string
    }
}