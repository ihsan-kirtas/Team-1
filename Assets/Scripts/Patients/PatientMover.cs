using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatientMover : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 target;

    private void Start()
    {
        // Get agent on this GO
        agent = this.GetComponent<NavMeshAgent>();
    }

    public void MovePatientTo(Vector3 location)
    {
        Debug.Log("Moving patient to " + location.ToString());

        agent = this.GetComponent<NavMeshAgent>();

        target = location;
        // Set a new destination for the AI Agent
        agent.SetDestination(target);
    }
}
