using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class ModifyTriageScale : MonoBehaviour
{
    // for buttons

    public Patient_Data currentPatientData;
    public MovePatient patientMovementLocation;
    private Text locationText;
    public PatientManager patientManager;
    public GameObject triageCanvas;//triage canvas 
    private NavMeshAgent agent;
    public static bool GameIsPaused = false;
    

    //public Transform resusTarget;
    //public Transform bedspaceTarget;
    //
    //public GameObject resusBed;
    //public GameObject bedspaceBed;
    //public GameObject resusBed;
    //public GameObject bedspaceBed;





    void Start()
    {
        triageCanvas.SetActive(false);
        // Link location Text
        locationText = GameObject.Find("Patients Current Location").GetComponent<Text>();

        // pauses game
        Time.timeScale = 1f;
        GameIsPaused = false;
       
        // Link Patient Manager
        patientManager = GameObject.Find("GameManager").GetComponent<PatientManager>();
        agent = GetComponent<NavMeshAgent>();

        //set all objects as false so that the player can triage using a key
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            triageCanvas.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true; 
            Debug.Log(" triage canvas is activated");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;// shows cursor
        }

        else if (Input.GetKeyDown(KeyCode.Q))
        {
            triageCanvas.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
            Debug.Log("triage canvas is deactivated");
            Cursor.visible = false;//hides cursor 
        }
    }

    

    void SetTriageScale(int cat)
    {
        currentPatientData = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;

        if (currentPatientData != null)
        {
            currentPatientData.triageScale = cat;
        }
    }
    
    void setScale1()
    {
        SetTriageScale(1);
        currentPatientData.currentLocation = "Resus Bay 1";
        locationText.text = "Assigned to: Resus 1";
       
    }

    void setScale2()
    {
        SetTriageScale(2);
        currentPatientData.currentLocation = "Resus Bay 1";
        locationText.text = "Assigned to: Resus 1";
    }

    void setScale3()
    {
        SetTriageScale(3);
        currentPatientData.currentLocation = "Bed Space 2";
        locationText.text = "Assigned to: Bed Space 2";
    }

    void setScale4()
    {
        SetTriageScale(4);
        currentPatientData.currentLocation = "Bed Space 3";
        locationText.text = "Assigned to: Bed Space 3";


    }
    void setScale5()
    {
        SetTriageScale(5);
        



    }
}