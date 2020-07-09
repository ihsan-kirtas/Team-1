using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

// Setup steps
// Tag player with "Player" Tag
// Link UI Next button to Next function in inspector
// Link UI Close button to StopDialog function in inspector

// Unity's character controller will make clicking UI buttons a mess.


public class DialogManager : MonoBehaviour
{
    // Dialog Event
    public UnityEvent start_dialog;

    public GameObject dialogPanel;

    public Text npcNameText;
    public Text dialogText;

    private List<string> conversation;
    private int convoIndex;

    void Start()
    {
        dialogPanel.SetActive(false);                               // Sets the dialog panel to not active
    }

    public void Start_Dialog(Patient_Data patient)
    {
        GameEvents.current.UIActivated();                           // EVENT Broadcast - Dialog UI opened
        npcNameText.text = patient.name;                            // Set the UI NPC name on the dialog box
        conversation = new List<string>(patient.conversation);      // Create a list from the convo provided to the function call
        dialogPanel.SetActive(true);                                // Shows the dialog box
        convoIndex = 0;                                             // The 1st thing in our list
        ShowText();
    }


    public void StopDialog()
    {
        GameEvents.current.UIDeactivated();                         // EVENT Broadcast - Dialog UI closed
        dialogPanel.SetActive(false);                               // Hide the dialog panel
    }

    private void ShowText()
    {
        dialogText.text = conversation[convoIndex];                 // Set the text to current part of the conversation.
    }


    public void Next()                                              // Increment convo to the next message
    {
        if (convoIndex < conversation.Count - 1)                    // Check the convo length before incrementing
        {
            convoIndex += 1;
            ShowText();
        }
    }

    public void Previous()                                              // decrement convo to the previous message
    {
        if (convoIndex > 0)                                             // only go as low as 0
        {
            convoIndex -= 1;
            ShowText();
        }
    }
}
