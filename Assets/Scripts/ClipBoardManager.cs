using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Events;

public class ClipBoardManager : MonoBehaviour
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
    public GameObject clipBoardPanel;

    [Header("System")]
    public Patient_Data patient_data;
    public bool viewingChart = true;

    // Dialog Event
    public UnityEvent start_clipboardUI;


    private void OnEnable()
    {
        // Subscribe to events - Clip Board UI
        GameEvents.current.onUIActivated += ShowClipBoardUI;
        GameEvents.current.onUIDeactivated += HideClipBoardUI;
    }
    private void OnDisable()
    {
        // Unsubscribe to events - Clip Board UI
        GameEvents.current.onUIActivated -= ShowClipBoardUI;
        GameEvents.current.onUIDeactivated -= HideClipBoardUI;
    }




    // Start is called before the first frame update
    void Start()
    {
        viewingChart = false;
        clipBoardPanel.SetActive(false);

        // Repeat Function - (FunctionName, Start Delay, Repeat every)
        InvokeRepeating("ClipBoardProcessor", 0.0f, updateFrequency);
    }

    // Update is called once per frame
    void Update()
    {
        // Toggles clip board UI on space bar
        if (Input.GetKeyDown("space"))
        {
            if (!viewingChart)
            {
                GameEvents.current.UIActivated();                     // EVENT Broadcast - Clip Board UI opened
            }
            else
            {
                GameEvents.current.UIDeactivated();                   // EVENT Broadcast - Clip Board UI closed
            }
        }
    }



     void ShowClipBoardUI()
    {
        // Toggle viewing chart bool
        viewingChart = true;
        clipBoardPanel.SetActive(true);
    }

    void HideClipBoardUI()
    {
        // Toggle viewing chart bool
        viewingChart = false;
        clipBoardPanel.SetActive(false);
    }

    void ClipBoardProcessor()
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
