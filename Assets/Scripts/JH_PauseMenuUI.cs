using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class JH_PauseMenuUI : MonoBehaviour
{
    public bool GameIsPaused = true;

    public GameObject pauseMenuUIPanel;             //This is for the panel that is used to darken the screen when the game is paused. The Pause Menu UI is under this.
    public GameObject pauseMenuUI;                  //This is the Pause Menu UI which is under the panel - connect this to PauseMenuUIBackground in Unity
    public GameObject settingsMenuUI;               //Connect this to SettingMenuUIBackground in Unity

    private void Start()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        
        //Game Events Subscription
        //GameEvents.current.event_showPauseMenuUI += Pause;
        //GameEvents.current.event_hidePauseMenuUI += Resume;
    }

    //private void OnDestroy()
    //{
    //    //Game Events Unsubscription
    //    GameEvents.current.event_showPauseMenuUI -= Pause;
    //    GameEvents.current.event_hidePauseMenuUI -= Resume;
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        pauseMenuUIPanel.SetActive(false);
        //Cursor.lockState = CursorLockMode.Locked; 
        //Cursor.visible = false;                   //Unsure if these are needed but I'm adding them in case
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUIPanel.SetActive(true);
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        pauseMenuUIPanel.SetActive(false);
        //Cursor.lockState = CursorLockMode.Locked; 
        //Cursor.visible = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Main Scene");       //Using scene names as Index hasn't been worked on yet. This will need to be changed in the script - I forgot how to make it changable in Unity
    }

    public void RestartTutorial()
    {
        pauseMenuUIPanel.SetActive(false);
        //Cursor.lockState = CursorLockMode.Locked; 
        //Cursor.visible = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("TutorialScene");       //Using scene names as Index hasn't been worked on yet. This will need to be changed in the script - I forgot how to make it changable in Unity
    }

    public void SettingsMenu()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    public void ReturnToPauseMenu()
    {
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void ExitToMenu()
    {
        //Cursor.lockState = CursorLockMode.None; 
        //Cursor.visible = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Menu");       //Using scene name as no Index exist currently
    }

    public void ExitToDesktop()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
