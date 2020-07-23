using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_PatientSpawner : MonoBehaviour
{
    public GameObject gameManager;

    public GameObject[] spawnPoints;

    public List<GameObject> patients;

    // Start is called before the first frame update
    void Start()
    {
        patients = gameManager.GetComponent<PatientManager>().allPatients;



        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = GameObject.FindGameObjectsWithTag("SpawnPoint")[i]; //Find tag in the dropdown menu on an item prefab
        }

        //for (int i = 0; i < patients.Length; i++)
        //{
        //    Instantiate(patients[i], spawnPoints[i].transform.position, Quaternion.identity); 
        //}

        // reference game manager and get component for patient manager script. all patients

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
