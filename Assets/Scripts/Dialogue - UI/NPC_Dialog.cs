using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC_Dialog : MonoBehaviour
{
    public bool patient1;
    public bool patient2;
    public bool patient3;
    public bool patient4;
    public bool patient5;

    public Patient_Data NPC_Data;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //GameEvents.current.ShowDialogueUI();

            // Call event when player enters this NPC's trigger
            if (patient1){GameEvents.current.StartConvoPatient1();}
            else if (patient2) { GameEvents.current.StartConvoPatient2(); }
            else if (patient3) { GameEvents.current.StartConvoPatient3(); }
            else if (patient4) { GameEvents.current.StartConvoPatient4(); }
            else if (patient5) { GameEvents.current.StartConvoPatient5(); }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //GameEvents.current.HideDialogueUI();

            // Call event when player exits this NPC's trigger
            if (patient1) { GameEvents.current.EndConvoPatient1(); }
            else if (patient2) { GameEvents.current.EndConvoPatient2(); }
            else if (patient3) { GameEvents.current.EndConvoPatient3(); }
            else if (patient4) { GameEvents.current.EndConvoPatient4(); }
            else if (patient5) { GameEvents.current.EndConvoPatient5(); }
        }
    }
}
