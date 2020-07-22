
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    public GameObject mainMenuUI;                           //This is called MainMenuUIButtons in the editor
    public GameObject mainMenuSettingMenuUI;                //This currently does not exist and has a stand in
    public GameObject creditPageStandIn;                    //This is currently a stand in and may not be used like this in the final build

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
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

    public void Credits()
    {
        //SceneManager.LoadScene("___");                      //This is the most probable way this will work and the functionality is coded - for now the UI element is a stand in to shown functionality.
        creditPageStandIn.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void CreditsReturnToMainMenu()
    {
        mainMenuUI.SetActive(true);
        mainMenuUI.GetComponent<Animator>().enabled = false;
        creditPageStandIn.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Quiet Application");
        Application.Quit();
    }
}
