using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoEventBroadcast : MonoBehaviour
{
    void Update()
    {
        // If X is pressed, call a function in the GameEvents.cs (attached to GameManager Object)
        if (Input.GetKeyDown("x"))
        {
            GameEvents.current.DemoEvent();
        }
    }
}
