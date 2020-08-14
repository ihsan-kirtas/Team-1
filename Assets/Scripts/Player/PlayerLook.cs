using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Initially based on tutorial: https://www.youtube.com/watch?v=n-KX8AeGK7E
 */

public class PlayerLook : MonoBehaviour
{
    private string mouseXInputName = "Mouse X";     // For Input
    private string mouseYInputName = "Mouse Y";     // For Input
    private float mouseSensitivity = 150;           // Mouse sensitivity
    private float xAxisClamp;                       // Stop looking too high or low

    private Transform playerBody;                   // Parent's body transform

    private bool moveCamera;                        // Controls wheather to move or lock camera on update

    private void Awake()
    {
        playerBody = this.transform.parent;         // Attach parent's transform on script run
        UnlockCamera();                             // Unlock camera for start of game
        xAxisClamp = 0.0f;
    }

    private void Start()
    {
        // Lock / Unlock UI
        // These events are broadcasted from the CanvasManager script
        GameEvents.current.event_lockCamera += LockCamera;          // Lock UI - UI Mode
        GameEvents.current.event_unlockCamera += UnlockCamera;      // Unlock UI - Game Mode
    }

    private void OnDestroy()
    {
        // Lock / Unlock UI
        GameEvents.current.event_lockCamera -= LockCamera;          // Lock UI - UI Mode
        GameEvents.current.event_unlockCamera -= UnlockCamera;      // Unlock UI - Game Mode
    }

    private void Update()
    {
        if (moveCamera){ CameraRotation(); }    // Apply camera rotations if allowed
    }

    void LockCamera()       //UI Mode
    {
        moveCamera = false;                         // Locks the camera in one position
        Cursor.lockState = CursorLockMode.None;     // Enables the cursor for UI, makes visible
    }

    void UnlockCamera()     // Game Mode
    {
        moveCamera = true;                          // Allow the camera to move
        Cursor.lockState = CursorLockMode.Locked;   // Locks the cursor the the middle of the screen and makes invisible
    }

    // Camera rotation controller
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
