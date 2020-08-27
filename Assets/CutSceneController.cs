using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CutSceneController : MonoBehaviour
{
    // Players camera which will be activated after the cutscene plays
    public GameObject playerCamera;

    // Turn always on panels on
    public GameObject alwaysOnUIPanel;

    public GameObject cinemachineMaster;

    void Start()
    {
        StartCoroutine(CutScene());
    }

    IEnumerator CutScene()
    {
        // Player camera off
        playerCamera.SetActive(false);

        // turn off Always on panel
        alwaysOnUIPanel.SetActive(false);

        // Cut scene auto plays for x seconds
        yield return new WaitForSeconds(5);

        // Turn player camera on for game play
        playerCamera.SetActive(true);

        // turn on Always on panel
        alwaysOnUIPanel.SetActive(true);

        // disable cinemachine hierachy
        cinemachineMaster.SetActive(false);
    }
}
