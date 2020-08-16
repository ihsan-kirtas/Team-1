using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartUIManager : MonoBehaviour
{
    private GameObject gameManager;
    public GameObject player;
    private GameObject chartsMasterPanel;           

    void Start()
    {
        GameEvents.current.event_spacePressed += SpacePressed;                              // SUBSCRIBE to Space Pressed event
        gameManager = GameObject.Find("GameManager");                                       // Find GameManager
        chartsMasterPanel = gameManager.GetComponent<CanvasManager>().chartsMasterPanel;    // Link Chart Master Panel

        InvokeRepeating("ChartsUpdater", 1f, 0.5f);
    }

    private void OnDestroy()
    {
        GameEvents.current.event_spacePressed -= SpacePressed;                              // UN SUBSCRIBE
    }

    void ChartsUpdater()
    {
        // broadcast event that updates the graphs
        //event_updatePatientData
        GameEvents.current.UpdatePatientData();
    }

    void SpacePressed()
    {
        Debug.Log("ChartUIManager - SpacePressed()");
        if (chartsMasterPanel.activeSelf)                   // If this is already active
        {
            Debug.Log("ChartUIManager - chart master active");
            chartsMasterPanel.SetActive(false);             // Disable Charts Master Panel
            GameEvents.current.CheckCameraLock();           // Checks wheather to Lock / Unlock Camera
        }
        else
        {
            Debug.Log("ChartUIManager - chart master NOT active");
            if (player.GetComponent<DialogManager>().currentPatient != null)
            {
                Debug.Log("ChartUIManager - patient data found");
                chartsMasterPanel.SetActive(true);                                                  // Activate the Chart Master Panel
                chartsMasterPanel.GetComponent<chartsUIPageManager>().SwitchPanel("patient info");  // Open the default page
                GameEvents.current.CheckCameraLock();                                               // Checks wheather to Lock / Unlock Camera
                Debug.Log("ChartUIManager - check cam lock event called");
            }
            else
            {
                StartCoroutine(DisplayNoObsMessage());
            }
        }
    }

    IEnumerator DisplayNoObsMessage()
    {
        gameManager.GetComponent<CanvasManager>().ObsNotAvailableAlert.SetActive(true);     // Show "No Charts" message
        yield return new WaitForSeconds(2);                                                 // Wait 2 secods
        gameManager.GetComponent<CanvasManager>().ObsNotAvailableAlert.SetActive(false);    // Hide Message
    }
}
