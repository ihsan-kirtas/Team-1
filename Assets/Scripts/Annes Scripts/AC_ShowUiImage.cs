using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AC_ShowUiImage : MonoBehaviour
{
    public GameObject GregPatientJourney;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        GregPatientJourney.SetActive(false);
        StartCoroutine(PatientJourney());
    }

    IEnumerator PatientJourney()
    {
        yield return new WaitForSeconds (180);
        GregPatientJourney.SetActive(true);
        yield return new WaitForSeconds(15);
        GregPatientJourney.SetActive(false);
    }
}
