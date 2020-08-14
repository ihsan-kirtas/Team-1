using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    // This is used as a master connection point for all UI.
    // Link the panels here once then reference panels here instead of in each script.

    public GameObject dialogueUiPanel;      // Dialogue Main UI
    public GameObject chartsMasterPanel;    // Charts main UI
    public GameObject ObsNotAvailableAlert; // Notifies the player that they need to be near a patient to view their obs
    public GameObject MovePatientPanel;     // Move patient panel
    public GameObject convoAvailablePanel;  // Conversation available popup - "press C for convo"
    public GameObject pauseMenuMasterPanel; // Pause menu panel - Triggered by Esc
    public GameObject pauseMenuHomePage;    // Pause menu child
    public GameObject pauseMenuSettingsPage;// Pause menu child


    private void Start()
    {
        // Hide all panels on start
        dialogueUiPanel.SetActive(false);
        chartsMasterPanel.SetActive(false);
        ObsNotAvailableAlert.SetActive(false);
        //MovePatientPanel.SetActive(false);
        convoAvailablePanel.SetActive(false);
        pauseMenuMasterPanel.SetActive(false);

        GameEvents.current.event_checkCameraLock += CheckLockState;     // Subscribe to check event
    }

    private void OnDestroy()
    {
        GameEvents.current.event_checkCameraLock -= CheckLockState;     // UnSubscribe to event
    }

    // Decides wheather to lock the Camera or not
    void CheckLockState()
    {
        // If there is an active panel
        if(dialogueUiPanel.activeSelf || chartsMasterPanel.activeSelf || pauseMenuMasterPanel.activeSelf)
        {
            // Lock the camera - UI Mode
            GameEvents.current.LockCamera();
        }
        else
        {
            // Unlock the camera - Game Mode
            GameEvents.current.UnlockCamera();
        }
    }
}
