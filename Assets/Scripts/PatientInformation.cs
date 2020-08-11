using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PatientInformation : MonoBehaviour
{
    public Text patientname;
    public Text patientInformation;
    public Text initalobs;
    public Text ambulancebayhandover;
    public Text currentObs;
    public Text ample;
    public Text recommendedDecision;
    public Text patientJourney;
    public Text clinicalReasoning;
    public Text triageScaleScore;
    public bool gameispaused = false;




    private void Start()
    {

        patientname = GameObject.Find("PatientInformation_variableName").GetComponent<Text>();


    }

    private void Update()//every frame it is going to look for the patient data 
    {

        if (GameObject.Find("Player").GetComponent<DialogManager>().currentPatient != null) //if it is set put something here
        {
            //Time.timeScale = 1f;
            //GameIsPaused = false;
            Cursor.visible = true;


            Patient_Data patient_data = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;

            patientname.text = patient_data.patientdemographics;
            //patientInformation.text = patient_data.patientdemographics;
            ambulancebayhandover.text = patient_data.uiambohandover;
            initalobs.text=patient_data.ambulanceBayConversation.Last().ToString();
            currentObs.text = patient_data.currentobs;
            ample.text = patient_data.AMPLEtext;
            recommendedDecision.text = patient_data.recommendations;
            patientJourney.text = patient_data.patienthospitaljourney;
            clinicalReasoning.text = patient_data.clinicalReferences;
            triageScaleScore.text="Triage Score: "+ patient_data.triageScale.ToString();

        }
        else
        {
            patientname.text = "";
            Cursor.visible = false;
        }

        
        
    }

 
}
