using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePatient : MonoBehaviour
{
    private Text locationText;

    public Vector3 destination;

    private void Start()
    {
        // Link location Text
        locationText = GameObject.Find("Patients Current Location").GetComponent<Text>();
    }


    // Send patient to area
    public void sendPatient(Transform location)
    {

        Patient_Data currentPatientData = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;
        GameObject currentPatientPrefab = currentPatientData.PatientPrefab;

        // Set this patients destination
        switch (location.name)
        {
            case "Triage Point":
                currentPatientData.currentLocation = "Triage Point";
                locationText.text = "Assigned to: Triage Point";
                break;
            case "Ambulance Bay":
                currentPatientData.currentLocation = "Ambulance Bay";   // Set the location string in the patient data
                break;
            case "Bed Space 1":
                currentPatientData.currentLocation = "Bed Space 1";
                locationText.text = "Assigned to: Bed Space 1";
                break;
            case "Bed Space 2":
                currentPatientData.currentLocation = "Bed Space 2";
                locationText.text = "Assigned to: Bed Space 2";
                break;
            case "Bed Space 3":
                currentPatientData.currentLocation = "Bed Space 3";
                locationText.text = "Assigned to: Bed Space 3";
                break;
            case "Bed Space 4":
                currentPatientData.currentLocation = "Bed Space 4";
                locationText.text = "Assigned to: Bed Space 4";
                break;
            case "Bed Space 5":
                currentPatientData.currentLocation = "Bed Space 5";
                locationText.text = "Assigned to: Bed Space 5";
                break;
            case "Bed Space 6":
                currentPatientData.currentLocation = "Bed Space 6";
                locationText.text = "Assigned to: Bed Space 6";
                break;
            case "Resus 1":
                currentPatientData.currentLocation = "Resus Bay 1";
                locationText.text = "Assigned to: Resus 1";
                break;
            case "Resus 2":
                currentPatientData.currentLocation = "Resus Bay 2";
                locationText.text = "Assigned to: Resus 2";
                break;
            default:
                Debug.Log("PatientMove Destination set wrong");
                destination = new Vector3(0, 0, 0);
                break;
        }
        destination = location.position;

        // update the UI Text
        locationText.text = "Assigned to: " + currentPatientData.currentLocation;

        // Call nurse to patients current location and prepare to push them


        // Call the MovePatientTo function attached to the patient prefab
        currentPatientPrefab.GetComponent<PatientMover>().SetNewDestination(location);
    }
}
