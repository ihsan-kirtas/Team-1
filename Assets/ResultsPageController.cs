using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsPageController : MonoBehaviour
{
    private Patient_Data pd;
    public GameObject player;

    //public Text patientname;
    public Text yourDecisionText;
    public Text recommendedDecisionText; 
    public Text patientJourneyText;


    private void Start()
    {
        //player = GameObject.Find("Player");     // Link player

        //yourDecisionText.text = "";
        //recommendedDecisionText.text = "";
        //patientJourneyText.text = "";
    }

    public void UpdateResultsPage()
    {
        Debug.Log("Update results Page");

        // Update current patient Data
        pd = player.GetComponent<DialogManager>().currentPatient;

        if (pd != null)
        {
            // Set Text
            yourDecisionText.text = "";
            recommendedDecisionText.text = "";
            patientJourneyText.text = "";

        }
        else
        {
            yourDecisionText.text = BuildYourDecisionText();
            recommendedDecisionText.text = BuildYourDecisionText();
            patientJourneyText.text = pd.patienthospitaljourney;
        }
    }

    public string BuildYourDecisionText()
    {
        string returnString =
            "Name: " + pd.name + "\n" +
            " Include Triage score here";

        return returnString;
    }


    public string BuildRecommendedDecisionText()
    {
        string returnString = pd.recommendations + "\n" +
        " Include Clinical Reasoning here";

        return returnString;
    }
}
