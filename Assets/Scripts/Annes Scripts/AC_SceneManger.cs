using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AC_SceneManger : MonoBehaviour
{
    public string myScene;

   public void loadScene()
    {
        SceneManager.LoadScene(myScene);
    }
}
