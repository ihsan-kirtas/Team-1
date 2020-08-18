using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObsChartPageController : MonoBehaviour
{
    private Patient_Data pd;
    public GameObject player;

    //public Text patientname;
    public Text initialObsText;


    private void Start()
    {
        //player = GameObject.Find("Player");     // Link player

        //initialObsText.text = "";
    }

    public void UpdateObsChartPage()
    {
        Debug.Log("Update obs chart Page");

        // Update current patient Data
        pd = player.GetComponent<DialogManager>().currentPatient;

        if (pd != null)
        {
            // Set Text
            //initialObsText.text = pd.uiambohandover;

        }
        else
        {
            //initialObsText.text = "";
        }
    }
}
