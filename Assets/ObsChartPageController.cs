﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObsChartPageController : MonoBehaviour
{
    private Patient_Data currentPatientData;
    private GameObject player;

    //public Text patientname;
    public Text initialObsText;


    private void Start()
    {
        player = GameObject.Find("Player");     // Link player

        initialObsText.text = "";
    }

    public void UpdateObsChartPage()
    {
        Debug.Log("Update obs chart Page");

        // Update current patient Data
        currentPatientData = player.GetComponent<DialogManager>().currentPatient;

        if (currentPatientData != null)
        {
            // Set Text
            initialObsText.text = currentPatientData.uiambohandover;

        }
        else
        {
            initialObsText.text = "";
        }
    }
}
