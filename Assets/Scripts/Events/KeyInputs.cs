using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputs : MonoBehaviour
{
    public GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {

        // Toggles clip board UI on space bar
        if (Input.GetKeyDown("space") || Input.GetKeyDown("escape"))
        {
            if (!gameManager.GetComponent<ClipBoardManager>().viewingChart)
            {
                GameEvents.current.UIActivated();                     // Call "UIActivated()" function that will boardcast "onUIActivated" Event
            }
            else
            {
                GameEvents.current.UIDeactivated();                   // EVENT Broadcast - Clip Board UI closed
            }
        }
    }
}

