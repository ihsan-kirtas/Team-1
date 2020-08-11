using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Events;

public class ChartUIManager : MonoBehaviour
{
    private GameObject chartsMasterPanel;

    [Header("System / debug")]
    private Patient_Data current_patient_data;
    public bool viewingChart = true;


    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to events
        GameEvents.current.event_showChartUI += ShowChartsUI;    // Show Charts UI
        GameEvents.current.event_hideChartUI += HideChartsUI;    // Hide Charts UI

        // link to charts panel
        chartsMasterPanel = GameObject.Find("GameManager").GetComponent<CanvasManager>().chartsMasterPanel;

        viewingChart = false;
        chartsMasterPanel.SetActive(false);
    }

    private void OnDestroy()
    {
        // Unsubscribe to events
        GameEvents.current.event_showChartUI -= ShowChartsUI;
        GameEvents.current.event_hideChartUI -= HideChartsUI;
    }


    void ShowChartsUI()
    {
        current_patient_data = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;

        // Toggle viewing chart bool
        viewingChart = true;

        chartsMasterPanel.SetActive(true);
        
    }

    void HideChartsUI()
    {
        // Toggle viewing chart bool
        viewingChart = false;
        chartsMasterPanel.SetActive(false);

        current_patient_data = null;
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
