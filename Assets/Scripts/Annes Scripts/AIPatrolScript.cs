using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrolScript : MonoBehaviour
{
    public Transform assistantPosition;
    public Transform startPosition;
    private NavMeshAgent agent;
    public float assistantTimer;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
               
    }

    void Update()
    {
        assistantTimer -= Time.deltaTime;
        if (assistantTimer < 0)
        {
            StartCoroutine(assistantWaitTime());
        }

    }


    IEnumerator assistantWaitTime()
    {
        agent.destination = assistantPosition.position;

        if (agent.remainingDistance < 0.3)
        {
            yield return new WaitForSeconds(3);
            agent.destination = startPosition.position;
            assistantTimer = 10f;

        }
        
    }

     
}


    

