using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAnimationCintroller : MonoBehaviour
{
    public static bool mainstart=true ;
    public GameObject title;
    public GameObject mainAnimation;
    public Animator animator;

    IEnumerator Start()
    {
        //animator = GetComponent<Animator>();
        if (mainstart == true)
        yield return new WaitForSeconds(9);
        mainstart = false;
        title.SetActive(true);
        mainAnimation.SetActive(false);
        animator.SetBool("QuickView", true);
    }

    // Update is called once per frame
    void Update()
    {
       


    }

}
