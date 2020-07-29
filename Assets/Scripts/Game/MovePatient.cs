using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePatient : MonoBehaviour
{
    // Locations
    public Vector3 ambulanceBayPosition;
    public Vector3 bed1Position;
    public Vector3 bed2Position;
    public Vector3 bed3Position;
    public Vector3 bed4Position;
    public Vector3 bed5Position;
    public Vector3 bed6Position;
    public Vector3 resus1Position;
    public Vector3 resus2Position;


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
    }



    // Send patient to area
    public void sendPatient(string location)
    {
        // Set this patients destination
        switch (location)
        {
            case "AmbulanceBay":
                destination = ambulanceBayPosition;
                break;
            case "Bed1":
                destination = bed1Position;
                break;
            case "Bed2":
                destination = bed2Position;
                break;
            case "Bed3":
                destination = bed3Position;
                break;
            case "Bed4":
                destination = bed4Position;
                break;
            case "Bed5":
                destination = bed5Position;
                break;
            case "Bed6":
                destination = bed6Position;
                break;
            case "Resus1":
                destination = resus1Position;
                break;
            case "Resus2":
                destination = resus2Position;
                break;
            default:
                Debug.Log("PatientMove Destination set wrong");
                destination = new Vector3(0,0,0);
                break;
        }

        // Call nurse to patients current location and prepare to push them

        // Push patient to destination
    }
}
