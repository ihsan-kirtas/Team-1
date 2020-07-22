using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ObsManager : MonoBehaviour
{
    public List<Patient_Data> patients;                 // The patient_data scriptable objects to record obs on
    public float takeObsFrequency = 15.0f;              // Take obs every x seconds

    void Start()
    {
        // spawn 1st patient
        ActivatePatient(patients[0]);

        // Repeat Function - (FunctionName, Start Delay, Repeat every)
        InvokeRepeating("ProcessAllCurrentPatients", 0.0f, takeObsFrequency);
    }

    void Update()
    {
    }

    public void ActivatePatient(Patient_Data patient_data)
    {
        // Set Initial Obs Chart data + Activate
        ClearObsTrackers(patient_data);                  // clears out any data from the previous game in the scriptable object.
        NewPatientInitialObs(patient_data);
        patient_data.patientActive = true;
        Debug.Log("activate patient complete");
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
        Debug.Log("patient data cleared");
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

        Debug.Log("DEV - initial obs done");
    }

    void ProcessAllCurrentPatients()
    {
        if(patients.Count != 0)
        {
            foreach (Patient_Data patient in patients)
            {
                if (patient.patientActive)
                {
                    RecordObsChanges(patient);
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
            patient_data.bloodPressureSystolicTracker.Add(patient_data.bloodPressureSystolicTracker.Last() + patient_data.bloodPressureSystolicMod);        // Blood Pressure - Systolic
            patient_data.bloodPressureDiastolicTracker.Add(patient_data.bloodPressureDiastolicTracker.Last() + patient_data.bloodPressureDiastolicMod);     // Blood Pressure - Diastolic
            patient_data.breathRateTracker.Add(patient_data.breathRateTracker.Last() + patient_data.breathRateMod);                                         // Breath Rate
            patient_data.capillaryRefillTracker.Add(patient_data.capillaryRefillTracker.Last() + patient_data.capillaryRefillMod);                          // Capillary Refill
            patient_data.glasgowComaScaleTracker.Add(patient_data.glasgowComaScaleTracker.Last() + patient_data.glasgowComaScaleMod);                       // Glasgow Coma Scale
            patient_data.oxygenTracker.Add(patient_data.oxygenTracker.Last() + patient_data.oxygenMod);                                                     // Oxygen
            patient_data.pulseRateTracker.Add(patient_data.pulseRateTracker.Last() + patient_data.pulseRateMod);                                            // Pulse Rate
            patient_data.pupilReactionTracker.Add(patient_data.pupilReactionTracker.Last() + patient_data.pupilReactionMod);                                // Pupil Reaction

            //Debug.Log("DEV - Obs updated for " + patient_data.name);
        }
    }
}
