using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_PatientSpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] patients;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = GameObject.FindGameObjectsWithTag("SpawnPoint")[i]; //Find tag in the dropdown menu on an item prefab
        }

        //for (int i = 0; i < patients.Length; i++)
        //{
        //    patients[i] = GameObject.FindGameObjectsWithTag("Patients")[i];       //Can't do this because patients don't exist in game yet
        //}

        //Instantiate(patients[], spawnPoints[].transform.position, Quaternion.identity); //Do Not know how to finish this but I am working on this as a way to spawn in our patients from an array
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
