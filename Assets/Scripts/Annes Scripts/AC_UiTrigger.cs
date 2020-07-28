using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AC_UiTrigger : MonoBehaviour
{
    public GameObject uiTextObject;
    public GameObject tutText;
    
    public void Start()
    {
        uiTextObject.SetActive(false);
        tutText.SetActive(false);
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag=="Player")
        {
            uiTextObject.SetActive(true);
            tutText.SetActive(true);
            Debug.Log("player entered trigger");
        }

        
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {

            Destroy(uiTextObject);
            Destroy(tutText);
            //uiTextObject.SetActive(false);
            //tutText.SetActive(false);
            //Debug.Log("player exited trigger");
        }
    }
}
