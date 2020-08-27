using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_ : MonoBehaviour
{
    public GameObject crosshair;


    void Start()
    {
        crosshair.SetActive(true);


     }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            crosshair.SetActive(true);
        }
        else
        {
            crosshair.SetActive(true);
        }
    }
}
