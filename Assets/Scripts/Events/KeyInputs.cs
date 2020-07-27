using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputs : MonoBehaviour
{
    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        // Clip Board UI
        if (Input.GetKeyDown("space"))
        {
            if (!gameManager.GetComponent<ChartUIManager>().viewingChart)
            {
                // Player must be within a patients trigger to launch charts UI
                if (GameObject.Find("Player").GetComponent<DialogManager>().currentPatient != null)
                {
                    GameEvents.current.ShowChartUI();
                }
                else
                {
                    Debug.Log("You need to be at the patient first - Make me a UI notification");
                }
            }
            else
            {
                GameEvents.current.HideChartUI();
            }
        }

        // Pause Menu UI
        if (Input.GetKeyDown("escape"))
        {
            bool is_ui_showing = true;

            if (is_ui_showing)
            {
                GameEvents.current.ShowPauseMenuUI();
            }
            else
            {
                GameEvents.current.HidePauseMenuUI();
            }
        }
    }
}

