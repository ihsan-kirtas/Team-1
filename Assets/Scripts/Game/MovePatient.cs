using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePatient : MonoBehaviour
{
    // Locations
    private Vector3 ambulanceBayPosition;
    private Vector3 bed1Position;
    private Vector3 bed2Position;
    private Vector3 bed3Position;
    private Vector3 bed4Position;
    private Vector3 bed5Position;
    private Vector3 bed6Position;
    private Vector3 resus1Position;
    private Vector3 resus2Position;

    private Text locationText;

    public Vector3 destination;

    private void Start()
    {
        // Link locations to GO's and get their position.
        ambulanceBayPosition = GameObject.Find("Initial Triage Point").transform.position;
        bed1Position = GameObject.Find("Bed Space 1").transform.position;
        bed2Position = GameObject.Find("Bed Space 2").transform.position;
        bed3Position = GameObject.Find("Bed Space 3").transform.position;
        bed4Position = GameObject.Find("Bed Space 4").transform.position;
        bed5Position = GameObject.Find("Bed Space 5").transform.position;
        bed6Position = GameObject.Find("Bed Space 6").transform.position;
        resus1Position = GameObject.Find("Resus 1 Bed").transform.position;
        resus2Position = GameObject.Find("Resus 2 Bed").transform.position;

        // Link location Text
        locationText = GameObject.Find("Patients Current Location").GetComponent<Text>();
    }



    // Send patient to area
    public void sendPatient(string location)
    {

        Patient_Data currentPatientData = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;
        GameObject currentPatientPrefab = currentPatientData.PatientPrefab;

        // Set this patients destination
        switch (location)
        {
            case "AmbulanceBay":
                destination = ambulanceBayPosition;                     // Set destination to the position of the ambulance bay gizmo
                currentPatientData.currentLocation = "Ambulance Bay";   // Set the location string in the patient data
                break;
            case "Bed1":
                destination = bed1Position;
                currentPatientData.currentLocation = "Bed Space 1";
                locationText.text = "Assigned to: Bed Space 1";
                break;
            case "Bed2":
                destination = bed2Position;
                currentPatientData.currentLocation = "Bed Space 2";
                locationText.text = "Assigned to: Bed Space 2";
                break;
            case "Bed3":
                destination = bed3Position;
                currentPatientData.currentLocation = "Bed Space 3";
                locationText.text = "Assigned to: Bed Space 3";
                break;
            case "Bed4":
                destination = bed4Position;
                currentPatientData.currentLocation = "Bed Space 4";
                locationText.text = "Assigned to: Bed Space 4";
                break;
            case "Bed5":
                destination = bed5Position;
                currentPatientData.currentLocation = "Bed Space 5";
                locationText.text = "Assigned to: Bed Space 5";
                break;
            case "Bed6":
                destination = bed6Position;
                currentPatientData.currentLocation = "Bed Space 6";
                locationText.text = "Assigned to: Bed Space 6";
                break;
            case "Resus1":
                destination = resus1Position;
                currentPatientData.currentLocation = "Resus Bay 1";
                locationText.text = "Assigned to: Resus 1";
                break;
            case "Resus2":
                destination = resus2Position;
                currentPatientData.currentLocation = "Resus Bay 2";
                locationText.text = "Assigned to: Resus 2";
                break;
            default:
                Debug.Log("PatientMove Destination set wrong");
                destination = new Vector3(0, 0, 0);
                break;
        }

        // update the UI Text
        locationText.text = "Assigned to: " + currentPatientData.currentLocation;

        // Call nurse to patients current location and prepare to push them


        // Call the MovePatientTo function attached to the patient prefab
        currentPatientPrefab.GetComponent<PatientMover>().MovePatientTo(destination);

    }
}
