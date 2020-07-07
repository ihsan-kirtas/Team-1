using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_AnimationController : MonoBehaviour
{
    [SerializeField] Animator myAnimatorController;
    //public GameObject NPC;
    bool idleTrue = false;

    private void Start()
    {
        idleTrue = false;
    }


    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Assistant 3 NPC"))
        {

            idleTrue = true;
            //myAnimatorController.SetBool("IdleTrue", true);
        }
        
    }

    
}
