using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AC_UiTrigger : MonoBehaviour
{
    public GameObject uiTextObject;
    public GameObject tutText;
    //public GameObject button;
   
    
    public void Start()
    {
        uiTextObject.SetActive(false);
        tutText.SetActive(false);
        //button.SetActive(false);

    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag=="Player")
        {
            uiTextObject.SetActive(true);
            tutText.SetActive(true);
            //button.SetActive(true);

            Debug.Log("player entered trigger");

                       
        
        }

       

    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            uiTextObject.SetActive(false);
            tutText.SetActive(false);
            //button.SetActive(true);

            Debug.Log("player entered trigger");



        }



    }



    //public void OnButtonClick()
    //{
    //    uiTextObject.SetActive(false);
    //    tutText.SetActive(false);
    //    button.SetActive(false);

    //    Debug.Log("button click works");

    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        uiTextObject.SetActive(false);
    //        tutText.SetActive(false);
    //    }
    //}





}
