using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JH_PauseMenuUI : MonoBehaviour
{
    public bool GameIsPaused = false;
    private GameObject gameManager;                  // GameManager
    private GameObject pauseMenuUIPanel;             // This is for the panel that is used to darken the screen when the game is paused. The Pause Menu UI is under this.
    private GameObject pauseMenuUI;                  // This is the Pause Menu UI which is under the panel - connect this to PauseMenuUIBackground in Unity
    private GameObject settingsMenuUI;               // Connect this to SettingMenuUIBackground in Unity
    private GameObject terminologyPageUI;            // Connect this to TerminologyPageBackground in Unity

    private void Start()
    {
        GameEvents.current.event_pPressed += PPressed;                                // SUBSCRIBE to Escape Pressed event

        gameManager = GameObject.Find("GameManager");                                           // Link Game Manager
        pauseMenuUIPanel = gameManager.GetComponent<CanvasManager>().pauseMenuMasterPanel;      // Main background panel
        pauseMenuUI = gameManager.GetComponent<CanvasManager>().pauseMenuHomePage;              // Pause menu home page
        settingsMenuUI = gameManager.GetComponent<CanvasManager>().pauseMenuSettingsPage;       // Pause menu settings page
        terminologyPageUI = gameManager.GetComponent<CanvasManager>().terminologyPage;          // Medical terminology page
    }

    private void OnDestroy()
    {
        GameEvents.current.event_pPressed -= PPressed;                                // UN SUBSCRIBE to Escape Pressed
    }

    void PPressed()                            // Called on event_escapePressed
    {
        if (pauseMenuUIPanel.activeSelf) 
        { 
            Resume(); 
        } 
        else 
        { 
            Pause(); 
        }
    }

    public void Resume()
    {
        pauseMenuUIPanel.SetActive(false);          // Turns off the Pause Menu Panel
        GameEvents.current.CheckCameraLock();       // Checks wheather to Lock / Unlock Camera
        
        Time.timeScale = 1f;                        // Resumes the game at normal speed
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUIPanel.SetActive(true);           // Turns on the Pause Menu Panel
        GameEvents.current.CheckCameraLock();       // Checks wheather to Lock / Unlock Camera
        
        Time.timeScale = 0f;                        // Pauses the game
        GameIsPaused = true;
    }

    public void RestartMain()
    {
        pauseMenuUIPanel.SetActive(false);          // Turns off the Pause Menu Panel
        GameEvents.current.CheckCameraLock();       // Checks wheather to Lock / Unlock Camera

        Time.timeScale = 1f;                        // Resumes the game at normal speed
        GameIsPaused = false;

        SceneManager.LoadScene("Main Scene");       //Using scene names as Index hasn't been worked on yet. This will need to be changed in the script - I forgot how to make it changable in Unity
    }

    public void RestartTutorial()
    {
        pauseMenuUIPanel.SetActive(false);          // Turns off the Pause Menu Panel
        GameEvents.current.CheckCameraLock();       // Checks wheather to Lock / Unlock Camera

        Time.timeScale = 1f;                        // Resumes the game at normal speed
        GameIsPaused = false;

        SceneManager.LoadScene("NewTutScene");    //Using scene names as Index hasn't been worked on yet. This will need to be changed in the script - I forgot how to make it changable in Unity
    }

    public void RestartFreeRoam()
    {
        pauseMenuUIPanel.SetActive(false);          // Turns off the Pause Menu Panel
        GameEvents.current.CheckCameraLock();       // Checks wheather to Lock / Unlock Camera

        Time.timeScale = 1f;                        // Resumes the game at normal speed
        GameIsPaused = false;

        SceneManager.LoadScene("Emergency Dept");    //Using scene names as Index hasn't been worked on yet. This will need to be changed in the script - I forgot how to make it changable in Unity
    }

    public void SettingsMenu()                      // SWITCH PAGES
    {
        pauseMenuUI.SetActive(false);               // Turn OFF Pause BG panel
        settingsMenuUI.SetActive(true);             // Turn ON Settings BG panel
    }

    public void SettingsReturnToPauseMenu()         // SWITCH PAGES
    {
        settingsMenuUI.SetActive(false);            // Turn OFF Settings BG panel
        pauseMenuUI.SetActive(true);                // Turn ON Pause BG panel
    }

    public void TerminologyPage()                   // SWITCH PAGES
    {
        pauseMenuUI.SetActive(false);               // Turn OFF Pause BG panel
        terminologyPageUI.SetActive(true);          // Turn ON Terminology BG panel
    }

    public void TerminologyReturnToPauseMenu()      // SWITCH PAGES
    {
        terminologyPageUI.SetActive(false);         // Turn OFF Terminology BG panel
        pauseMenuUI.SetActive(true);                // Turn ON Pause BG panel
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;                        // Resumes the game at normal speed
        SceneManager.LoadScene("Start Menu");       // Using scene name as no Index exist currently
    }

    public void ExitToDesktop()
    {
        Application.Quit();                         // Quits the application
    }
}
