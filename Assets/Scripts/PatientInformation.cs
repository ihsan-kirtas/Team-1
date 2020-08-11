using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PatientInformation : MonoBehaviour
{
    public Text patientname;
    public Text patientage;
    public Text patientGender;
    public Text preexistingmedcond;
    public Text initalobs;
    public Text ambulancebayhandover;
    public Text currentObs;
    public Text ample;
    public Text recommendedDecision;
    public Text patientJourney;
    public Text clinicalReasoning;




    private void Start()
    {

        patientname = GameObject.Find("PatientInformation_variableName").GetComponent<Text>();
    }

    private void Update()//every frame it is going to look for the patient data 
    {
        

        if (GameObject.Find("Player").GetComponent<DialogManager>().currentPatient != null) //if it is set put something here
        {
            
            Patient_Data patient_data = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;
            patientname.text = patient_data.name;
            patientname.text = patient_data.uiambohandover;
            patientage.text = patient_data.age.ToString();
            ambulancebayhandover.text = patient_data.uiambohandover;
            currentObs.text = patient_data.currentObs;
            ample.text = patient_data.ampleText;
            recommendedDecision.text = patient_data.recommendations;
            patientJourney.text = patient_data.patienthospitaljourney;
            clinicalReasoning.text = patient_data.clinicalReferences;


            //ambulancebayhandover.text = patient_data.ambulanceBayConversation.Last().ToString();

            
        } else
        {
            patientname.text = "";
        }
    }
}
