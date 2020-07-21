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

        for (int i = 0; i < patients.Length; i++)
        {
            Instantiate(patients[i], spawnPoints[i].transform.position, Quaternion.identity); 
        }               
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
