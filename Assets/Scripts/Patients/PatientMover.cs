using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatientMover : MonoBehaviour
{
    NavMeshAgent agent;

    public Transform target;

    private void Start()
    {
        // Get agent on this GO
        agent = GetComponent<NavMeshAgent>();

        target = GameObject.Find("Triage Point").transform;

        // clear patient location from patient_data
        this.GetComponent<NPC_Dialog>().NPC_Data.currentLocation = " Un Assigned";
    }

    private void Update()
    {
        agent.destination = target.position;
    }
}
