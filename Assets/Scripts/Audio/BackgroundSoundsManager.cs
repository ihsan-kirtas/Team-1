using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundsManager : MonoBehaviour
{
    void Start()
    {
        // Subscribe to events
        GameEvents.current.event_playerEnteredAmbulanceBay += PlayAmbulanceBayBGAudio;  // Ambulance Bay
        GameEvents.current.event_playerEnteredBedsArea += PlayBedsAreaBGAudio;          // Beds Area
        GameEvents.current.event_playerEnteredResus1 += PlayResusBayBGAudio;            // Resus 1
        GameEvents.current.event_playerEnteredResus2 += PlayResusBayBGAudio;            // Resus 2
        GameEvents.current.event_playerEnteredHallway += PlayHallwayBGAudio;            // Hallway
    }

    private void OnDestroy()
    {
        // Unubscribe to events
        GameEvents.current.event_playerEnteredAmbulanceBay -= PlayAmbulanceBayBGAudio;  // Ambulance Bay
        GameEvents.current.event_playerEnteredBedsArea -= PlayBedsAreaBGAudio;          // Beds Area
        GameEvents.current.event_playerEnteredResus1 -= PlayResusBayBGAudio;            // Resus 1
        GameEvents.current.event_playerEnteredResus2 -= PlayResusBayBGAudio;            // Resus 2
        GameEvents.current.event_playerEnteredHallway -= PlayHallwayBGAudio;            // Hallway
    }


    private void PlayAmbulanceBayBGAudio()
    {
        // Debug.Log("Play Ambulance Bay BG Audio");
    }

    private void PlayBedsAreaBGAudio()
    {
        // Debug.Log("Beds Area BG Audio");
    }

    private void PlayResusBayBGAudio()
    {
        // Debug.Log("Play Resus Bay BG Audio");
    }

    private void PlayHallwayBGAudio()
    {
        // Debug.Log("Play Hallway BG Audio");
    }


    /* Its probably a good idea to start the audio from the event.
     * you can also check that the if the player is still in that zone with the bool ZoneManager.isInAmbulanceBay
     * So something like while (ZoneManager.isInAmbulanceBay == true), play sound
     */



}
