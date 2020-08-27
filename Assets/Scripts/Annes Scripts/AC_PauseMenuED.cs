using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AC_PauseMenuED : MonoBehaviour
{
    public GameObject pauseMenuUIPanel;             // This is for the panel that is used to darken the screen when the game is paused. The Pause Menu UI is under this.
    public GameObject pauseMenuUI;                  // This is the Pause Menu UI which is under the panel - connect this to PauseMenuUIBackground in Unity
    public GameObject settingsMenuUI;               // Connect this to SettingMenuUIBackground in Unity
    public GameObject terminologyPageUI;            // Connect this to TerminologyPageBackground in Unity
    public GameObject uiDotForLooking;
    public static bool GameIsPaused = false;
   

    private void Start()
    {
        pauseMenuUIPanel.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }    
        }
    }

    public void Resume()
    {
        pauseMenuUIPanel.SetActive(false);          // Turns off the Pause Menu Panel
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        uiDotForLooking.SetActive(true);
        Time.timeScale = 1f;                        // Resumes the game at normal speed
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUIPanel.SetActive(true);           // Turns on the Pause Menu Panel
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        uiDotForLooking.SetActive(false);
        Time.timeScale = 0f;                        // Pauses the game
        GameIsPaused = true;
    }

    public void RestartFreeRoam()
    {
        pauseMenuUIPanel.SetActive(false);          // Turns off the Pause Menu Panel
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 1f;                        // Resumes the game at normal speed

        SceneManager.LoadScene("Start Menu");       // Using scene name as no Index exist currently
    }

    public void ExitToDesktop()
    {
        Application.Quit();                         // Quits the application
    }
}


