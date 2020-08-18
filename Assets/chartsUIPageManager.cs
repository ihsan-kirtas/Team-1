using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script contributors: James Siebert

public class chartsUIPageManager : MonoBehaviour
{
    public GameObject gameManager;

    public GameObject resultsPage;
    public GameObject patientTransferPage;
    public GameObject obsChartPage;
    public GameObject initialObsPage;
    public GameObject patientInfoPage;


    // This switches the active page on the Charts UI. Designed to connect to the UI buttons
    public void SwitchPanel(string showPanel)
    {

        // Turn all off
        resultsPage.SetActive(false);
        patientTransferPage.SetActive(false);
        obsChartPage.SetActive(false);
        initialObsPage.SetActive(false);
        patientInfoPage.SetActive(false);

        // Turn the selected page on
        switch (showPanel)
        {
            case "results":
                resultsPage.GetComponent<ResultsPageController>().UpdateResultsPage();    // Update the values
                resultsPage.SetActive(true);
                break;
            case "transfer":
                patientTransferPage.GetComponent<PatientTransferPageController>().UpdatePatientTransferPage();    // Update the values
                patientTransferPage.SetActive(true);
                break;
            case "obs chart":
                //obsChartPage.GetComponent<ObsChartPageController>().UpdateObsChartPage();    // Update the values
                obsChartPage.SetActive(true);
                break;
            case "initial obs":
                initialObsPage.GetComponent<InitiallObsPageController>().UpdateInitialObsPage();    // Update the values
                initialObsPage.SetActive(true);
                break;
            case "patient info":
                //Debug.Log("PATIENT INFO PAGE");
                patientInfoPage.GetComponent<PatientInformationPageController>().UpdatePatientInformationPage();    // Update the values
                patientInfoPage.SetActive(true);
                break;
            default:
                Debug.LogError("Wrong page name entered on chart ui button");
                break;
        }
    }
}
