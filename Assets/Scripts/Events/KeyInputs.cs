using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputs : MonoBehaviour
{
    void Update()
    {
        // Pause Menu UI
        if (Input.GetKeyDown("p"))
        {
            GameEvents.current.PPressed();
        }

        // Charts UI
        if (Input.GetKeyDown("space"))
        {
            GameEvents.current.SpacePressed();
        }

        // Start Convo - open dialogue box
        if (Input.GetKeyDown("c"))
        {
            GameEvents.current.CPressed();
        }
    }
}

