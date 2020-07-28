using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_RaycastDrag : MonoBehaviour
{
    public bool dragging = false;
    public float distance;
    public Transform dragTransform;
    public Vector3 dragPoint;
    public Vector3 dragPointToLocalOrigin;
    public RaycastHit hit;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LMBDown();
        }

        if (Input.GetMouseButtonDown(0))
        {
            LMBDrag();
        }


        if (Input.GetMouseButtonDown(0))
        {
            LMBUp();
        }


    }

    private void LMBDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        dragging = Physics.Raycast(ray, out hit);

        if (dragging)
        {
            dragPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, hit.distance);
            dragPoint = Camera.main.ScreenToWorldPoint(dragPoint);
            dragPointToLocalOrigin = hit.transform.position - dragPoint;
        }
    }

    private void LMBDrag()
    {
        

        if (dragging)
        {
            dragPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, hit.distance);
            dragPoint = Camera.main.ScreenToWorldPoint(dragPoint);
            hit.transform.position = dragPoint + dragPointToLocalOrigin;
        }
    }

    private void LMBUp()
    {
        dragging = false;
    }
}
