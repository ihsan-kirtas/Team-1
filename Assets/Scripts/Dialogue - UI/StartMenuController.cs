
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public GameObject mainMenuUI;                           //This is called MainMenuUIButtons in the editor
    public GameObject mainMenuSettingMenuUI;                //This currently does not exist and has a stand in
    // public GameObject creditPageStandIn;                    //This is currently a stand in and may not be used like this in the final build
    public GameObject loadingScreen;                        //This is the loading screen animation

    public void StartGame()
    {
        StartCoroutine(loadingScreenCoroutineStart());      // This starts the load screen before going to Main Game scene
    }

    public void StartTutorial()                             // This starts the load screen before going to Tutorial scene
    {
        StartCoroutine(loadingScreenCoroutineTut());
    }

    public void StartFreeRoam()                             // This starts the load screen before going to Free Roam scene
    {
        StartCoroutine(loadingScreenCoroutineFreeRoam());
    }

    public void SettingMenuUI()
    {
        mainMenuSettingMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        mainMenuUI.SetActive(true);
        mainMenuUI.GetComponent<Animator>().enabled = false;
        mainMenuSettingMenuUI.SetActive(false);
    }

    public void StartPlayerTimes()                          // This starts the load screen before going to Player Data scene
    {                                                       // NOTE this could link to the wrong scene. Change this under the corresponding coroutine
        StartCoroutine(loadingScreenCoroutinePlayerTimes());
    }

    public void Credits()
    {
        StartCoroutine(loadingScreenCoroutineCredits());        // This is the most probable way this will work and the functionality is coded - for now the UI element is a stand in to shown functionality.
        //creditPageStandIn.SetActive(true);
        //mainMenuUI.SetActive(false);
    }

    //public void CreditsReturnToMainMenu()                   // This is a stand in function for current credits stand in. 
    //{                                                       // This will be deactivated when credits scene is made.
    //    mainMenuUI.SetActive(true);
    //    mainMenuUI.GetComponent<Animator>().enabled = false;
    //    creditPageStandIn.SetActive(false);
    //}

    public void ExitGame()
    {
        Debug.Log("Quiet Application");
        Application.Quit();
    }

    IEnumerator loadingScreenCoroutineStart()               // Coroutine for Start button
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main Scene");
        yield return new WaitForSeconds(1);
        loadingScreen.SetActive(false);
    }

    IEnumerator loadingScreenCoroutineTut()                 // Coroutine for Tutorial button
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("NewTutScene");
        yield return new WaitForSeconds(1);
        loadingScreen.SetActive(false);
    }
    IEnumerator loadingScreenCoroutineFreeRoam()            // Coroutine for Free Roam button
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Emergency Dept");
        yield return new WaitForSeconds(1);
        loadingScreen.SetActive(false);
    }

    IEnumerator loadingScreenCoroutinePlayerTimes()         // Coroutine for Player Data button
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Save Player Name 1");           // Change to correct scene here for player prefs if this is the incorrect scene. 
        yield return new WaitForSeconds(1);
        loadingScreen.SetActive(false);
    }

    IEnumerator loadingScreenCoroutineCredits()               // Coroutine for Credits button
    {
       // loadingScreen.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("CreditScene");                 // This scene name will need to be changed when this is a credits scene is made.
        yield return new WaitForSeconds(1);
       // loadingScreen.SetActive(false);
    }
}


//=======
//﻿
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class StartMenuController : MonoBehaviour
//{
//    public GameObject mainMenuUI;                           //This is called MainMenuUIButtons in the editor
//    public GameObject mainMenuSettingMenuUI;                //This currently does not exist and has a stand in
//    public GameObject creditPageStandIn;                    //This is currently a stand in and may not be used like this in the final build

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
    
//    public void StartGame()
//    {
//        SceneManager.LoadScene("Main Scene");
//    }

//    public void StartTutorial()
//    {
//        SceneManager.LoadScene("TutorialScene");
//    }
    
//    public void SettingMenuUI()
//    {
//        mainMenuSettingMenuUI.SetActive(true);
//        mainMenuUI.SetActive(false);
//    }

//    public void ReturnToMainMenu()
//    {
//        mainMenuUI.SetActive(true);
//        mainMenuUI.GetComponent<Animator>().enabled = false;
//        mainMenuSettingMenuUI.SetActive(false);
//    }

//    public void Credits()
//    {
//        //SceneManager.LoadScene("___");                      //This is the most probable way this will work and the functionality is coded - for now the UI element is a stand in to shown functionality.
//        creditPageStandIn.SetActive(true);
//        mainMenuUI.SetActive(false);
//    }

//    public void CreditsReturnToMainMenu()
//    {
//        mainMenuUI.SetActive(true);
//        mainMenuUI.GetComponent<Animator>().enabled = false;
//        creditPageStandIn.SetActive(false);
//    }

//    public void ExitGame()
//    {
//        Debug.Log("Quiet Application");
//        Application.Quit();
//    }
//}
//>>>>>>> Stashed changes
//>>>>>>> Stashed changes
