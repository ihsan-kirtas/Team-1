using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatientMover : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    public Transform target;

    private void Start()
    {
        // Get agent on this GO
        agent = this.GetComponent<NavMeshAgent>();

        // clear patient location from patient_data
        this.GetComponent<NPC_Dialog>().NPC_Data.currentLocation = " Un Assigned";

        agent.SetDestination(new Vector3(20,0,20));
    }

    public void SetNewDestination(Transform newTarget)
    {
        target = newTarget;
        agent.SetDestination(target.position);
        Debug.Log("Moving patient to " + target.ToString());
    }
}
