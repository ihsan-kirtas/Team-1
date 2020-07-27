using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Events;

public class ChartUIManager : MonoBehaviour
{
    [Header("Refresh rate")]
    public float updateFrequency = 1.0f;

    
    private Text bloodPressureSTracker;
    private Text bloodPressureDTracker;
    private Text breathRateTracker;
    private Text capillaryRefillTracker;
    private Text glasgowComaScaleTracker;
    private Text oxygenTracker;
    private Text pulseRateTracker;
    private Text pupilReactionTracker;


    private Text bloodPressureSCurrent;
    private Text bloodPressureDCurrent;
    private Text breathRateCurrent;
    private Text capillaryRefillCurrent;
    private Text glasgowComaScaleCurrent;
    private Text oxygenCurrent;
    private Text pulseRateCurrent;
    private Text pupilReactionCurrent;

    [Header("Other")]
    public GameObject chartsMasterPanel;

    [Header("System / debug")]


    public Patient_Data current_patient_data;
    public bool viewingChart = true;





    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to events
        GameEvents.current.event_showChartUI += ShowChartsUI;    // Show Charts UI
        GameEvents.current.event_hideChartUI += HideChartsUI;    // Hide Charts UI



        // Tap into StartCvonvo events to swap the current patient data
        GameEvents.current.event_startConvoPatient1 += LoadPatient1Data;
        GameEvents.current.event_startConvoPatient2 += LoadPatient2Data;
        GameEvents.current.event_startConvoPatient3 += LoadPatient3Data;
        GameEvents.current.event_startConvoPatient4 += LoadPatient4Data;
        GameEvents.current.event_startConvoPatient5 += LoadPatient5Data;

        GameEvents.current.event_endConvoPatient1 += UnloadAllPatientData;
        GameEvents.current.event_endConvoPatient2 += UnloadAllPatientData;
        GameEvents.current.event_endConvoPatient3 += UnloadAllPatientData;
        GameEvents.current.event_endConvoPatient4 += UnloadAllPatientData;
        GameEvents.current.event_endConvoPatient5 += UnloadAllPatientData;



        // Link all of the UI text etc, keeps the inspector cleaner.
        LinkObjects();

        viewingChart = false;
        chartsMasterPanel.SetActive(false);

        // Repeat Function - (FunctionName, Start Delay, Repeat every)
        InvokeRepeating("ChartsProcessor", 0.0f, updateFrequency);
    }

    private void OnDestroy()
    {
        // Unsubscribe to events
        GameEvents.current.event_showChartUI -= ShowChartsUI;
        GameEvents.current.event_hideChartUI -= HideChartsUI;


        // Tap into StartCvonvo events to swap the current patient data
        GameEvents.current.event_startConvoPatient1 -= LoadPatient1Data;
        GameEvents.current.event_startConvoPatient2 -= LoadPatient2Data;
        GameEvents.current.event_startConvoPatient3 -= LoadPatient3Data;
        GameEvents.current.event_startConvoPatient4 -= LoadPatient4Data;
        GameEvents.current.event_startConvoPatient5 -= LoadPatient5Data;

        GameEvents.current.event_endConvoPatient1 -= UnloadAllPatientData;
        GameEvents.current.event_endConvoPatient2 -= UnloadAllPatientData;
        GameEvents.current.event_endConvoPatient3 -= UnloadAllPatientData;
        GameEvents.current.event_endConvoPatient4 -= UnloadAllPatientData;
        GameEvents.current.event_endConvoPatient5 -= UnloadAllPatientData;
    }

    private void LinkObjects()
    {

        // Activate UI to allow linking
        chartsMasterPanel.SetActive(true);

        // Text Link Trackers
        bloodPressureSTracker = GameObject.Find("Obs Blood Pressure - S Tracker").GetComponent<Text>();
        bloodPressureDTracker = GameObject.Find("Obs Blood Pressure - D Tracker").GetComponent<Text>();
        breathRateTracker = GameObject.Find("Obs Breath Rate Tracker").GetComponent<Text>();
        capillaryRefillTracker = GameObject.Find("Obs Capillary Refill Tracker").GetComponent<Text>();
        glasgowComaScaleTracker = GameObject.Find("Obs Glasgow Coma Scale Tracker").GetComponent<Text>();
        oxygenTracker = GameObject.Find("Obs Oxygen Tracker").GetComponent<Text>();
        pulseRateTracker = GameObject.Find("Obs Pulse Rate Tracker").GetComponent<Text>();
        pupilReactionTracker = GameObject.Find("Obs Pupil Reaction Tracker").GetComponent<Text>();

        // Text link current values
        bloodPressureSCurrent = GameObject.Find("Obs Blood Pressure - S Current").GetComponent<Text>();
        bloodPressureDCurrent = GameObject.Find("Obs Blood Pressure - D Current").GetComponent<Text>();
        breathRateCurrent = GameObject.Find("Obs Breath Rate Current").GetComponent<Text>();
        capillaryRefillCurrent = GameObject.Find("Obs Capillary Refill Current").GetComponent<Text>();
        glasgowComaScaleCurrent = GameObject.Find("Obs Glasgow Coma Scale Current").GetComponent<Text>();
        oxygenCurrent = GameObject.Find("Obs Oxygen Current").GetComponent<Text>();
        pulseRateCurrent = GameObject.Find("Obs Pulse Rate Current").GetComponent<Text>();
        pupilReactionCurrent = GameObject.Find("Obs Pupil Reaction Current").GetComponent<Text>();


        // Deactivate UI after linking
        chartsMasterPanel.SetActive(false);

    }


    void LoadPatient1Data()
    {
        current_patient_data = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;
    }
    void LoadPatient2Data()
    {
        current_patient_data = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;
    }
    void LoadPatient3Data()
    {
        current_patient_data = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;
    }
    void LoadPatient4Data()
    {
        current_patient_data = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;
    }
    void LoadPatient5Data()
    {
        current_patient_data = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;
    }

    void UnloadAllPatientData()
    {
        current_patient_data = null;
    }


    void ShowChartsUI()
    {

        // Toggle viewing chart bool
        viewingChart = true;

        chartsMasterPanel.SetActive(true);

    }

    void HideChartsUI()
    {
        // Toggle viewing chart bool
        viewingChart = false;
        chartsMasterPanel.SetActive(false);
    }

    void ChartsProcessor()
    {
        if(current_patient_data != null && viewingChart)
        {
            updateValues();
        }
    }

    public void updateValues()
    {
        // Tracker strings
        bloodPressureSTracker.text = generateTrackerString(current_patient_data.bloodPressureSystolicTracker);  // Blood Pressure - S
        bloodPressureDTracker.text = generateTrackerString(current_patient_data.bloodPressureDiastolicTracker); // Blood Pressure - D
        breathRateTracker.text = generateTrackerString(current_patient_data.breathRateTracker);                 // Breath Rate
        capillaryRefillTracker.text = generateTrackerString(current_patient_data.capillaryRefillTracker);       // Capillary Refill
        glasgowComaScaleTracker.text = generateTrackerString(current_patient_data.glasgowComaScaleTracker);     // Glasgow Coma Scale
        oxygenTracker.text = generateTrackerString(current_patient_data.oxygenTracker);                         // Oxygen
        pulseRateTracker.text = generateTrackerString(current_patient_data.pulseRateTracker);                   // Pulse Rate
        pupilReactionTracker.text = generateTrackerString(current_patient_data.pupilReactionTracker);           // Pupil Reaction

        // Current Values
        bloodPressureSCurrent.text = System.Math.Round(current_patient_data.bloodPressureSystolicTracker.Last(), 1).ToString();       // Blood Pressure - S
        bloodPressureDCurrent.text = System.Math.Round(current_patient_data.bloodPressureDiastolicTracker.Last(), 1).ToString();      // Blood Pressure - D
        breathRateCurrent.text = System.Math.Round(current_patient_data.breathRateTracker.Last(), 1).ToString();                     // Breath Rate
        capillaryRefillCurrent.text = System.Math.Round(current_patient_data.capillaryRefillTracker.Last(), 1).ToString();          // Capillary Refill
        glasgowComaScaleCurrent.text = System.Math.Round(current_patient_data.glasgowComaScaleTracker.Last(), 1).ToString();         // Glasgow Coma Scale
        oxygenCurrent.text = System.Math.Round(current_patient_data.oxygenTracker.Last(), 1).ToString();                              // Oxygen
        pulseRateCurrent.text = System.Math.Round(current_patient_data.pulseRateTracker.Last(), 1).ToString();                       // Pulse Rate
        pupilReactionCurrent.text = System.Math.Round(current_patient_data.pupilReactionTracker.Last(), 1).ToString();               // Pupil Reaction
    }

    string generateTrackerString(List<float> tracker)
    {
        string return_str = "";
        foreach (float ob in tracker)
        {
            return_str += System.Math.Round(ob).ToString() + " | ";
        }
        return return_str;
    }

}
