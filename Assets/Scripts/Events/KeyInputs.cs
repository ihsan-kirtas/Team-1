using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputs : MonoBehaviour
{
    private GameObject gameManager;

    private GameObject noObsAvailablePanel;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        noObsAvailablePanel = GameObject.Find("GameManager").GetComponent<CanvasManager>().ObsNotAvailableAlert;
        noObsAvailablePanel.SetActive(false);
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
                    //Debug.Log("You need to be at the patient first - Make me a UI notification");

                    // Show error message
                    StartCoroutine(DisplayNoObsMessage());
                }
            }
            else
            {
                GameEvents.current.HideChartUI();
            }
        }


        IEnumerator DisplayNoObsMessage()
        {
            // Show message
            noObsAvailablePanel.SetActive(true);

            //yield on a new YieldInstruction that waits for X seconds.
            yield return new WaitForSeconds(2);

            // Hide Message
            noObsAvailablePanel.SetActive(false);
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

