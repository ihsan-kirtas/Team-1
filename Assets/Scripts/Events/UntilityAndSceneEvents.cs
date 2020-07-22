using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UntilityAndSceneEvents : MonoBehaviour
{

    private void Start()
    {
        // SUBSCRIBE TO EVENTS

        // Close Application
        GameEvents.current.onCloseApplication += CloseApplication;

        // Go to Start Menu
        GameEvents.current.onGoToStartMenu += GoToStartMenu;

        // Go to Tutorial
        GameEvents.current.onGoToTutorial += GoToTutorial;

        // Go to Main Scene
        GameEvents.current.onGoToMainScene += GoToMainScene;

    }

    private void OnDestroy()
    {
        // UNSUBSCRIBE TO EVENTS

        // Close Application
        GameEvents.current.onCloseApplication -= CloseApplication;

        // Go to Start Menu
        GameEvents.current.onGoToStartMenu -= GoToStartMenu;

        // Go to Tutorial
        GameEvents.current.onGoToTutorial -= GoToTutorial;

        // Go to Main Scene
        GameEvents.current.onGoToMainScene -= GoToMainScene;
    }

    private void Placeholder()
    {
        Debug.Log("Placeholder Triggered");
    }

    private void CloseApplication()
    {
        Application.Quit();
    }


    private void GoToStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }


    private void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    private void GoToMainScene()
    {
        SceneManager.LoadScene("Main Scene");
    }


}
