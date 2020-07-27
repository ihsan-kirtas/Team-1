using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_PatientSpawner : MonoBehaviour
{
    private GameObject gameManager;

    // can make me priate when complete
    public GameObject[] spawnPoints;

    // Can make me private when complete
    public List<GameObject> patients;

    // Start is called before the first frame update
    void Start()
    {
        // Probably dont need this but this is a way to auto-find the GameManager without needing to link in the inspecter.
        gameManager = GameObject.Find("GameManager");


        // Gets all the patient Game Objects from the allPatients list (GameManager/PatientManager) then adds them to your patients list inside this script.
        // Working like this lets us only need to use 1 list throughout the whole game for all the available patients :)
        patients = gameManager.GetComponent<PatientManager>().allPatients;






        // ------ Find all spawn points ------

        //for (int i = 0; i < spawnPoints.Length; i++)
        //{
        //    spawnPoints[i] = GameObject.FindGameObjectsWithTag("SpawnPoint")[i]; //Find tag in the dropdown menu on an item prefab
        //}

        // Easier way - This will find all GameObjects tagged as "SpawnPoint", then add them to the array, no need to loop
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");




        // ------ Instantiate Patients ------
        for (int i = 0; i < patients.Count; i++)
        {
            GameObject newPatient = Instantiate(patients[i], spawnPoints[i].transform.position, Quaternion.identity);

            // Set the newly instantiated patient to be the child of the Patients GameObject - Keeps things tidy :)
            newPatient.transform.parent = GameObject.Find("Patients").transform;

            // Calls a function in the ObsManager which sets up the new patients UI data. Also sends that function this patient_data object
            Patient_Data patient_data = newPatient.GetComponent<NPC_Dialog>().NPC_Data;
            gameManager.GetComponent<ObsManager>().ActivatePatient(patient_data);

            // Broadcast event for a new patient being spawned
            GameEvents.current.PatientSpawned();

            Debug.Log("Patient: " + newPatient.name + " spawned at " + spawnPoints[i].ToString());
        }

        // reference game manager and get component for patient manager script. all patients



        // Hope this helps :)

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
