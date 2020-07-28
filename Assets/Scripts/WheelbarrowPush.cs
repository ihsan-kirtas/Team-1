using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WheelbarrowPush : MonoBehaviour
{
    public Transform target;

    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        //alllow script to comm with navmesh agent
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //use navmesh to move agent towards target
        agent.SetDestination(target.position);
    }
}
