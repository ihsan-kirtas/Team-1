using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AC_TriageSwitch : MonoBehaviour
{
    public int triagescore = 5;


    void Greet()
    {
        switch (triagescore)
        {
            case 5:
                print("Triage Score 5");
                break;
            case 4:
                print("Triage Score 4");
                break;
            case 3:
                print("Triage Score 3");
                break;
            case 2:
                print("Triage Score 2");
                break;
            case 1:
                print("Triage Score 1");
                break;
            default:
                print("");
                break;
        }
    }
}


