using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientSpawner : MonoBehaviour
{
    public List<Patient_Data> patients;

    private void Start()
    {
        if(patients.Count != 0)
        {
            // Deactivate all patients
            foreach (Patient_Data patient in patients)
            {
                //patient.character.SetActive(false);
            }

            // Spawn the 1st patient
            SpawnPatient(patients[0]);
            Debug.Log("1st Patient Spawned");
        }
        else
        {
            Debug.LogError("Triage Error - Patients required in PatientSpawner list.");
        }
        
    }

    void SpawnPatient(Patient_Data patient_data)
    {
        // Activate Patient Model visibility
        //patient_data.character.SetActive(true);

        // Calls the ActivatePatient function in the ObsManager script
        this.GetComponent<ObsManager>().ActivatePatient(patient_data);
    }
}
