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





                            // -- DELETE ME ---
                            // -- Update the charts --
                            // First check that onDemoEvent != null
                            public void ChartUpdate()
                            {
                                if (onChartUpdate != null)
                                {
                                    onChartUpdate();
                                }
                            }
                            // Then broadcast the event
                            public event Action onChartUpdate;



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






                        // - DELETE ME --
                        // -- UI Deactivated Event --
                        // First check that onUIActivated != null
                        public void UIDeactivated()
                        {
                            if (onUIDeactivated != null)
                            {
                                onUIDeactivated();
                            }
                        }
                        // Then broadcast the event "onUIActivated"
                        public event Action onUIDeactivated;


                        // - DELETE ME --
                        // -- UI Activated Event --
                        // First check that onUIActivated != null
                        public void UIActivated()
                        {
                            if (onUIActivated != null)
                            {
                                onUIActivated();
                            }
                        }
                        // Then broadcast the event "onUIActivated"
                        public event Action onUIActivated;



    // ---------------- Patient Events -----------------------------------------------------------------

    // Spawn Next Patient
    public void SpawnNextPatient()
    {
        if (event_spawnNextPatient != null) { event_spawnNextPatient(); }
    }
    public event Action event_spawnNextPatient;

    
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
}
