using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ModifyTriageScale : MonoBehaviour
{
    public GameObject player;

    // Set the triage value inside the player's player_data SO
    public void SetTriageScale(int cat)
    {
        if (player.GetComponent<DialogManager>().currentPatient != null)
            player.GetComponent<DialogManager>().currentPatient.triageScale = cat;
    }
}