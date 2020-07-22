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
    public GameObject dialogPanel;

    public Text npcNameText;
    public Text dialogText;

    private List<string> conversation;
    private int convoIndex;


    void Start()
    {
        // Subscribe to events
        GameEvents.current.event_showDialogueUI += ShowDialoguePanel;   // Show dialogue
        GameEvents.current.event_hideDialogueUI += HideDialoguePanel;   // Hide Dialogue

        dialogPanel.SetActive(false);                               // Sets the dialog panel to not active
    }

    private void OnDestroy()
    {
        // Unsubscribe to events
        GameEvents.current.event_showDialogueUI -= ShowDialoguePanel;   // Show dialogue
        GameEvents.current.event_hideDialogueUI -= HideDialoguePanel;   // Hide Dialogue
    }

    private void ShowDialoguePanel()
    {
        dialogPanel.SetActive(true);
    }

    private void HideDialoguePanel()
    {
        dialogPanel.SetActive(false);
    }

    // UI - Close Button
    public void CloseButton()
    {
        // Calls Hide Dialogue event
        GameEvents.current.HideDialogueUI();
    }


    public void Start_Dialog(Patient_Data patient)
    {
        npcNameText.text = patient.name;                            // Set the UI NPC name on the dialog box



        // Which convsersation to use based on players location
        if (ZoneManager.inAmbulanceBay)
        {
            conversation = new List<string>(patient.ambulanceBayConversation);
        }
        else if (ZoneManager.inBedsArea)
        {
            conversation = new List<string>(patient.bedsAreaConversation);
        }
        else if (ZoneManager.inResus1 || ZoneManager.inResus2)
        {
            conversation = new List<string>(patient.resusBayConversation);
        }
        else
        {
            conversation = null;
        }


        convoIndex = 0;                                             // The 1st thing in our list
        ShowText();
    }


    public void StopDialog()
    {
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
