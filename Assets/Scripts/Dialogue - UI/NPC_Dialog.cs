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

            // Call event when player enters this NPC's trigger
            if (patient1){
                GameEvents.current.StartContactPatient1();
            }
            else if (patient2) 
            { 
                GameEvents.current.StartContactPatient2(); 
            }
            else if (patient3) 
            { 
                GameEvents.current.StartContactPatient3(); 
            }
            else if (patient4) 
            { 
                GameEvents.current.StartContactPatient4(); 
            }
            else if (patient5) 
            { 
                GameEvents.current.StartContactPatient5(); 
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Call event when player exits this NPC's trigger
            if (patient1) { GameEvents.current.EndContactPatient1(); }
            else if (patient2) { GameEvents.current.EndContactPatient2(); }
            else if (patient3) { GameEvents.current.EndContactPatient3(); }
            else if (patient4) { GameEvents.current.EndContactPatient4(); }
            else if (patient5) { GameEvents.current.EndContactPatient5(); }
        }
    }
}
