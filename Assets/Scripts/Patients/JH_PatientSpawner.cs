using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_PatientSpawner : MonoBehaviour
{
    //private GameObject gameManager;

    // can make me priate when complete
    //public GameObject[] spawnPoints;

    // Can make me private when complete
    public List<GameObject> allPatientsList;

    private int nextPatientIndex;

    private Vector3 spawnPoint;

    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Find the object in the game named "Spawn Point" and link it
        spawnPoint = GameObject.Find("Spawn Point").transform.position;

        gameManager = GameObject.Find("GameManager");

        // Get all available patent prefabs
        allPatientsList = gameManager.GetComponent<PatientManager>().allPatients;

        nextPatientIndex = 0;






        // ------ Find all spawn points ------

        //for (int i = 0; i < spawnPoints.Length; i++)
        //{
        //    spawnPoints[i] = GameObject.FindGameObjectsWithTag("SpawnPoint")[i]; //Find tag in the dropdown menu on an item prefab
        //}

        // Easier way - This will find all GameObjects tagged as "SpawnPoint", then add them to the array, no need to loop
        //spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");




        // ------ Instantiate Patients ------
        //for (int i = 0; i < allPatientsList.Count; i++)
        //{
        //    GameObject newPatient = Instantiate(allPatientsList[i], spawnPoints[i].transform.position, Quaternion.identity);

        //    // Set the newly instantiated patient to be the child of the Patients GameObject - Keeps things tidy :)
        //    newPatient.transform.parent = GameObject.Find("Patients").transform;

        //    // Calls a function in the ObsManager which sets up the new patients UI data. Also sends that function this patient_data object
        //    Patient_Data patient_data = newPatient.GetComponent<NPC_Dialog>().NPC_Data;
        //    gameManager.GetComponent<ObsManager>().ActivatePatient(patient_data);

        //    // Broadcast event for a new patient being spawned
        //    GameEvents.current.PatientSpawned();

        //    Debug.Log("Patient: " + newPatient.name + " spawned at " + spawnPoints[i].ToString());
        //}

        // reference game manager and get component for patient manager script. all patients



        // Hope this helps :)

    }


    public void SpawnNextPatient()
    {
        if(nextPatientIndex + 1 <= allPatientsList.Count)
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
    }
}
