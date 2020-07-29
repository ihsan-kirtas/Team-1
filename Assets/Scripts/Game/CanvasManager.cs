using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    // This is used as a master connection point for all UI.
    // Link the panels here once then reference panels here instead of in each script.


    // Dialogue Main UI
    public GameObject dialogueUiPanel;

    // Charts main UI
    public GameObject chartsMasterPanel;

    // Notifies the player that they need to be near a patient to view their obs
    public GameObject ObsNotAvailableAlert;

    // Move patient panel
    public GameObject MovePatientPanel;

    private void Start()
    {
        // Hide panels on start
        //dialogueUiPanel.SetActive(false);
        //chartsMasterPanel.SetActive(false);
        //ObsNotAvailableAlert.SetActive(false);
        MovePatientPanel.SetActive(false);
    }
}
