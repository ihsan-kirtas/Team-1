using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_PatientSpawner : MonoBehaviour
{

    public List<GameObject> allPatientsList;

    private int nextPatientIndex;

    private Vector3 spawnPoint;

    GameObject gameManager;

    private bool spawnEnabled = true;


    void Start()
    {
        // Find the object in the game named "Spawn Point" and link it
        spawnPoint = GameObject.Find("Spawn Point").transform.position;

        gameManager = GameObject.Find("GameManager");

        // Get all available patent prefabs
        allPatientsList = gameManager.GetComponent<PatientManager>().allPatients;

        nextPatientIndex = 0;
    }


    public void SpawnNextPatient()
    {
        if (spawnEnabled)
        {
            if (nextPatientIndex + 1 <= 4) // Capped at 4 patients
            {
                // Spawn Patient from list
                GameObject newPatient = Instantiate(allPatientsList[nextPatientIndex], spawnPoint, Quaternion.identity);

                // Set its parent object
                newPatient.transform.parent = GameObject.Find("Patients").transform;

                // Activate the patient
                Patient_Data patient_data = newPatient.GetComponent<NPC_Dialog>().NPC_Data;
                gameManager.GetComponent<ObsManager>().ActivatePatient(patient_data);

                // Call spawned event
                GameEvents.current.PatientSpawned();

                Debug.Log("Patient: " + newPatient.name + " spawned");

                // Increment ready for next spawn
                nextPatientIndex++;
            }
            else
            {
                Debug.Log("No More Patients");
                Debug.Log(nextPatientIndex + 1);
            }

            StartCoroutine(EnableSpawn());
        }
        else
        {
            Debug.Log("spawn timer delay");
        }
        
    }

    IEnumerator EnableSpawn()
    {
        spawnEnabled = false;
        yield return new WaitForSeconds(3);
        spawnEnabled = true;
    }
}
