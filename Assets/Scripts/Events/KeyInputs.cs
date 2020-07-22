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
        // Clip Board UI
        if (Input.GetKeyDown("space"))
        {
            if (!gameManager.GetComponent<ChartUIManager>().viewingChart)
            {
                GameEvents.current.ShowChartUI();
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

