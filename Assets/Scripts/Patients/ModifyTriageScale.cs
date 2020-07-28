using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class ModifyTriageScale : MonoBehaviour
{
    // for buttons
    
    public Patient_Data currentPatientData;
    public GameObject resusBed;
    public GameObject bedspaceBed;
    public GameObject triageCanvas;//triage canvas 
    public Transform resusTarget;
    public Transform bedspaceTarget;
    private NavMeshAgent agent;




    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        triageCanvas.SetActive(false);//set all objects as false so that the player can triage using a key
    }

    


    private void OnTriggerEnter(Collider player)
    {

        if (player.gameObject.tag == "Player")
        {
            triageCanvas.SetActive(true);
        }
                       

        else if (Input.GetKeyDown(KeyCode.N))
        {
            triageCanvas.SetActive(false);
        }

        // on triage trigger enter triage scale will be enabled player will select correct triage score of 1 or 2
    }

    void SetTriageScale(int cat)
    {
        currentPatientData = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;

        if(currentPatientData != null)
        {
            currentPatientData.triageScale = cat;
        }
    }


    void setScale1()
    {
        SetTriageScale(1);
        resusBed.SetActive(false);
        agent.SetDestination(resusTarget.position);// resus bay 1 is the target position 
    }

    void setScale2()
    {
        SetTriageScale(2);
        resusBed.SetActive(false);
        agent.SetDestination(resusTarget.position); // resus bay 1 is the target position 
    }

    void setScale3()
    {
        SetTriageScale(3);
        bedspaceBed.SetActive(false);
        agent.SetDestination(bedspaceTarget.position);// bedspace 1 is the target position 
    }

    void setScale4()
    {
        SetTriageScale(4);
        bedspaceBed.SetActive(false);
        agent.SetDestination(bedspaceTarget.position);// bedspace 1 is the target position 
    }

    void setScale5()
    {
        SetTriageScale(5);
        bedspaceBed.SetActive(false);
        agent.SetDestination(bedspaceTarget.position);// bedspace 1 is the target position 
    }
}

