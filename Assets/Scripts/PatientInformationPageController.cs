using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PatientInformationPageController : MonoBehaviour
{
    private Patient_Data currentPatientData;
    private GameObject player;

    //public Text patientname;
    public Text patientInformation;
    public Text ample;
    public Text ambulancebayhandover;


    private void Start()
    {
        player = GameObject.Find("Player");     // Link player

        patientInformation.text = "";
        ample.text = "";
        ambulancebayhandover.text = "";
    }





    // THIS SHOULD BE OK TO DELETE

    //private void Update()//every frame it is going to look for the patient data 
    //{

    //    if (GameObject.Find("Player").GetComponent<DialogManager>().currentPatient != null) //if it is set put something here
    //    {
    //        //Time.timeScale = 1f;
    //        //GameIsPaused = false;
    //        //Cursor.visible = true;


    //        Patient_Data patient_data = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;

    //        patientname.text = patient_data.patientdemographics;
    //        //patientInformation.text = patient_data.patientdemographics;
    //        ambulancebayhandover.text = patient_data.uiambohandover;
    //        initalobs.text=patient_data.ambulanceBayConversation.Last().ToString();
    //        currentObs.text = patient_data.currentobs;
    //        //listOfInitialObs.text = patient_data.currentObs.ToArray().ToString();
    //        ample.text = patient_data.AMPLEtext;
    //        recommendedDecision.text = patient_data.recommendations;
    //        patientJourney.text = patient_data.patienthospitaljourney;
    //        clinicalReasoning.text = patient_data.clinicalReferences;
    //        triageScaleScore.text="Triage Score: "+ patient_data.triageScale.ToString();

    //    }
    //    else
    //    {
    //        patientname.text = "";
    //        //Cursor.visible = false;
    //    } 
    //}


    // Call me whenever you display patient Information page
    public void UpdatePatientInformationPage()
    {
        Debug.Log("Update patient Info");

        // Update current patient Data
        currentPatientData = player.GetComponent<DialogManager>().currentPatient;

        // If there is a patient in range, set text
        if (currentPatientData != null)
        {
            // Set Text
            
            patientInformation.text = "patient info here";
            ambulancebayhandover.text = currentPatientData.uiambohandover;
            ample.text = currentPatientData.AMPLEtext;

            //patientname.text = currentPatientData.patientdemographics;
            //initalobs.text = currentPatientData.ambulanceBayConversation.Last().ToString();
            //currentObs.text = currentPatientData.currentobs;
            //recommendedDecision.text = currentPatientData.recommendations;
            //patientJourney.text = currentPatientData.patienthospitaljourney;
            //clinicalReasoning.text = currentPatientData.clinicalReferences;
            //triageScaleScore.text = "Triage Score: " + currentPatientData.triageScale.ToString();
        }
        else
        {
            // No Patient close by - this shouldnt be possible but just in case
            patientInformation.text = "";
            ambulancebayhandover.text = "";
            ample.text = "";

            //patientname.text = "";
            //initalobs.text = "";
            //currentObs.text = "";
            //recommendedDecision.text = "";
            //patientJourney.text = "";
            //clinicalReasoning.text = "";
            //triageScaleScore.text = "";
        }
    }
}
