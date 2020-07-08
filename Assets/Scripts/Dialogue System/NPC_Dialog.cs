using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable Object for NPC
/// </summary>
public class NPC_Dialog : MonoBehaviour
{
    public DialogManager dialogManager;
    public Patient_Data NPC_data;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogManager.Start_Dialog(NPC_data);
        }
    }
}
