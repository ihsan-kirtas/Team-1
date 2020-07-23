using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Events;

public class ChartUIManager : MonoBehaviour
{
    [Header("Settings")]
    public float updateFrequency = 1.0f;

    [Header("Tracker strings")]
    public Text bloodPressureSTracker;
    public Text bloodPressureDTracker;
    public Text breathRateTracker;
    public Text capillaryRefillTracker;
    public Text glasgowComaScaleTracker;
    public Text oxygenTracker;
    public Text pulseRateTracker;
    public Text pupilReactionTracker;

    [Header("Current Values")]
    public Text bloodPressureSCurrent;
    public Text bloodPressureDCurrent;
    public Text breathRateCurrent;
    public Text capillaryRefillCurrent;
    public Text glasgowComaScaleCurrent;
    public Text oxygenCurrent;
    public Text pulseRateCurrent;
    public Text pupilReactionCurrent;

    [Header("Other")]
    public GameObject chartsMasterPanel;

    [Header("System")]
    public Patient_Data patient_data;
    public bool viewingChart = true;


    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to events
        GameEvents.current.event_showChartUI += ShowChartsUI;    // Show Charts UI
        GameEvents.current.event_hideChartUI += HideChartsUI;    // Hide Charts UI

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
    }

    private void LinkObjects()
    {

        // Activate UI to allow linking
        chartsMasterPanel.SetActive(true);

        // Text
        bloodPressureSTracker = GameObject.Find("Blood Pressure - S Title").GetComponent<Text>();



        //bloodPressureSTracker = GameObject.Find("ChartsMasterPanel/ObsChartPanel/ObsDataTrackers/Blood Pressure - S Tracker").GetComponent<Text>();
        //bloodPressureSTracker = GameObject.FindObjectsOfTypeAll(typeof(GameObject))("Blood Pressure - S Tracker1").GetComponent<Text>();
        //Text cameraLabel = GameObject.Find("Canvas/Camera Label").GetComponent[UnityEngine.UI.Text]();
        //Text cameraLabel = GameObject.Find("Canvas/Camera Label").GetComponent<Text>();



        //        bloodPressureDTracker;
        //breathRateTracker;
        //capillaryRefillTracker;
        //glasgowComaScaleTracker;
        //oxygenTracker;
        //pulseRateTracker;
        //pupilReactionTracker;

        //bloodPressureSCurrent;
        //bloodPressureDCurrent;
        //breathRateCurrent;
        //capillaryRefillCurrent;
        //glasgowComaScaleCurrent;
        //oxygenCurrent;
        //pulseRateCurrent;
        //pupilReactionCurrent;

        //        // Panel
        //        bloodPressureSTracker = GameObject.Find("Blood Pressure - S Title").GetComponent<Text>();
        //chartsMasterPanel;

        // Deactivate UI after linking
        chartsMasterPanel.SetActive(false);

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
        if(patient_data != null && viewingChart)
        {
            updateValues();
        }
    }

    public void updateValues()
    {
        // Tracker strings
        bloodPressureSTracker.text = generateTrackerString(patient_data.bloodPressureSystolicTracker);  // Blood Pressure - S
        bloodPressureDTracker.text = generateTrackerString(patient_data.bloodPressureDiastolicTracker); // Blood Pressure - D
        breathRateTracker.text = generateTrackerString(patient_data.breathRateTracker);                 // Breath Rate
        capillaryRefillTracker.text = generateTrackerString(patient_data.capillaryRefillTracker);       // Capillary Refill
        glasgowComaScaleTracker.text = generateTrackerString(patient_data.glasgowComaScaleTracker);     // Glasgow Coma Scale
        oxygenTracker.text = generateTrackerString(patient_data.oxygenTracker);                         // Oxygen
        pulseRateTracker.text = generateTrackerString(patient_data.pulseRateTracker);                   // Pulse Rate
        pupilReactionTracker.text = generateTrackerString(patient_data.pupilReactionTracker);           // Pupil Reaction

        // Current Values
        bloodPressureSCurrent.text = System.Math.Round(patient_data.bloodPressureSystolicTracker.Last(), 1).ToString();       // Blood Pressure - S
        bloodPressureDCurrent.text = System.Math.Round(patient_data.bloodPressureDiastolicTracker.Last(), 1).ToString();      // Blood Pressure - D
        breathRateCurrent.text = System.Math.Round(patient_data.breathRateTracker.Last(), 1).ToString();                     // Breath Rate
        capillaryRefillCurrent.text = System.Math.Round(patient_data.capillaryRefillTracker.Last(), 1).ToString();          // Capillary Refill
        glasgowComaScaleCurrent.text = System.Math.Round(patient_data.glasgowComaScaleTracker.Last(), 1).ToString();         // Glasgow Coma Scale
        oxygenCurrent.text = System.Math.Round(patient_data.oxygenTracker.Last(), 1).ToString();                              // Oxygen
        pulseRateCurrent.text = System.Math.Round(patient_data.pulseRateTracker.Last(), 1).ToString();                       // Pulse Rate
        pupilReactionCurrent.text = System.Math.Round(patient_data.pupilReactionTracker.Last(), 1).ToString();               // Pupil Reaction
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
