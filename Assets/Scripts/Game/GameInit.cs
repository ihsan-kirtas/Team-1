using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{


    private void Awake()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;   // Locks the cursor the the middle of the screen and makes invisible
    }
    // Start is called before the first frame update
    void Start()
    {
        // Check to make sure cursor lock / ui is all good
        GameEvents.current.CheckCameraLock();
    }
}
