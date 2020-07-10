using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName = "Horizontal";
    [SerializeField] private string verticalInputName = "Vertical";

    [SerializeField] private float movementSpeed = 6;

    private CharacterController charController;

    // Lock player movement when UI visible
    public bool moveBody;

    //HACK to close all panels on game camera
    public GameObject dialogPanel;
    public GameObject ClipBoardPanel;


    private void Awake()
    {
        // Gets the Character controller on this object.
        charController = GetComponent<CharacterController>();
        ActivateGameMovement();
    }

    private void Start()
    {
        // Subscribe to event Action "onUIActivated" - If received call ActivateUIMovement()
        GameEvents.current.onUIActivated += ActivateUIMovement;
        GameEvents.current.onUIDeactivated += ActivateGameMovement;
    }

    private void OnDestroy()
    {
        // Unsubscribe to events
        GameEvents.current.onUIActivated -= ActivateUIMovement;
        GameEvents.current.onUIDeactivated -= ActivateGameMovement;
    }

    private void Update()
    {
        if (moveBody)
        {
            PlayerMovement();
        }
    }

    // Switch movement mode to Game
    void ActivateGameMovement()
    {
        //Debug.Log("GAME MOVE SETTIGS");
        moveBody = true;

        // HACK - todo FIX THIS
        dialogPanel.SetActive(false);
        ClipBoardPanel.SetActive(false);
    }


    // Switch movement mode to UI
    void ActivateUIMovement()
    {
        //Debug.Log("UI MOVE SETTINGS");
        moveBody = false;
    }


    private void PlayerMovement()
    {
        float horzInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horzInput;

        // Character controller built in movement (auto applies delta time)
        charController.SimpleMove(forwardMovement + rightMovement);
    }
}
