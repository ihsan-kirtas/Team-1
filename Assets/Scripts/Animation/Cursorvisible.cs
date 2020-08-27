using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursorvisible : MonoBehaviour
{
    public bool cursorvisibility;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cursorvisibility == true)
        {
            Cursor.visible = true;
        }
        
        if (cursorvisibility == false)
        {
            Cursor.visible = false;
        }
    }
}
