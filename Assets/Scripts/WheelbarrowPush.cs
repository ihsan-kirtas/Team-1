using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WheelbarrowPush : MonoBehaviour
{
    public Transform target;

    private Animator animator;

    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //alllow script to comm with navmesh agent
        agent = GetComponent<NavMeshAgent>();
        //use navmesh to move agent towards target
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 charPos = new Vector2(transform.position.x, transform.position.z);
        Vector2 tarPos = new Vector2(agent.destination.x, agent.destination.z);

        if (Vector2.Distance(charPos, tarPos) < 0.2)
        {
            animator.SetBool("Walking", false);
        }
        else
        {
            animator.SetBool("Walking", true);
        }
    }
}
