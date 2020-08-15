using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriageScaleController : MonoBehaviour
{
    // Accesses the patient_data of the patient next to the player.
    // Sets a new trige scale on the patient_data
    public void SetTriageScale(int cat)
    {
        Patient_Data currentPatientData = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;

        if (currentPatientData != null)
        {
            currentPatientData.triageScale = cat;
        }
    }
}
