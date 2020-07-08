using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AC_UiTrigger : MonoBehaviour
{
    public GameObject uiTextObject;
    
    public void Start()
    {
        uiTextObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Player"))
        {
            uiTextObject.SetActive(true);
            Debug.Log("player entered trigger");
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.CompareTag("Player"))
        {
            uiTextObject.SetActive(false);
            Debug.Log("player exited trigger");
        }
    }
}
