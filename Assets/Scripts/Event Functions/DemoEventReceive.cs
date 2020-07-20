using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoEventReceive : MonoBehaviour
{
    private void Start()
    {
        // Subscribe to event Action "onDemoEvent", set function to execute.
        GameEvents.current.onDemoEvent += DoSomething;
    }

    private void OnDestroy()
    {
        // Unsubscribe to events
        GameEvents.current.onDemoEvent -= DoSomething;
    }

    private void DoSomething()
    {
        Debug.Log("EVENT RECEIVED - onDemoEvent");
    }

}
