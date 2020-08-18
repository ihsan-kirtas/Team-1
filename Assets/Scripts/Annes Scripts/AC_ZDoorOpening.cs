using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_ZDoorOpening : MonoBehaviour
{
    public Animator leftDoorOpening;
    public Animator rightDoorOpening;
    public AudioSource doorOpening;

    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Animation - Play
            leftDoorOpening.SetBool("Left Door", true);
            rightDoorOpening.SetBool("RightDoor", true);

          
            // Sound - Un-Pause
            doorOpening.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Animation - Stop
            leftDoorOpening.SetBool("Left Door", false);
            rightDoorOpening.SetBool(" RightDoor ", false);


            // Sound - Pause
            doorOpening.Pause();
        }
    }

}
