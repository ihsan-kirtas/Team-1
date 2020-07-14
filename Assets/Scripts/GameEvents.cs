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


    // -- Close Application - Exit Game --
    public void CloseApplication()
    {
        if (onCloseApplication != null)
        {
            onCloseApplication();
        }
    }
    // Broadcast the event
    public event Action onCloseApplication;


    //--------------------------------------------
    // -- SCENE CHANGES --
    //--------------------------------------------


    // -- Go to Start Menu --
    public void GoToStartMenu()
    {
        if (onGoToStartMenu != null)
        {
            onGoToStartMenu();
        }
    }
    // Broadcast the event
    public event Action onGoToStartMenu;



    // -- Go to Tutorial --
    public void GoToTutorial()
    {
        if (onGoToTutorial != null)
        {
            onGoToTutorial();
        }
    }
    // Broadcast the event
    public event Action onGoToTutorial;



    // -- Go to main scene --
    public void GoToMainScene()
    {
        if (onGoToMainScene != null)
        {
            onGoToMainScene();
        }
    }
    // Broadcast the event
    public event Action onGoToMainScene;

}
