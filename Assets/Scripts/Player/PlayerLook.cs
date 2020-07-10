using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Initially based on tutorial: https://www.youtube.com/watch?v=n-KX8AeGK7E
 */

public class PlayerLook : MonoBehaviour
{
    // Set input names
    [SerializeField] private string mouseXInputName = "Mouse X";
    [SerializeField] private string mouseYInputName = "Mouse Y";

    [SerializeField] private float mouseSensitivity = 150;

    // Parent's body transform
    private Transform playerBody;

    // Locks camera position while viewing UI
    private bool moveCamera;

    // Stop looking too high or low
    private float xAxisClamp;


    private void Awake()
    {
        playerBody = this.transform.parent;         // Attach parent's transform on script run
        ActivateGameCamera();
        xAxisClamp = 0.0f;
    }

    private void Start()
    {
        // Subscribe to event Action "onUIActivated" - If received call ActivateUICamera()
        GameEvents.current.onUIActivated += ActivateUICamera;
        GameEvents.current.onUIDeactivated += ActivateGameCamera;
    }

    private void OnDestroy()
    {
        // Unsubscribe to events
        GameEvents.current.onUIActivated -= ActivateUICamera;
        GameEvents.current.onUIDeactivated -= ActivateGameCamera;
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
