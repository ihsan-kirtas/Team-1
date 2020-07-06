using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AC_RaycastScript : MonoBehaviour
{
    public RaycastHit hit;
    public Ray ray;

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);



        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider != null)
                {
                    hit.collider.enabled = true;
                    Debug.Log(hit.transform.name);
                }
            }

            

           
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

