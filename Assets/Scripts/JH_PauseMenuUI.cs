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

    private void Start()
    {
        GameEvents.current.event_escapePressed += EscapePressed;                                // SUBSCRIBE to Escape Pressed event

        gameManager = GameObject.Find("GameManager");                                           // Link Game Manager
        pauseMenuUIPanel = gameManager.GetComponent<CanvasManager>().pauseMenuMasterPanel;      // Main background panel
        pauseMenuUI = gameManager.GetComponent<CanvasManager>().pauseMenuHomePage;              // Pause menu home page
        settingsMenuUI = gameManager.GetComponent<CanvasManager>().pauseMenuSettingsPage;       // Pause menu settings page
    }

    private void OnDestroy()
    {
        GameEvents.current.event_escapePressed -= EscapePressed;                                // UN SUBSCRIBE to Escape Pressed
    }

    void EscapePressed()                            // Called on event_escapePressed
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

    public void Restart()
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

        SceneManager.LoadScene("TutorialScene");    //Using scene names as Index hasn't been worked on yet. This will need to be changed in the script - I forgot how to make it changable in Unity
    }

    public void SettingsMenu()                      // SWITCH PAGES
    {
        pauseMenuUI.SetActive(false);               // Turn OFF Pause BG panel
        settingsMenuUI.SetActive(true);             // Turn ON Settings BG panel
    }

    public void ReturnToPauseMenu()                 // SWITCH PAGES
    {
        settingsMenuUI.SetActive(false);            // Turn OFF Settings BG panel
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
