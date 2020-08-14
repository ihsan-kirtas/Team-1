using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script: James Siebert

public class DialogManager : MonoBehaviour
{
    public Patient_Data currentPatient;         // The Patient_Data of the patient you are next to

    public List<GameObject> patientsList;       // List of all patients
    
    private GameObject gameManager;             // GameManager Object

    private GameObject dialogPanel;             // The Dialogue Panel
    private GameObject convoAvailablePanel;     // The Conversation Available Notification

    private Text npcNameText;                   // Dialogue box NPC Name
    private Text dialogText;                    // Dialogue box Conversation text
    private List<string> conversation;          // Dialogue conversation list
    private int convoIndex;                     // Dialogue index for setting the current message to show
    

    void Start()
    {
        // -- EVENT SUBSCRIPTIONS --

        // When the player presses C
        GameEvents.current.event_cPressed += CPressed;

        // Link the patients data to this script when player makes contact.
        GameEvents.current.event_startContactPatient1 += LinkToPatient1;
        GameEvents.current.event_startContactPatient2 += LinkToPatient2;
        GameEvents.current.event_startContactPatient3 += LinkToPatient3;
        GameEvents.current.event_startContactPatient4 += LinkToPatient4;
        GameEvents.current.event_startContactPatient5 += LinkToPatient5;

        // Reset when the player breaks contact with the patient.
        GameEvents.current.event_endContactPatient1 += UnLinkPatientsCommon;
        GameEvents.current.event_endContactPatient2 += UnLinkPatientsCommon;
        GameEvents.current.event_endContactPatient3 += UnLinkPatientsCommon;
        GameEvents.current.event_endContactPatient4 += UnLinkPatientsCommon;
        GameEvents.current.event_endContactPatient5 += UnLinkPatientsCommon;

        // Link Game Manager
        gameManager = GameObject.Find("GameManager");

        // Link patients list
        patientsList = gameManager.GetComponent<PatientManager>().allPatients;

        // Link pannels
        dialogPanel = gameManager.GetComponent<CanvasManager>().dialogueUiPanel;
        convoAvailablePanel = gameManager.GetComponent<CanvasManager>().convoAvailablePanel;

        // Link Dialogue text - (Find only available when an object is active)
        dialogPanel.SetActive(true);
        npcNameText = GameObject.Find("Dialog_NPC_Name").GetComponent<Text>();
        dialogText = GameObject.Find("Dialog_Text").GetComponent<Text>();
        dialogPanel.SetActive(false);
    }

    private void OnDestroy()
    {
        // -- EVENT UN-SUBSCRIPTIONS --

        // When the player presses C
        GameEvents.current.event_cPressed -= CPressed;

        // Link the patients data to this script when player makes contact.
        GameEvents.current.event_startContactPatient1 -= LinkToPatient1;
        GameEvents.current.event_startContactPatient2 -= LinkToPatient2;
        GameEvents.current.event_startContactPatient3 -= LinkToPatient3;
        GameEvents.current.event_startContactPatient4 -= LinkToPatient4;
        GameEvents.current.event_startContactPatient5 -= LinkToPatient5;

        // Reset when the player breaks contact with the patient.
        GameEvents.current.event_endContactPatient1 -= UnLinkPatientsCommon;
        GameEvents.current.event_endContactPatient2 -= UnLinkPatientsCommon;
        GameEvents.current.event_endContactPatient3 -= UnLinkPatientsCommon;
        GameEvents.current.event_endContactPatient4 -= UnLinkPatientsCommon;
        GameEvents.current.event_endContactPatient5 -= UnLinkPatientsCommon;
    }

    // Attach the NPC Data from the patient to this "currentPatient" variable. All scripts access the current patient from here
    void LinkToPatient1()
    {
        currentPatient = patientsList[0].GetComponent<NPC_Dialog>().NPC_Data;
        LinkPatientsCommon();
    }
    void LinkToPatient2()
    {
        currentPatient = patientsList[1].GetComponent<NPC_Dialog>().NPC_Data;
        LinkPatientsCommon();
    }
    void LinkToPatient3()
    {
        currentPatient = patientsList[2].GetComponent<NPC_Dialog>().NPC_Data;
        LinkPatientsCommon();
    }
    void LinkToPatient4()
    {
        currentPatient = patientsList[3].GetComponent<NPC_Dialog>().NPC_Data;
        LinkPatientsCommon();
    }
    void LinkToPatient5()
    {
        currentPatient = patientsList[4].GetComponent<NPC_Dialog>().NPC_Data;
        LinkPatientsCommon();
    }

    // If player comes in contact with patient - Common Code
    void LinkPatientsCommon()
    {
        convoAvailablePanel.SetActive(true);        // Shows the player that conversation is available if they want it
    }
    // If player breaks contact with patient - Common Code
    void UnLinkPatientsCommon()
    {
        convoAvailablePanel.SetActive(false);       // Hides the Conversation available UI
        currentPatient = null;                      // Unlinks the current patients data 
        // Force Hide the dialogue if it is visible
    }

    // Player has signified they want to show the conversation available
    private void CPressed()
    {
        // If the player is actually at a patient
        if(currentPatient != null)
        {
            if (dialogPanel.activeSelf)
            {
                dialogPanel.SetActive(false);               // If the dialogue panel is already active then turn it off.
                GameEvents.current.CheckCameraLock();       // Checks wheather to Lock / Unlock Camera
            }
            else                                            // Dialogue panel isnt active, lets activate it.
            {
                npcNameText.text = currentPatient.name;     // Set The Dialog Box Patients Name

                // Select which conversation list to access based on which area the player is located in.
                if (ZoneManager.inAmbulanceBay)
                { conversation = new List<string>(currentPatient.ambulanceBayConversation); }
                else if (ZoneManager.inBedsArea)
                { conversation = new List<string>(currentPatient.bedsAreaConversation); }
                else if (ZoneManager.inResus1 || ZoneManager.inResus2)
                { conversation = new List<string>(currentPatient.resusBayConversation); }
                else { conversation = new List<string>(currentPatient.otherConversation); }

                convoIndex = 0;                                 // Sets the conversation back to item 0 in the conversation.
                dialogText.text = conversation[convoIndex];     // Update the current convo text being displayed.
                dialogPanel.SetActive(true);                    // Show the Dialogue Panel

                GameEvents.current.CheckCameraLock();           // Checks wheather to Lock / Unlock Camera
            }
        }
    }

    // Display the next message in the convo
    public void Next()
    {
        if (convoIndex < conversation.Count - 1)            // Check the convo length before incrementing
        {
            convoIndex += 1;                                // Increment the convo text list by 1.
            dialogText.text = conversation[convoIndex];     // Update the current convo text being displayed.
        }
    }

    // Display the previous message in the convo
    public void Previous()
    {
        if (convoIndex > 0)                                 // Check the convo min before decementing.
        {
            convoIndex -= 1;                                // Decrement the convo text list by 1.
            dialogText.text = conversation[convoIndex];     // Update the current convo text being displayed.
        }
    }
}