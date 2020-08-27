using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitWipePatients : MonoBehaviour
{
    public List<Patient_Data> patientDatas;

    private void Start()
    {
        foreach (Patient_Data currentPatientData in patientDatas)
        {
            WipeAndInit(currentPatientData);
        }
        //Debug.Log("All patients wiped");
    }

    // wipe lists and fill with the init value
    void WipeAndInit(Patient_Data currentPatientData)
    {
        currentPatientData.breathRateTracker.Clear();
        currentPatientData.breathRateTracker.Add(currentPatientData.breathRateInit);

        currentPatientData.oxygenTracker.Clear();
        currentPatientData.oxygenTracker.Add(currentPatientData.oxygenInit);

        currentPatientData.bloodPressureDiastolicTracker.Clear();
        currentPatientData.bloodPressureDiastolicTracker.Add(currentPatientData.bloodPressureDiastolicInit);

        currentPatientData.bloodPressureSystolicTracker.Clear();
        currentPatientData.bloodPressureSystolicTracker.Add(currentPatientData.bloodPressureSystolicInit);

        currentPatientData.bloodPressureSystolicTracker.Clear();
        currentPatientData.bloodPressureSystolicTracker.Add(currentPatientData.bloodPressureSystolicInit);

        currentPatientData.pulseRateTracker.Clear();
        currentPatientData.pulseRateTracker.Add(currentPatientData.pulseRateInit);

        currentPatientData.tempTracker.Clear();
        currentPatientData.tempTracker.Add(currentPatientData.tempInit);
    }
}
