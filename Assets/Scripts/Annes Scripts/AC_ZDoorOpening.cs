using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_ZDoorOpening : MonoBehaviour
{
    public Animator leftDoorOpening;
    public Animator rightDoorOpening;
     

   
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Patient"))
        {
            // Animation - Play

            leftDoorOpening.SetBool("LeftDoorOpen", true);
            rightDoorOpening.SetBool("RightDoorOpen", true);

            //leftDoorOpening.transform.position = new Vector3(0, 0, 2);
            //rightDoorOpening.transform.position = new Vector3(0.007935028f, -0.1499473f, -1.45f);
            Debug.Log("door opening");
            // Sound - Un-Pause
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Patient"))
        {
            // Animation - Play

            leftDoorOpening.SetBool("LeftDoorOpen", false);
            rightDoorOpening.SetBool("RightDoorOpen", false);

            //leftDoorOpening.transform.position = new Vector3(0, 0, 2);
            //rightDoorOpening.transform.position = new Vector3(0.007935028f, -0.1499473f, -1.45f);
            Debug.Log("door opening");
            // Sound - Un-Pause

        }
    }

}
