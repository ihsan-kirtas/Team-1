
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Temp bypass until start menu is ready
        SceneManager.LoadScene("Emergency Room");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("Emergency Room");
    }
}
