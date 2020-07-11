using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_HighlightObject : MonoBehaviour
{
    public GameObject selectedObject;
    public int redCol;
    public int greenCol;
    public int blueCol;
    public bool lookingAtObject = false; //if we are looking at object we want the object to flash as an interactable
    public bool flashingIn = true;
    public bool startedFlashing = false;


    void Update()
    {
        if (lookingAtObject == true)
        {
            selectedObject.GetComponent<Renderer>().material.color = new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255);
        }
    }


     void OnMouseOver()
    {
        selectedObject = GameObject.Find(AC_castingObject.selectedObject);
        lookingAtObject = true;
        if (startedFlashing == false)
        {
            startedFlashing = true;
            StartCoroutine(FlashObject());

        }
           
    }

     void OnMouseExit()
    {
        startedFlashing = false;
        lookingAtObject = false;
        StopCoroutine(FlashObject());
        selectedObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
    }

    IEnumerator FlashObject()
    {
        while (lookingAtObject == true)
        {
            yield return new WaitForSeconds(0.1f);
            if (flashingIn == true)
            {
                if (blueCol <= 30)
                {
                    flashingIn = false;
                }
                else
                {
                    redCol -= 25;
                    greenCol -= 1;
                }
            }

            if (flashingIn ==false)
            {
                if (blueCol >= 250)
                {
                    flashingIn = true;
                }

                else
                {
                    redCol += 25;
                    greenCol += 1;

                }
            }
            
        }
    }

}
