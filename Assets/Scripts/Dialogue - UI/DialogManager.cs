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
    public List<GameObject> patientsList;
    public Patient_Data currentPatient;

    private GameObject dialogPanel;

    private Text npcNameText;
    private Text dialogText;

    private List<string> conversation;
    private int convoIndex;


    void Start()
    {
        // Subscribe to events
        GameEvents.current.event_showDialogueUI += ShowDialoguePanel;   // maybe delete
        GameEvents.current.event_hideDialogueUI += HideDialoguePanel;   // maybe delete


        GameEvents.current.event_startConvoPatient1 += startConvoPatient1;
        GameEvents.current.event_startConvoPatient2 += startConvoPatient2;
        GameEvents.current.event_startConvoPatient3 += startConvoPatient3;
        GameEvents.current.event_startConvoPatient4 += startConvoPatient4;
        GameEvents.current.event_startConvoPatient5 += startConvoPatient5;

        GameEvents.current.event_endConvoPatient1 += endConvoPatientAll;
        GameEvents.current.event_endConvoPatient2 += endConvoPatientAll;
        GameEvents.current.event_endConvoPatient3 += endConvoPatientAll;
        GameEvents.current.event_endConvoPatient4 += endConvoPatientAll;
        GameEvents.current.event_endConvoPatient5 += endConvoPatientAll;


        // link panels
        dialogPanel = GameObject.Find("GameManager").GetComponent<CanvasManager>().dialogueUiPanel;

        patientsList = GameObject.Find("GameManager").GetComponent<PatientManager>().allPatients;

        dialogPanel.SetActive(true);
        npcNameText = GameObject.Find("Dialog_NPC_Name").GetComponent<Text>();
        dialogText = GameObject.Find("Dialog_Text").GetComponent<Text>();
        dialogPanel.SetActive(false);                               // Sets the dialog panel to not active
    }

    private void OnDestroy()
    {
        // Unsubscribe to events
        GameEvents.current.event_showDialogueUI -= ShowDialoguePanel;   // Show dialogue
        GameEvents.current.event_hideDialogueUI -= HideDialoguePanel;   // Hide Dialogue



        GameEvents.current.event_startConvoPatient1 -= startConvoPatient1;
        GameEvents.current.event_startConvoPatient2 -= startConvoPatient2;
        GameEvents.current.event_startConvoPatient3 -= startConvoPatient3;
        GameEvents.current.event_startConvoPatient4 -= startConvoPatient4;
        GameEvents.current.event_startConvoPatient5 -= startConvoPatient5;

        GameEvents.current.event_endConvoPatient1 -= endConvoPatientAll;
        GameEvents.current.event_endConvoPatient2 -= endConvoPatientAll;
        GameEvents.current.event_endConvoPatient3 -= endConvoPatientAll;
        GameEvents.current.event_endConvoPatient4 -= endConvoPatientAll;
        GameEvents.current.event_endConvoPatient5 -= endConvoPatientAll;
    }

    // Start dialogue setup
    private void startConvoPatient1()
    {
        //Debug.Log("Patient 1 convo started");
        if (patientsList.Count > 0)
        {
            //Debug.Log("list > 0");
            currentPatient = patientsList[0].GetComponent<NPC_Dialog>().NPC_Data;
            convoIndex = 0;
            GameEvents.current.ShowDialogueUI();
            Start_Dialog();
        }
    }
    private void startConvoPatient2()
    {
        //Debug.Log("Patient 2 convo started");
        if (patientsList.Count > 0)
        {
            currentPatient = patientsList[1].GetComponent<NPC_Dialog>().NPC_Data;
            convoIndex = 0;
            GameEvents.current.ShowDialogueUI();
            Start_Dialog();
        }
    }
    private void startConvoPatient3()
    {
        //Debug.Log("Patient 3 convo started");
        if (patientsList.Count > 0)
        {
            currentPatient = patientsList[2].GetComponent<NPC_Dialog>().NPC_Data;
            convoIndex = 0;
            GameEvents.current.ShowDialogueUI();
            Start_Dialog();
        }
    }
    private void startConvoPatient4()
    {
        //Debug.Log("Patient 4 convo started");
        if (patientsList.Count > 0)
        {
            currentPatient = patientsList[3].GetComponent<NPC_Dialog>().NPC_Data;
            convoIndex = 0;
            GameEvents.current.ShowDialogueUI();
            Start_Dialog();
        }
    }
    private void startConvoPatient5()
    {
        //Debug.Log("Patient 5 convo started");
        if (patientsList.Count > 0)
        {
            currentPatient = patientsList[4].GetComponent<NPC_Dialog>().NPC_Data;
            convoIndex = 0;
            GameEvents.current.ShowDialogueUI();
            Start_Dialog();
        }
    }

    // End dialogue
    private void endConvoPatientAll()
    {
        //Debug.Log("All patient convo ended");

        GameEvents.current.HideDialogueUI();

        currentPatient = null;
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


    public void Start_Dialog()
    {
        npcNameText.text = currentPatient.name;                            // Set the UI NPC name on the dialog box



        // Which convsersation to use based on players location
        if (ZoneManager.inAmbulanceBay)
        {
            conversation = new List<string>(currentPatient.ambulanceBayConversation);
        }
        else if (ZoneManager.inBedsArea)
        {
            conversation = new List<string>(currentPatient.bedsAreaConversation);
        }
        else if (ZoneManager.inResus1 || ZoneManager.inResus2)
        {
            conversation = new List<string>(currentPatient.resusBayConversation);
        }
        else
        {
            conversation = new List<string>(currentPatient.otherConversation);
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
