using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrolScriptV2 : MonoBehaviour
{
    private NavMeshAgent agent;

    private Animator animator;
    public Transform[] wayPoints;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = wayPoints[1].position;

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