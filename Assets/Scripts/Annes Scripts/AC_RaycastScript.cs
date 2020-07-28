using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AC_RaycastScript : MonoBehaviour
{
    public RaycastHit hit;
    public Ray ray;
    public GameObject uiTextObject;
    
    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        uiTextObject.SetActive(false);

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider!=null)
                {
                    
                    uiTextObject.SetActive(true);
                    Debug.Log(hit.transform.name);

                }

                else
                {
                    
                    uiTextObject.SetActive(false);
                }
            }

            //if (Input.GetButtonDown("escape"))
            //{
            //    uiTextObject.SetActive(false);
            //}

           
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

