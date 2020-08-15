using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chartsUIPageManager : MonoBehaviour
{
    private GameObject gameManager;

    private GameObject resultsPage;
    private GameObject patientTransferPage;
    private GameObject obsChartPage;
    private GameObject initialObsPage;
    private GameObject patientInfoPage;
    
    private void Start()
    {
        // Find Game Manager
        gameManager = GameObject.Find("GameManager");

        // Link panels
        resultsPage = gameManager.GetComponent<CanvasManager>().resultsPagePanel;
        patientTransferPage = gameManager.GetComponent<CanvasManager>().patientInfoPagePanel;
        obsChartPage = gameManager.GetComponent<CanvasManager>().obsChartPagePanel;
        initialObsPage = gameManager.GetComponent<CanvasManager>().initialObsPagePanel;
        patientInfoPage = gameManager.GetComponent<CanvasManager>().patientInfoPagePanel;
    }

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
                resultsPage.SetActive(true);
                resultsPage.GetComponent<ResultsPageController>().UpdateResultsPage();    // Update the values
                break;
            case "transfer":
                patientTransferPage.SetActive(true);
                patientTransferPage.GetComponent<PatientTransferPageController>().UpdatePatientTransferPage();    // Update the values
                break;
            case "obs chart":
                obsChartPage.SetActive(true);
                obsChartPage.GetComponent<ObsChartPageController>().UpdateObsChartPage();    // Update the values
                break;
            case "initial obs":
                initialObsPage.SetActive(true);
                initialObsPage.GetComponent<InitiallObsPageController>().UpdateInitialObsPage();    // Update the values
                break;
            case "patient info":
                patientInfoPage.SetActive(true);
                patientInfoPage.GetComponent<PatientInformationPageController>().UpdatePatientInformationPage();    // Update the values

                break;
            default:
                Debug.LogError("Wrong page name entered on chart ui button");
                break;
        }
    }
}
