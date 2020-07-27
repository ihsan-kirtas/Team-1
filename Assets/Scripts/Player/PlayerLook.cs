using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Initially based on tutorial: https://www.youtube.com/watch?v=n-KX8AeGK7E
 */

public class PlayerLook : MonoBehaviour
{
    // Set input names
    private string mouseXInputName = "Mouse X";
    private string mouseYInputName = "Mouse Y";

    private float mouseSensitivity = 150;

    // Parent's body transform
    private Transform playerBody;

    // Locks camera position while viewing UI
    private bool moveCamera;

    // Stop looking too high or low
    private float xAxisClamp;


    private GameObject dialogPanel;
    private GameObject chartsMasterPanel;


    private void Awake()
    {
        playerBody = this.transform.parent;         // Attach parent's transform on script run
        ActivateGameCamera();
        xAxisClamp = 0.0f;
    }

    private void Start()
    {
        // Subscribe to events

        // Camera - Activate UI Mode
        //GameEvents.current.event_showChartUI += ActivateUICamera;           // Chart UI
        GameEvents.current.event_showDialogueUI += ActivateUICamera;        // Dialogue UI
        GameEvents.current.event_showPauseMenuUI += ActivateUICamera;       // Pause Menu UI

        // Camera - Activate Game Mode
        //GameEvents.current.event_hideChartUI += ActivateGameCamera;         // Chart UI
        GameEvents.current.event_hideDialogueUI += ActivateGameCamera;      // Dialogue UI
        GameEvents.current.event_hidePauseMenuUI += ActivateGameCamera;     // Pause Menu UI

        // link panels
        dialogPanel = GameObject.Find("GameManager").GetComponent<CanvasManager>().dialogueUiPanel;
        chartsMasterPanel = GameObject.Find("GameManager").GetComponent<CanvasManager>().chartsMasterPanel;

        // set cursor and cam to game mode
        moveCamera = true;
        Cursor.lockState = CursorLockMode.Locked;   // Locks the cursor the the middle of the screen

    }

    private void OnDestroy()
    {
        // Unsubscribe to events - OLD
        //GameEvents.current.onUIActivated -= ActivateUICamera;
        //GameEvents.current.onUIDeactivated -= ActivateGameCamera;



        // Camera - Activate UI Mode
        //GameEvents.current.event_showChartUI -= ActivateUICamera;           // Chart UI
        GameEvents.current.event_showDialogueUI -= ActivateUICamera;        // Dialogue UI
        GameEvents.current.event_showPauseMenuUI -= ActivateUICamera;       // Pause Menu UI

        // Camera - Activate Game Mode
        //GameEvents.current.event_hideChartUI -= ActivateGameCamera;         // Chart UI
        GameEvents.current.event_hideDialogueUI -= ActivateGameCamera;      // Dialogue UI
        GameEvents.current.event_hidePauseMenuUI -= ActivateGameCamera;     // Pause Menu UI
    }

    // Switch camera mode to Game
    void ActivateGameCamera()
    {   

        //Debug.Log("GAME CAMERA SETTIGS");
        moveCamera = true;
        Cursor.lockState = CursorLockMode.Locked;   // Locks the cursor the the middle of the screen


    }


    // Switch camera mode to UI
    void ActivateUICamera()
    {
        //Debug.Log("UI CAMERA SETTINGS");
        moveCamera = false;
        Cursor.lockState = CursorLockMode.None;   // Unlocks the cursor for UI buttons
    }



    private void Update()
    {
        if (moveCamera)
        {
            CameraRotation();
        }
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;


        // Clamp look angles
        xAxisClamp += mouseY;

        if(xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        // Vertical
        transform.Rotate(Vector3.left * mouseY);

        // Horizontal
        playerBody.Rotate(Vector3.up * mouseX);
    }

    // Stops the camera rotation from exceeding the clamp on X (up and down)
    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
