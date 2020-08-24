using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AC_RaycastScript : MonoBehaviour
{
    public float range = 50f;
    public Camera fpsCam;
    public float fadeTime;
    //public GameObject uiCanvas;
    public Text myText;
    public string objectName;
    public Ray ray;
    public  RaycastHit hit;

    public bool displayInfo;


    private void Start()

    {
        myText = GameObject.Find("Text").GetComponent<Text>();
        myText.color = Color.clear;
    }


    private void Update()
    {
       

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            displayInfo = true;
            FadeText();
        }

    }

    void FadeText()
    {
        if (displayInfo)
        {
            myText.text = objectName;
            myText.color = Color.Lerp(myText.color, Color.white, fadeTime * Time.deltaTime);
            Debug.Log("change object name");
        }

        else
        {
            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
        }
    }







    //public Camera playerCam;
    //public Ray ray;
    ////public float range = 2.0f;

    //private void Update()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {   

    //        //(RaycastHit.collider.gameObject)
    //        IdentifyObject();
    //    }

    //    RaycastHit hit;
    //    if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit))
    //    {
    //        Debug.Log(hit.transform.name);
    //    }
    //}

    //void IdentifyObject()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit))
    //    {
    //        Debug.Log(hit.transform.name);
    //    }
    //}
}

