using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Attach a larger box collider to the NPC
// Set that collider to isTrigger



public class NPC : MonoBehaviour
{
    public string npcName;                                      // This NPCs name
    public DialogManager dialogManager;                         // Link to player
    public List<string> npcConvo = new List<string>();          // Convsersation

    private void OnTriggerEnter(Collider other)                 // If something enters my trigger area
    {
        if (other.CompareTag("Player"))                         // And if that something is tagged Player
        {
            dialogManager.Start_Dialog(npcName, npcConvo);      // Execute the players start dialog function and provide it with my name and list of convo.
        }
    }
}
