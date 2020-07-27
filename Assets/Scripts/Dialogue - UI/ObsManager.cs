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
        ClearObsTrackers(patient_data);                  // clears out any data from the previous game in the scriptable object.
        NewPatientInitialObs(patient_data);
        patient_data.patientActive = true;
        //Debug.Log("activate patient complete");
    }

    void ClearObsTrackers(Patient_Data patient_data)
    {
        patient_data.bloodPressureSystolicTracker.Clear();      // Blood Pressure - Systolic
        patient_data.bloodPressureDiastolicTracker.Clear();     // Blood Pressure - Diastolic
        patient_data.breathRateTracker.Clear();                 // Breath Rate
        patient_data.capillaryRefillTracker.Clear();            // Capillary Refill
        patient_data.glasgowComaScaleTracker.Clear();           // Glasgow Coma Scale
        patient_data.oxygenTracker.Clear();                     // Oxygen
        patient_data.pulseRateTracker.Clear();                  // Pulse Rate
        patient_data.pupilReactionTracker.Clear();              // Pupil Reaction
        //Debug.Log("patient data cleared");
    }


    // Called when patient added. Adds initial values as the 1st observation recording in the tracker list
    void NewPatientInitialObs(Patient_Data patient_data)
    {
        patient_data.bloodPressureSystolicTracker.Add(patient_data.bloodPressureSystolicInit);          // Blood Pressure - Systolic
        patient_data.bloodPressureDiastolicTracker.Add(patient_data.bloodPressureDiastolicInit);        // Blood Pressure - Diastolic
        patient_data.breathRateTracker.Add(patient_data.breathRateInit);                                // Breath Rate
        patient_data.capillaryRefillTracker.Add(patient_data.capillaryRefillInit);                      // Capillary Refill
        patient_data.glasgowComaScaleTracker.Add(patient_data.glasgowComaScaleInit);                    // Glasgow Coma Scale
        patient_data.oxygenTracker.Add(patient_data.oxygenInit);                                        // Oxygen
        patient_data.pulseRateTracker.Add(patient_data.pulseRateInit);                                  // Pulse Rate
        patient_data.pupilReactionTracker.Add(patient_data.pupilReactionInit);                          // Pupil Reaction

        // Set initial values added to true, allows obs to start auto recording
        patient_data.initValsAdded = true;

        //Debug.Log("DEV - initial obs done");
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
    void RecordObsChanges(Patient_Data patient_data)
    {
        if (patient_data.initValsAdded)
        {
            // Add values to existing list
            patient_data.bloodPressureSystolicTracker.Add(patient_data.bloodPressureSystolicTracker.Last() + patient_data.bloodPressureSystolicMod);        // Blood Pressure - Systolic
            patient_data.bloodPressureDiastolicTracker.Add(patient_data.bloodPressureDiastolicTracker.Last() + patient_data.bloodPressureDiastolicMod);     // Blood Pressure - Diastolic
            patient_data.breathRateTracker.Add(patient_data.breathRateTracker.Last() + patient_data.breathRateMod);                                         // Breath Rate
            patient_data.capillaryRefillTracker.Add(patient_data.capillaryRefillTracker.Last() + patient_data.capillaryRefillMod);                          // Capillary Refill
            patient_data.glasgowComaScaleTracker.Add(patient_data.glasgowComaScaleTracker.Last() + patient_data.glasgowComaScaleMod);                       // Glasgow Coma Scale
            patient_data.oxygenTracker.Add(patient_data.oxygenTracker.Last() + patient_data.oxygenMod);                                                     // Oxygen
            patient_data.pulseRateTracker.Add(patient_data.pulseRateTracker.Last() + patient_data.pulseRateMod);                                            // Pulse Rate
            patient_data.pupilReactionTracker.Add(patient_data.pupilReactionTracker.Last() + patient_data.pupilReactionMod);                                // Pupil Reaction

            // if length > 10 remove 2nd item in the list
            TrimListSize(patient_data.bloodPressureSystolicTracker);
            TrimListSize(patient_data.bloodPressureDiastolicTracker);
            TrimListSize(patient_data.breathRateTracker);
            TrimListSize(patient_data.capillaryRefillTracker);
            TrimListSize(patient_data.glasgowComaScaleTracker);
            TrimListSize(patient_data.oxygenTracker);
            TrimListSize(patient_data.pulseRateTracker);
            TrimListSize(patient_data.pupilReactionTracker);

            //Debug.Log("DEV - Obs updated for " + patient_data.name);
        }
    }

    // List cleanup - Used to stop the Obs array from getting too huge. keeps the initial value and deletes the 2nd value if length >10
    void TrimListSize(List<float> tracker)
    {
        while (tracker.Count > 10)
        {
            // remove the 2nd value in the list
            tracker.Remove(tracker[1]);
        }
    }
}
