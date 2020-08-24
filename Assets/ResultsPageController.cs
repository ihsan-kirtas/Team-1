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

        yourDecisionText.text = BuildYourDecisionText();
        recommendedDecisionText.text = BuildRecommendedDecisionText();
        patientJourneyText.text = PatientHospitalJourneyText();

        //if (pd != null)
        //{
        //    // Set Text
        //    yourDecisionText.text = "";
        //    recommendedDecisionText.text = "";
        //    patientJourneyText.text = "";

        //}
        //else
        //{
        //    yourDecisionText.text = BuildYourDecisionText();
        //    recommendedDecisionText.text = BuildRecommendedDecisionText();
        //    patientJourneyText.text = PatientHospitalJourneyText();
        //}
    }

    public string BuildYourDecisionText()
    {
        string returnString =
            "Triage Score " + pd.triageScale + "\n";
           

        return returnString;
    }


    public string BuildRecommendedDecisionText()
    {
        string returnString =
            "Recommendations " + pd.recommendations + "\n" +
            "Clinical References " + pd.clinicalReferences + "\n";
        

        return returnString;
    }

    public string PatientHospitalJourneyText()
    {
        string returnString =
            " " + pd.patienthospitaljourney + "\n";
        return returnString;
    }
}
