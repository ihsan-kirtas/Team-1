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
    // Then bradcast the event "onUIActivated"
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
    // Then bradcast the event "onUIActivated"
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
    // Then bradcast the event "onDemoEvent"
    public event Action onDemoEvent;
}
