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

    // UI Activated
    public event Action onUIActivated;
    public void UIActivated()
    {
        if (onUIActivated != null)
        {
            onUIActivated();
        }
    }

    // UI Deactivated
    public event Action onUIDeactivated;
    public void UIDeactivated()
    {
        if (onUIDeactivated != null)
        {
            onUIDeactivated();
        }
    }
}
