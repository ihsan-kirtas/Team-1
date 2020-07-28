using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class ModifyTriageScale : MonoBehaviour
{
    // for buttons
    
    public Patient_Data currentPatientData;
    
    public GameObject triageCanvas;//triage canvas 




    void Start()
    {
        
        triageCanvas.SetActive(false);//set all objects as false so that the player can triage using a key
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            triageCanvas.SetActive(true);
            Debug.Log("triage key pressed");
        }

        else if (Input.GetKeyDown(KeyCode.N))
        {
            triageCanvas.SetActive(false);
        }
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
        
    }

    void setScale2()
    {
        SetTriageScale(2);
        
    }

    void setScale3()
    {
        SetTriageScale(3);
        
    }

    void setScale4()
    {
        SetTriageScale(4);
        

    }

    void setScale5()
    {
        SetTriageScale(5);
       
    }
}

