using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_HideGameObject : MonoBehaviour
{
    public GameObject patientBed;


    // Start is called before the first frame update
    void Start()
    {
        patientBed.SetActive(true);
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            patientBed.SetActive(false);
        }
    }
}
