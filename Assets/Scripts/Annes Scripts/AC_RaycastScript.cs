using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AC_RaycastScript : MonoBehaviour
{
    //[SerializeField] private Animator myAnimationController;
    public Camera fpsCam;
    public float range = 5f;

    

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            OpenCloseDoor();
        }
    }

    void OpenCloseDoor()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            PlayAnimation();
            Debug.Log("door handle hit");
        }


    }

    void PlayAnimation()
    {
        //myAnimationController.SetBool("PlayDoorOpen", true);
        GetComponent<Animation>().Play();
        Debug.Log("animation plays");
    }
}

