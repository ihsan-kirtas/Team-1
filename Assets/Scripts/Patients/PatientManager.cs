using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientManager : MonoBehaviour
{
    // Lists all the possible patients in the game
    [Header("Add ALL Patients prefabs here only")]
    public List<GameObject> allPatients;

    // to check if a patient is in active use patient_data isActive = true

    public GameObject currentPatientPrefab;




    private void Awake()
    {
        // Subscibe to events
        GameEvents.current.event_startContactPatient1 += SetCurrentPatient1;
        GameEvents.current.event_startContactPatient2 += SetCurrentPatient2;
        GameEvents.current.event_startContactPatient3 += SetCurrentPatient3;
        GameEvents.current.event_startContactPatient4 += SetCurrentPatient4;
        GameEvents.current.event_startContactPatient5 += SetCurrentPatient5;

        GameEvents.current.event_endContactPatient1 += UnlinkCurrentPatient;
        GameEvents.current.event_endContactPatient2 += UnlinkCurrentPatient;
        GameEvents.current.event_endContactPatient3 += UnlinkCurrentPatient;
        GameEvents.current.event_endContactPatient4 += UnlinkCurrentPatient;
        GameEvents.current.event_endContactPatient5 += UnlinkCurrentPatient;
    }




    private void OnDestroy()
    {
        // Subscibe to events
        GameEvents.current.event_startContactPatient1 -= SetCurrentPatient1;
        GameEvents.current.event_startContactPatient2 -= SetCurrentPatient2;
        GameEvents.current.event_startContactPatient3 -= SetCurrentPatient3;
        GameEvents.current.event_startContactPatient4 -= SetCurrentPatient4;
        GameEvents.current.event_startContactPatient5 -= SetCurrentPatient5;

        GameEvents.current.event_endContactPatient1 -= UnlinkCurrentPatient;
        GameEvents.current.event_endContactPatient2 -= UnlinkCurrentPatient;
        GameEvents.current.event_endContactPatient3 -= UnlinkCurrentPatient;
        GameEvents.current.event_endContactPatient4 -= UnlinkCurrentPatient;
        GameEvents.current.event_endContactPatient5 -= UnlinkCurrentPatient;
    }

    private void SetCurrentPatient1()
    {
        currentPatientPrefab = GameObject.Find("NPC_Patient1(Clone)");
    }
    private void SetCurrentPatient2()
    {
        currentPatientPrefab = GameObject.Find("NPC_Patient2(Clone)");
    }
    private void SetCurrentPatient3()
    {
        currentPatientPrefab = GameObject.Find("NPC_Patient3(Clone)");
    }
    private void SetCurrentPatient4()
    {
        currentPatientPrefab = GameObject.Find("NPC_Patient4(Clone)");
    }
    private void SetCurrentPatient5()
    {
        currentPatientPrefab = GameObject.Find("NPC_Patient5(Clone)");
    }
    private void UnlinkCurrentPatient()
    {
        currentPatientPrefab = null;
    }
}
