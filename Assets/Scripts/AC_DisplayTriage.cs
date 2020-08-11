using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AC_DisplayTriage : MonoBehaviour
{
    public GameObject patientInfoPage;
    public GameObject initalObsPage;
    public GameObject currentObsPage;
    public GameObject resultsPage;
    public GameObject patientTransferPage;
    public GameObject triageScore1;
    public GameObject triageScore2;
    public GameObject triageScore3;
    public GameObject triageScore4;
    public GameObject triageScore5;
    public GameObject SAGO1;
    public GameObject SAGO2;
    public GameObject bpHighvalue;
    public GameObject bpLowvalue;
    public GameObject respratevalue;
    public GameObject GCSvalue;
    public GameObject initalObsListTextbox;




    public void SetTriageScale(int cat)
    {
       Patient_Data currentPatientData = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;

        if (currentPatientData != null)
        {
            currentPatientData.triageScale = cat;
        }
    }

    public void displayPatientInfoPage()
    {
        patientInfoPage.SetActive(true);
        initalObsPage.SetActive(false);
        currentObsPage.SetActive(false);
        resultsPage.SetActive(false);
        patientTransferPage.SetActive(false);
        SAGO1.SetActive(false);
        SAGO2.SetActive(false);
        bpHighvalue.SetActive(false);
        bpLowvalue.SetActive(false);
        respratevalue.SetActive(false);
        GCSvalue.SetActive(false);
        initalObsListTextbox.SetActive(false);




}

public void displayInitalObsPage()
    {
        patientInfoPage.SetActive(false);
        initalObsPage.SetActive(true);
        currentObsPage.SetActive(false);
        resultsPage.SetActive(false);
        patientTransferPage.SetActive(false);
        SAGO1.SetActive(false);
        SAGO2.SetActive(false);
        bpHighvalue.SetActive(false);
        bpLowvalue.SetActive(false);
        respratevalue.SetActive(false);
        GCSvalue.SetActive(false);
        initalObsListTextbox.SetActive(true);

    }

    public void displayCurrentObsPage()
    {
        patientInfoPage.SetActive(false);
        initalObsPage.SetActive(false);
        currentObsPage.SetActive(true);
        resultsPage.SetActive(false);
        patientTransferPage.SetActive(false);
        SAGO1.SetActive(true);
        SAGO2.SetActive(true);
        bpHighvalue.SetActive(true);
        bpLowvalue.SetActive(true);
        respratevalue.SetActive(true);
        GCSvalue.SetActive(true);
        initalObsListTextbox.SetActive(false);

    }

    public void displayResultsPage()
    {
        patientInfoPage.SetActive(false);
        initalObsPage.SetActive(false);
        currentObsPage.SetActive(false);
        resultsPage.SetActive(true);
        patientTransferPage.SetActive(false);
        SAGO1.SetActive(false);
        SAGO2.SetActive(false);
        bpHighvalue.SetActive(false);
        bpLowvalue.SetActive(false);
        respratevalue.SetActive(false);
        GCSvalue.SetActive(false);
        initalObsListTextbox.SetActive(false);

    }

    public void displayPatientTransferPage()
    {
        patientInfoPage.SetActive(false);
        initalObsPage.SetActive(false);
        currentObsPage.SetActive(false);
        resultsPage.SetActive(false);
        patientTransferPage.SetActive(true);
        SAGO1.SetActive(false);
        SAGO2.SetActive(false);
        bpHighvalue.SetActive(false);
        bpLowvalue.SetActive(false);
        respratevalue.SetActive(false);
        GCSvalue.SetActive(false);
        initalObsListTextbox.SetActive(false);

    }

    public void spawnNewpatient()
    {
         //GameObject.Find("Player").GetComponent<JH_PatientSpawner>().SpawnNextPatient();
    }
}
