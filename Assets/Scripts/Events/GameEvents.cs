using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial: https://www.youtube.com/watch?v=gx0Lt4tCDE0

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this; 
    }


    // -- DEMO EVENT --
    // First check that onDemoEvent != null
    public void DemoEvent()
    {
        if (onDemoEvent != null)
        {
            onDemoEvent();
        }
    }
    // Then broadcast the event "onDemoEvent"
    public event Action onDemoEvent;




    // ---------------- Application Events -----------------------------------------------------------------

    // Close Application
    public void CloseApplication()
    {
        if (event_closeApplication != null) { event_closeApplication(); }
    }
    public event Action event_closeApplication;


    // ---------------- Scene Change Events -----------------------------------------------------------------

    // Start Menu
    public void SceneChangeStartMenu()
    {
        if (event_sceneChangeStartMenu != null) { event_sceneChangeStartMenu(); }
    }
    public event Action event_sceneChangeStartMenu;


    // Main Scene
    public void SceneChangeMain()
    {
        if (event_sceneChangeMain != null) { event_sceneChangeMain(); }
    }
    public event Action event_sceneChangeMain;


    // Tutorial
    public void SceneChangeTutorial()
    {
        if (event_sceneChangeTutorial != null) { event_sceneChangeTutorial(); }
    }
    public event Action event_sceneChangeTutorial;





    // ---------------- Game Events -----------------------------------------------------------------

    // Update Patient Data
    public void UpdatePatientData()
    {
        if (event_updatePatientData != null) { event_updatePatientData(); }
    }
    public event Action event_updatePatientData;



    // Pause Game
    public void PauseGame()
    {
        if (event_pauseGame != null) { event_pauseGame(); }
    }
    public event Action event_pauseGame;


    // Resume Game
    public void ResumeGame()
    {
        if (event_resumeGame != null) { event_resumeGame(); }
    }
    public event Action event_resumeGame;


    // ---------------- UI Events -----------------------------------------------------------------

    // Charts UI - Show
    public void ShowChartUI(){
        if (event_showChartUI != null){ event_showChartUI();}
    }
    public event Action event_showChartUI;


    // Charts UI - Hide
    public void HideChartUI()
    {
        if (event_hideChartUI != null) { event_hideChartUI(); }
    }
    public event Action event_hideChartUI;


    // Dialogue UI - Show
    public void ShowDialogueUI()
    {
        if (event_showDialogueUI != null) { event_showDialogueUI(); }
    }
    public event Action event_showDialogueUI;


    // Dialogue UI - Hide
    public void HideDialogueUI()
    {
        if (event_hideDialogueUI != null) { event_hideDialogueUI(); }
    }
    public event Action event_hideDialogueUI;

    // Pause Menu - Show
    public void ShowPauseMenuUI()
    {
        if (event_showPauseMenuUI != null) { event_showPauseMenuUI(); }
    }
    public event Action event_showPauseMenuUI;


    // Pause Menu - Hide
    public void HidePauseMenuUI()
    {
        if (event_hidePauseMenuUI != null) { event_hidePauseMenuUI(); }
    }
    public event Action event_hidePauseMenuUI;

    // ---------------- Player Events -----------------------------------------------------------------

    // Player entered Ambulance Bay
    public void PlayerEnteredAmbulanceBay()
    {
        if (event_playerEnteredAmbulanceBay != null) { event_playerEnteredAmbulanceBay(); }
    }
    public event Action event_playerEnteredAmbulanceBay;


    // Player entered Beds Area
    public void PlayerEnteredBedsArea()
    {
        if (event_playerEnteredBedsArea != null) { event_playerEnteredBedsArea(); }
    }
    public event Action event_playerEnteredBedsArea;


    // Player entered Resus 1
    public void PlayerEnteredResus1()
    {
        if (event_playerEnteredResus1 != null) { event_playerEnteredResus1(); }
    }
    public event Action event_playerEnteredResus1;


    // Player entered Resus 2
    public void PlayerEnteredResus2()
    {
        if (event_playerEnteredResus2 != null) { event_playerEnteredResus2(); }
    }
    public event Action event_playerEnteredResus2;


    // Player entered Hallway
    public void PlayerEnteredHallway()
    {
        if (event_playerEnteredHallway != null) { event_playerEnteredHallway(); }
    }
    public event Action event_playerEnteredHallway;



    // ---------------- Patient Events -----------------------------------------------------------------

    // Spawn Next Patient
    public void SpawnNextPatient()
    {
        if (event_spawnNextPatient != null) { event_spawnNextPatient(); }
    }
    public event Action event_spawnNextPatient;


    // Patient Spawned
    public void PatientSpawned()
    {
        if (event_patientSpawned != null) { event_patientSpawned(); }
    }
    public event Action event_patientSpawned;


    // Patient Moved to Beds
    public void MovePatientToBeds()
    {
        if (event_movePatientToBeds != null) { event_movePatientToBeds(); }
    }
    public event Action event_movePatientToBeds;


    // Patient Moved to Resus Bay 1
    public void MovePatientToResus1()
    {
        if (event_movePatientToResus1 != null) { event_movePatientToResus1(); }
    }
    public event Action event_movePatientToResus1;


    // Patient Moved to Resus Bay 2
    public void MovePatientToResus2()
    {
        if (event_movePatientToResus2 != null) { event_movePatientToResus2(); }
    }
    public event Action event_movePatientToResus2;



    // ---------------- Dialogue Events -----------------------------------------------------------------

    // --- Patient 1 Start / End Convo ---
    public void StartContactPatient1()
    {
        if (event_startContactPatient1 != null) { event_startContactPatient1(); }
    }
    public event Action event_startContactPatient1;

    public void EndContactPatient1()
    {
        if (event_endContactPatient1 != null) { event_endContactPatient1(); }
    }
    public event Action event_endContactPatient1;


    // --- Patient 2 Start / End Convo ---
    public void StartContactPatient2()
    {
        if (event_startContactPatient2 != null) { event_startContactPatient2(); }
    }
    public event Action event_startContactPatient2;

    public void EndContactPatient2()
    {
        if (event_endContactPatient2 != null) { event_endContactPatient2(); }
    }
    public event Action event_endContactPatient2;


    // --- Patient 3 Start / End Convo ---
    public void StartContactPatient3()
    {
        if (event_startContactPatient3 != null) { event_startContactPatient3(); }
    }
    public event Action event_startContactPatient3;

    public void EndContactPatient3()
    {
        if (event_endContactPatient3 != null) { event_endContactPatient3(); }
    }
    public event Action event_endContactPatient3;


    // --- Patient 1 Start / End Convo ---
    public void StartContactPatient4()
    {
        if (event_startContactPatient4 != null) { event_startContactPatient4(); }
    }
    public event Action event_startContactPatient4;

    public void EndContactPatient4()
    {
        if (event_endContactPatient4 != null) { event_endContactPatient4(); }
    }
    public event Action event_endContactPatient4;


    // --- Patient 1 Start / End Convo ---
    public void StartContactPatient5()
    {
        if (event_startContactPatient5 != null) { event_startContactPatient5(); }
    }
    public event Action event_startContactPatient5;

    public void EndContactPatient5()
    {
        if (event_endContactPatient5 != null) { event_endContactPatient5(); }
    }
    public event Action event_endContactPatient5;





    // -- C pressed (Show Conversation) --
    public void CPressed()
    {
        if (event_CPressed != null) { event_CPressed(); }
    }
    public event Action event_CPressed;

    public void CheckCameraLock()  // Makes decision wherater to lock camera or not
    {
        if (event_checkCameraLock != null) { event_checkCameraLock(); }
    }
    public event Action event_checkCameraLock;

    // -- Lock / Unlock UI --
    public void LockCamera()    // For UI Mode
    {
        if (event_lockCamera != null) { event_lockCamera(); }
    }
    public event Action event_lockCamera;

    public void UnlockCamera()  // For Game Mode
    {
        if (event_unlockCamera != null) { event_unlockCamera(); }
    }
    public event Action event_unlockCamera;



}
