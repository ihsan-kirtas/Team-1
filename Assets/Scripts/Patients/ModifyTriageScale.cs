using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyTriageScale : MonoBehaviour
{
    // for buttons


    public Patient_Data currentPatientData;
    public GameObject patient;
    //public Transform triage1and2location;
    //public Transform triage3to5location;
    public GameObject patientResusBed;
    public GameObject patientBedspaceBed;


    void Start()
    {
        patientResusBed.SetActive(true);
        patientBedspaceBed.SetActive(true);
    }

    void SetTriageScale(int cat)
    {
        currentPatientData = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;

        if(currentPatientData != null)
        {
            currentPatientData.triageScale = cat;
        }
    }


    void setScale1()
    {
        SetTriageScale(1);
        patientResusBed.SetActive(false);//resus bed is disabled and animation can put bed in the position
    }

    void setScale2()
    {
        SetTriageScale(2);
        patientResusBed.SetActive(false);//resus bed is disabled and animation can put bed in the position
    }

    void setScale3()
    {
        SetTriageScale(3);
        patientBedspaceBed.SetActive(false);//bedspace bed disabled and animation can put bed into the position
    }

    void setScale4()
    {
        SetTriageScale(4);
        patientBedspaceBed.SetActive(false); //bedspace bed disabled and animation can put bed into the position

    }

    void setScale5()
    {
        SetTriageScale(5);
        patientBedspaceBed.SetActive(false);//bedspace bed disabled and animation can put bed into the position
    }
}

