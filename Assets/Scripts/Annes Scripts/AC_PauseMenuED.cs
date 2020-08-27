using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AC_PauseMenuED : MonoBehaviour
{
    public GameObject pauseMenuUIPanel;             // This is for the panel that is used to darken the screen when the game is paused. The Pause Menu UI is under this.
    public GameObject pauseMenuUI;                  // This is the Pause Menu UI which is under the panel - connect this to PauseMenuUIBackground in Unity
    public GameObject settingsMenuUI;               // Connect this to SettingMenuUIBackground in Unity
    public GameObject terminologyPageUI;
    public static bool GameIsPaused = false;
   
    


    private void Start()
    {
        
        pauseMenuUI.SetActive(false);
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
        pauseMenuUI.SetActive(false);
        
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

   public void Pause()
    {
        pauseMenuUI.SetActive(true);
        
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

   


    public void RestartFreeRoam()
    {
        pauseMenuUI.SetActive(false);          // Turns off the Pause Menu Panel
        GameEvents.current.CheckCameraLock();       // Checks wheather to Lock / Unlock Camera

        Time.timeScale = 1f;                        // Resumes the game at normal speed
        GameIsPaused = false;

        SceneManager.LoadScene("Emergency Dept");    //Using scene names as Index hasn't been worked on yet. This will need to be changed in the script - I forgot how to make it changable in Unity
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

    //public void ShowSettingPanel()
    //{

    //    if (GameIsPaused)
    //    {
    //        settingsUI.SetActive(false);
    //        Time.timeScale = 0f;
    //    }
    //    else
    //    {
    //        settingsUI.SetActive(true);
    //        Time.timeScale = 0f;
    //    }

    //}


}


