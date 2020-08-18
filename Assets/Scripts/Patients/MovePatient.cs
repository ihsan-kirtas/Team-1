using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePatient : MonoBehaviour
{
    public Text locationText;
    public GameObject gameManager;
    public GameObject player;
    private PatientManager patientManager;
    private float drawDataFrequency = 300f;
    private float frameRecord = 0f;



    private void Start()
    {
        // Link Patient Manager
        patientManager = gameManager.GetComponent<PatientManager>();
    }

    private void Update()
    {

        // if time has passed for next data refresh
        if (Time.frameCount > frameRecord + drawDataFrequency)
        {
            if(gameManager.GetComponent<CanvasManager>().patientTransferPagePanel.activeSelf && player.GetComponent<DialogManager>().currentPatient != null)
            {
                // update the UI Text
                locationText.text = "Assigned to: " + player.GetComponent<DialogManager>().currentPatient.currentLocation;
            }
            else
            {
                locationText.text = "No Patient";
            }

            frameRecord = Time.frameCount;  // Record time when this happened
        }
    }

    // Send patient to area
    public void sendPatient(Transform location)
    {
        Patient_Data currentPatientData = player.GetComponent<DialogManager>().currentPatient;

        if(player.GetComponent<DialogManager>().currentPatient != null)
        {
            // Set this patients destination
            switch (location.name)
            {
                case "Triage Point":
                    currentPatientData.currentLocation = "Triage Point";
                    break;
                case "Ambulance Bay":
                    currentPatientData.currentLocation = "Ambulance Bay";   // Set the location string in the patient data
                    break;
                case "Bed Space 1":
                    currentPatientData.currentLocation = "Bed Space 1";
                    break;
                case "Bed Space 2":
                    currentPatientData.currentLocation = "Bed Space 2";
                    break;
                case "Bed Space 3":
                    currentPatientData.currentLocation = "Bed Space 3";
                    break;
                case "Bed Space 4":
                    currentPatientData.currentLocation = "Bed Space 4";
                    break;
                case "Bed Space 5":
                    currentPatientData.currentLocation = "Bed Space 5";
                    break;
                case "Bed Space 6":
                    currentPatientData.currentLocation = "Bed Space 6";
                    break;
                case "Resus 1":
                    currentPatientData.currentLocation = "Resus Bay 1";
                    break;
                case "Resus 2":
                    currentPatientData.currentLocation = "Resus Bay 2";
                    break;
                default:
                    Debug.Log("PatientMove Destination set wrong");
                    break;
            }

            

            // Call nurse to patients current location and prepare to push them


            // Set the new AI target
            if (patientManager.currentPatientPrefab != null)
            {
                patientManager.currentPatientPrefab.GetComponent<PatientMover>().target = location;
            }
            else
            {
                Debug.Log("no current patient prefab");
            }
        }
        else
        {
            locationText.text = "No Patient";
        }
    }
}
