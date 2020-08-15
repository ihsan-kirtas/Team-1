using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartUIManager : MonoBehaviour
{
    private GameObject gameManager;
    private GameObject chartsMasterPanel;           

    void Start()
    {
        GameEvents.current.event_spacePressed += SpacePressed;                              // SUBSCRIBE to Space Pressed event
        gameManager = GameObject.Find("GameManager");                                       // Find GameManager
        chartsMasterPanel = gameManager.GetComponent<CanvasManager>().chartsMasterPanel;    // Link Chart Master Panel
    }

    private void OnDestroy()
    {
        GameEvents.current.event_spacePressed -= SpacePressed;                              // UN SUBSCRIBE
    }

    void SpacePressed()
    {
        if (chartsMasterPanel.activeSelf)                   // If this is already active
        {
            chartsMasterPanel.SetActive(false);             // Disable Charts Master Panel
            GameEvents.current.CheckCameraLock();           // Checks wheather to Lock / Unlock Camera
        }
        else
        {
            if (GameObject.Find("Player").GetComponent<DialogManager>().currentPatient != null)
            {
                chartsMasterPanel.SetActive(true);          // Activate the Chart Master Panel
                GameEvents.current.CheckCameraLock();       // Checks wheather to Lock / Unlock Camera
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
