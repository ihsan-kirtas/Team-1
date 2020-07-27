using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName = "Horizontal";
    [SerializeField] private string verticalInputName = "Vertical";

    [SerializeField] private float movementSpeed = 6;

    private CharacterController charController;

    public bool disablePlayerLock;

    // Lock player movement when UI visible
    public bool moveBody;

    //HACK to close all panels on game camera
    public GameObject dialogPanel;
    public GameObject ChartsMasterPanel;



    private void Awake()
    {
        // Gets the Character controller on this object.
        charController = GetComponent<CharacterController>();
        ActivateGameMovement();
    }

    private void Start()
    {
        // Subscribe to events

        // Player Movement - Activate UI Mode
        GameEvents.current.event_showChartUI += ActivateUIMovement;           // Chart UI
        GameEvents.current.event_showDialogueUI += ActivateUIMovement;        // Dialogue UI
        GameEvents.current.event_showPauseMenuUI += ActivateUIMovement;       // Pause Menu UI

        // Player Movement - Activate Game Mode
        GameEvents.current.event_hideChartUI += ActivateGameMovement;         // Chart UI
        GameEvents.current.event_hideDialogueUI += ActivateGameMovement;      // Dialogue UI
        GameEvents.current.event_hidePauseMenuUI += ActivateGameMovement;     // Pause Menu UI

    }

    private void OnDestroy()
    {
        // Unsubscribe to events

        // Player Movement - Activate UI Mode
        GameEvents.current.event_showChartUI -= ActivateUIMovement;           // Chart UI
        GameEvents.current.event_showDialogueUI -= ActivateUIMovement;        // Dialogue UI
        GameEvents.current.event_showPauseMenuUI -= ActivateUIMovement;       // Pause Menu UI

        // Player Movement - Activate Game Mode
        GameEvents.current.event_hideChartUI -= ActivateGameMovement;         // Chart UI
        GameEvents.current.event_hideDialogueUI -= ActivateGameMovement;      // Dialogue UI
        GameEvents.current.event_hidePauseMenuUI -= ActivateGameMovement;     // Pause Menu UI
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
        moveBody = true;

        ChartsMasterPanel.SetActive(false);

        // HACK - todo FIX THIS
        // dialogPanel.SetActive(false);
    }


    // Switch movement mode to UI
    void ActivateUIMovement()
    {
        //Debug.Log("UI MOVE SETTINGS");
        if (!disablePlayerLock)
        {
            moveBody = false;
        }
        
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
