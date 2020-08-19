using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AC_ShowDateTime : MonoBehaviour
{

    public Text timedateBox;
   

    public float drawDataFrequency = 300;
    private float frameRecord = 0;
    

    public void showData()
    {
       timedateBox.text= PlayerPrefs.GetString("DateTime", "").ToString();
        Debug.Log("updated date and time");
    }

    private void Start()
    {
        showData();
    }


    private void Update()
    {
       
        // Only check every x frames - efficiency
        if (Time.frameCount > frameRecord + drawDataFrequency)
        {
            // if panel active and patient data exists
            
                
            //else
            //   showData();
            frameRecord = Time.frameCount;  // Record time when this happened
        }
        
    }
}
