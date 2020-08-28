using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ObsManager : MonoBehaviour
{
    private List<GameObject> patientsList;                 // The patient_data scriptable objects to record obs on
    public float takeObsFrequency = 15.0f;              // Take obs every x seconds


    void Start()
    {
        // spawn 1st patient
        //ActivatePatient(patients[0]);

        patientsList = GameObject.Find("GameManager").GetComponent<PatientManager>().allPatients;

        // Repeat Function - (FunctionName, Start Delay, Repeat every)
        InvokeRepeating("ProcessAllCurrentPatients", 0.0f, takeObsFrequency);
    }


    public void ActivatePatient(Patient_Data patient_data)
    {
        // Set Initial Obs Chart data + Activate
        patient_data.patientActive = true;
        //Debug.Log("activate patient complete");
    }


    void ProcessAllCurrentPatients()
    {
        if (patientsList.Count != 0)
        {
            // Checks if patient active, if yes record obs
            foreach (GameObject patientGO in patientsList)
            {
                Patient_Data patient_data = patientGO.GetComponent<NPC_Dialog>().NPC_Data;
                if (patient_data.patientActive)
                {
                    RecordObsChanges(patient_data);
                }
            }
            //Debug.Log("DEV - Obs cycle complete");
        }
        else
        {
            Debug.LogError("Triage Error - Patients required in ObsManager List");
        }


        // Broadcast UI update event
        //GameEvents.current.ChartUpdate(); // OLD
        GameEvents.current.UpdatePatientData();

    }

    // Add new Observations to the tracker. (new value = last value + modifier)
    void RecordObsChanges(Patient_Data pd)
    {
        // Add values to existing list
        if(pd.bloodPressureSystolicTracker.Count > 0)
            pd.bloodPressureSystolicTracker.Add(pd.bloodPressureSystolicTracker.Last() + pd.bloodPressureSystolicMod);        // Blood Pressure - Systolic
        if (pd.bloodPressureDiastolicTracker.Count > 0)
            pd.bloodPressureDiastolicTracker.Add(pd.bloodPressureDiastolicTracker.Last() + pd.bloodPressureDiastolicMod);     // Blood Pressure - Diastolic
        if(pd.breathRateTracker.Count > 0)
            pd.breathRateTracker.Add(pd.breathRateTracker.Last() + pd.breathRateMod);                                         // Breath Rate
        if (pd.oxygenTracker.Count > 0)
            pd.oxygenTracker.Add(pd.oxygenTracker.Last() + pd.oxygenMod);                                                     // Oxygen
        if (pd.pulseRateTracker.Count > 0)
            pd.pulseRateTracker.Add(pd.pulseRateTracker.Last() + pd.pulseRateMod);                                            // Pulse Rate
        if (pd.tempTracker.Count > 0)
            pd.tempTracker.Add(pd.tempTracker.Last() + pd.tempMod);                                                           // Temp Tracker

        // if length > 10 remove 2nd item in the list
        TrimListSize(pd.bloodPressureSystolicTracker);
        TrimListSize(pd.bloodPressureDiastolicTracker);
        TrimListSize(pd.breathRateTracker);
        
        TrimListSize(pd.oxygenTracker);
        TrimListSize(pd.pulseRateTracker);
        TrimListSize(pd.tempTracker);
    }

    // List cleanup - Used to stop the Obs array from getting too huge. keeps the initial value and deletes the 2nd value if length >10
    void TrimListSize(List<float> tracker)
    {
        while (tracker.Count > 21)
        {
            // remove the 2nd value in the list
            tracker.Remove(tracker[1]);
        }
    }
}
