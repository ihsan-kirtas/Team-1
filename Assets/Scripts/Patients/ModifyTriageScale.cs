using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyTriageScale : MonoBehaviour
{
    // for buttons


    public Patient_Data currentPatientData;

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
    }

    void setScale2()
    {
        SetTriageScale(2);
    }

    void setScale3()
    {
        SetTriageScale(3);
    }

    void setScale4()
    {
        SetTriageScale(4);
    }

    void setScale5()
    {
        SetTriageScale(5);
    }
}

