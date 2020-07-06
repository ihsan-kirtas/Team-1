using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_AnimationController : MonoBehaviour
{
    [SerializeField] Animator myAnimatorController;
    public GameObject NPC;

    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Assistant 3 NPC"))
        {
            myAnimatorController.SetBool("IdleTrue", true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Assistant 3 NPC"))
        {
            myAnimatorController.SetBool("IdleTrue", false);
        }

    }
}
