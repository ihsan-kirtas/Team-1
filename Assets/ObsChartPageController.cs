using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

// Script contributors: James Siebert

public class ObsChartPageController : MonoBehaviour
{
    private Patient_Data pd;
    public GameObject player;
    public GameObject gameManager;

    public float drawDataFrequency = 300;
    private float frameRecord = 0;
    public Text additionalInfoText;

    private void Start()
    {
        pd = player.GetComponent<DialogManager>().currentPatient;
        additionalInfoText.text = "";
    }

    private void Update()
    {
        {
            // Only check every x frames - efficiency
            if (Time.frameCount > frameRecord + drawDataFrequency)
            {
                // if panel active and patient data exists
                if (gameManager.GetComponent<CanvasManager>().obsChartPagePanel.activeSelf && player.GetComponent<DialogManager>().currentPatient != null)
                    DrawInfoText();
                else
                    NoInfoText();
                frameRecord = Time.frameCount;  // Record time when this happened
            }
        }
    }

    // info to be displayed
    void DrawInfoText()
    {
        additionalInfoText.text =
            "PatientName: " + pd.name + "\n" +                      // Standard value
            "Current Blood Pressure: " + LST(pd.bloodPressureDiastolicTracker) + "/" + LST(pd.bloodPressureSystolicTracker) + "\n" +      // BP
            "Has Cannula: " + pd.hasCannula.ToString() + "\n" +     // Display a Bool
            "PatientName: " + PSL(pd.medicationList) + "\n";        // Display a list of values
    }

    // message where no patient is available
    void NoInfoText()
    {
        additionalInfoText.text = "No Patient";
    }

    //Gets the LAST VALUE of a list (current value)
    string LST(List<float> floatList)
    {
        string returnString = "NA";
        if (floatList.Count > 0)
            returnString = floatList.Last().ToString();
        return returnString;
    }

    // Print String List - string builder
    string PSL(List<string> stringList)
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
