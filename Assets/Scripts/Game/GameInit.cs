using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Check to make sure cursor lock / ui is all good
        GameEvents.current.CheckCameraLock();
    }


}
