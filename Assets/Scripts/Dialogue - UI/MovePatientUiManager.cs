using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePatientUiManager : MonoBehaviour
{
    private Text locationText;

    private void Start()
    {
        // Subscribe to events
        GameEvents.current.event_startContactPatient1 += ShowButtons;
        GameEvents.current.event_startContactPatient2 += ShowButtons;
        GameEvents.current.event_startContactPatient3 += ShowButtons;
        GameEvents.current.event_startContactPatient4 += ShowButtons;
        GameEvents.current.event_startContactPatient5 += ShowButtons;

        GameEvents.current.event_endContactPatient1 += HideButtons;
        GameEvents.current.event_endContactPatient2 += HideButtons;
        GameEvents.current.event_endContactPatient3 += HideButtons;
        GameEvents.current.event_endContactPatient4 += HideButtons;
        GameEvents.current.event_endContactPatient5 += HideButtons;

        // link loction text element + hide panel on start
        GameObject.Find("GameManager").GetComponent<CanvasManager>().MovePatientPanel.SetActive(true);
        locationText = GameObject.Find("Patients Current Location").GetComponent<Text>();
        GameObject.Find("GameManager").GetComponent<CanvasManager>().MovePatientPanel.SetActive(false);
    }

    private void OnDestroy()
    {
        // Unsubscribe to events
        GameEvents.current.event_startContactPatient1 -= ShowButtons;
        GameEvents.current.event_startContactPatient2 -= ShowButtons;
        GameEvents.current.event_startContactPatient3 -= ShowButtons;
        GameEvents.current.event_startContactPatient4 -= ShowButtons;
        GameEvents.current.event_startContactPatient5 -= ShowButtons;

        GameEvents.current.event_endContactPatient1 -= HideButtons;
        GameEvents.current.event_endContactPatient2 -= HideButtons;
        GameEvents.current.event_endContactPatient3 -= HideButtons;
        GameEvents.current.event_endContactPatient4 -= HideButtons;
        GameEvents.current.event_endContactPatient5 -= HideButtons;
    }
    void ShowButtons()
    {
        // Show buttons panel
        GameObject.Find("GameManager").GetComponent<CanvasManager>().MovePatientPanel.SetActive(true);

        // Time delay to allow for player data to be loaded properly
        StartCoroutine(UpdateLocationText(0.1f));

    }

    void HideButtons()
    {
        // Hide buttons panel
        GameObject.Find("GameManager").GetComponent<CanvasManager>().MovePatientPanel.SetActive(false);
    }

    IEnumerator UpdateLocationText(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Get current patients data
        Patient_Data currentPatientData = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;

        // update the UI Text
        locationText.text = "Assigned to: " + currentPatientData.currentLocation;
    }
}
