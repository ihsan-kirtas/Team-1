using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    // Zones
    public static bool inAmbulanceBay;
    public static bool inBedsArea;
    public static bool inResus1;
    public static bool inResus2;
    public static bool inHallway;

    // If player enters zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AmbulanceBay"))
        {
            GameEvents.current.PlayerEnteredAmbulanceBay();
            inAmbulanceBay = true;
            Debug.Log("Player entered Ambulance Bay");
        }
        else if (other.CompareTag("BedsArea"))
        {
            GameEvents.current.PlayerEnteredBedsArea();
            inBedsArea = true;
            Debug.Log("Player entered Beds Area");
        }
        else if (other.CompareTag("Resus1"))
        {
            GameEvents.current.PlayerEnteredResus1();
            inResus1 = true;
            Debug.Log("Player entered Resus 1");
        }
        else if (other.CompareTag("Resus2"))
        {
            GameEvents.current.PlayerEnteredResus2();
            inResus2 = true;
            Debug.Log("Player entered Resus 2");
        }
        else
        {
            GameEvents.current.PlayerEnteredHallway();
            inHallway = true;
            Debug.Log("Player entered Hallway / Other");
        }
    }

    // If player exits zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AmbulanceBay"))
        {
            inAmbulanceBay = false;
        }
        if (other.CompareTag("BedsArea"))
        {
            inBedsArea = false;
        }
        if (other.CompareTag("Resus1"))
        {
            inResus1 = false;
        }
        if (other.CompareTag("Resus2"))
        {
            inResus2 = false;
        }
        if (other.CompareTag("Hallway"))
        {
            inHallway = false;
        }
    }
}
