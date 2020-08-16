using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitiallObsPageController : MonoBehaviour
{
    private Patient_Data pd;
    public GameObject player;

    //public Text patientname;
    public Text initialObsText;


    private void Start()
    {
        //initialObsText.text = "";
    }

    public void UpdateInitialObsPage()
    {
        Debug.Log("Update initial Obs Page");



        // Update current patient Data
        pd = player.GetComponent<DialogManager>().currentPatient;

        if (pd != null)
        {
            initialObsText.text = BuildInitialObsText();
        }
        else
        {
            initialObsText.text = "";
        }
    }

    public string BuildInitialObsText()
    {
        string returnString =
            // Triage - ABCDDEF

            "\n### A - Airway ###\n" +
            "Self Ventilating: " + pd.selfVentilating.ToString() + "\n" +

            "\n### B - Breathing ###\n" +
            "Oxygen: " + pd.oxygenInit.ToString() + "\n" +
            "Breath Rate: " + pd.breathRateInit.ToString() + "\n" +
            "Using Accessory Muscles: " + pd.accessoryMuscles.ToString() + "\n" +

            "\n### C - Circulation ###\n" +
            "Blood Pressure Systolic: " + pd.bloodPressureSystolicInit.ToString() + "\n" +
            "Blood Pressure Diastolic : " + pd.bloodPressureDiastolicInit.ToString() + "\n" +
            "Pulse Rate: " + pd.pulseRateInit.ToString() + "\n" +
            "Whole Body Perfusion: " + pd.wholeBodyPerfusion.ToString() + "\n" +
            "Capillary Refill: " + pd.capillaryRefillInit.ToString() + "\n" +

            "\n### D - Disability ###\n" +
            "Glasgow Coma Scale: " + pd.glasgowComaScaleInit.ToString() + "\n" +
            "Pupil Reaction: " + pd.pupilReactionInit.ToString() + "\n" +
            "Repetitive Questining: " + pd.repetitiveQuestining.ToString() + "\n" +

            "\n### D - Devices / Pain assessment and location of pain ###\n" +
            "Has Internal Devices: " + pd.hasInternalDevices.ToString() + "\n" +
            "Has Cannula: " + pd.hasCannula.ToString() + "\n" +

            "\n### E - Environment ###\n" +
            "Has Fever: " + pd.hasFever.ToString() + "\n";
        return returnString;
    }

}
