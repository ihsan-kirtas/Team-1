﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class GraphPlotter : MonoBehaviour
{
    public RectTransform graphContainer;
    public List<GameObject> currentGraphObjects;
    public Color lineColor;
    public GameObject noDataAvailableMessage;

    
    public List<float> tracker;
    private Patient_Data currentPatientData;


    private int heightSegments;
    private int widthSegments = 21;

    // Graph limits and zones
    private float graphMax;
    private float graphHighMax;
    private float graphHighMin;
    private float graphLowMax;
    private float graphLowMin;
    private float graphMin;

    private int maxZoneBoxStart;
    private int maxZoneBoxSpan;
    private int highZoneBoxStart;
    private int highZoneBoxSpan;
    private int normalZoneBoxStart;
    private int normalZoneBoxSpan;
    private int lowZoneBoxStart;
    private int lowZoneBoxSpan;
    private int MinZoneBoxStart;
    private int MinZoneBoxSpan;



    


    [Header("Choose Chart - Tick only 1")]
    public bool usingBreathRateTracker;

    private bool usingBloodPressureDiastolicTracker;
    private bool usingBloodPressureSystolicTracker;
    private bool usingOxygenTracker;
    private bool usingPulseRateTracker;
    private bool usingCapillaryRefillTracker;
    private bool usingGlasgowComaScaleTracker;
    private bool usingPupilReactionTracker;


    private void Start()
    {
        // Subscribe to events
        //GameEvents.current.event_updatePatientData += UpdateValues;

        //noDataAvailable.SetActive(true);

        // Draws the borders, zones and guide lines.
        //DrawBorders();

        
        SetGraphBGData();   // Sets the chart BG and value data (only needed once)
        DrawBackground();   // Draws the Chart BG
    }

    private void OnDestroy()
    {
        // Unsubscribe to events
        //GameEvents.current.event_updatePatientData -= UpdateValues;
    }

    private void UpdateValues()
    {
        // Delete all current graph items ready for new items
        if (currentGraphObjects.Count > 0)
        {
            foreach (GameObject item in currentGraphObjects)
            {
                Destroy(item);
            }
        }


        // check / link the current patient data
        currentPatientData = GameObject.Find("Player").GetComponent<DialogManager>().currentPatient;


        noDataAvailableMessage.SetActive(false);



        if (currentPatientData != null)
        {

            float listLength = tracker.Count;
            float xSpacingPercentage = 0.1f;
            float xSpacing = graphContainer.rect.width * xSpacingPercentage;

            float graphHeight = graphContainer.rect.height;
            float graphYrange = graphMax - graphMin;

            GameObject lastCircleGameObject = null;


            string currentValue = tracker.Last().ToString();



            for (int i = 0; i < listLength; i++)
            {
                // Calculate X
                float xPos = i * xSpacing;                                  // TODO issues with > 10 values

                // Calculate Y
                float obValue = tracker[i];                                 // Ob Value
                float yPercent = (obValue - graphMin) / graphYrange;        // percentage of the allowable range
                float yPos = yPercent * graphHeight;                        // apply to graph height

                // Plot point on graph - get the GO it returns
                GameObject circleGameObject = PlotPoint(new Vector2(xPos, yPos));

                if (lastCircleGameObject != null)
                {
                    // Join the previous point to this point with a line - LinkPoints(PosA, PosB)
                    LinkPoints(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);

                }
                lastCircleGameObject = circleGameObject;

            }
        }
        else
        {
            Debug.Log("NO GRAPH DATA AVAILABLE");

            noDataAvailableMessage.SetActive(true);

        }
    }


    void DrawBackground()
    {
        Debug.Log("background called");

        // Build layers in REVERSE ORDER: CreateBox(name, start at segment 8, spans how many segments)
        CreateBox("maxZoneBox", maxZoneBoxStart, maxZoneBoxSpan);
        CreateBox("highZoneBox", highZoneBoxStart, highZoneBoxSpan);
        CreateBox("normalZoneBox", normalZoneBoxStart, normalZoneBoxSpan);
        CreateBox("lowZoneBox", lowZoneBoxStart, lowZoneBoxSpan);
        CreateBox("MinZoneBox", MinZoneBoxStart, MinZoneBoxSpan);
    }

    // Draw Background Boxes
    GameObject CreateBox(string boxName, int start_seg, int span)
    {
        Debug.Log("create box initiated");


        GameObject box = new GameObject(boxName, typeof(Image));           // Create GO
        box.transform.SetParent(graphContainer, false);                    // Sets parent to this graph GO




        // Set color
        Color chartRed = new Color(1f, 0f, 0f, 0.5f);
        Color chartYellow = new Color(1f, 1f, 0f, 0.5f);
        Color chartNormal = new Color(1f, 1f, 1f, 0.5f);
        if (boxName == "maxZoneBox")
        { box.GetComponent<Image>().color = chartRed; }
        else if(boxName == "highZoneBox")
        { box.GetComponent<Image>().color = chartYellow; }
        else if (boxName == "normalZoneBox")
        { box.GetComponent<Image>().color = chartNormal; }
        else if (boxName == "lowZoneBox")
        { box.GetComponent<Image>().color = chartYellow; }
        else if (boxName == "MinZoneBox")
        { box.GetComponent<Image>().color = chartRed; }
        else  //Error
        { box.GetComponent<Image>().color = Color.magenta; }


        float segmentSize = graphContainer.sizeDelta.y / heightSegments;

        RectTransform box_rt = box.GetComponent<RectTransform>();


        float startPosY = (segmentSize * start_seg) - (span*segmentSize);               // Bottom Left of box
        box_rt.anchoredPosition = new Vector2(0,startPosY);                             // Set Position
          
        box_rt.sizeDelta = new Vector2(graphContainer.sizeDelta.x, span*segmentSize);   // Set size

        box_rt.anchorMin = new Vector2(0, 0);                                           // Set Anchors
        box_rt.anchorMax = new Vector2(0, 0);
        box_rt.pivot = new Vector2(0, 0);



        return box;
    }


    void drawData()
    {

    }

    void PlotPoint_(int xSegment, int ySegment)
    {

    }



    private GameObject PlotPoint(Vector2 position)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));                // Create a new game object, Type: Image, name: circle
        currentGraphObjects.Add(gameObject);                                            // Add new object to list so they can all be deleted on refresh
        gameObject.transform.SetParent(graphContainer, false);                          // Make circle a child of the graph container
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();         // Get the rect transform
        rectTransform.anchoredPosition = position;                                      // Set a new position for that rect transform
        rectTransform.sizeDelta = new Vector2(11, 11);                                  // ?? size delta ??

        rectTransform.anchorMin = new Vector2(0, 0);                                    // Anchor to lower left corner
        rectTransform.anchorMax = new Vector2(0, 0);                                    // Anchor to lower left corner

        return gameObject;                                                              // Returns the game object so we can use it to make the connecting lines.
    }


    private void LinkPoints(Vector2 pointPosA, Vector2 pointPosB)
    {
        GameObject gameObject = new GameObject("link", typeof(Image));                  // create new link GO
        currentGraphObjects.Add(gameObject);                                            // Add new object to list so they can all be deleted on refresh
        gameObject.transform.SetParent(graphContainer, false);                          // Set parent
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, .5f);               // Set line colour
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();         // Get rect transform
        Vector2 dir = (pointPosB - pointPosA).normalized;                               // Line Direction
        float distance = Vector2.Distance(pointPosA, pointPosB);                        // Line Distance
        rectTransform.anchorMin = new Vector2(0, 0);                                    // Set anchor
        rectTransform.anchorMax = new Vector2(0, 0);                                    // Set anchor
        rectTransform.sizeDelta = new Vector2(80, 3f);                                 // Set size delta
        rectTransform.anchoredPosition = pointPosA + dir * distance * .5f;              // Half way between A and B

        Vector2 forward = new Vector2(1, 0);
        float angle = Vector2.Angle(forward, dir);                                      // Get line angle

        rectTransform.localEulerAngles = new Vector3(0, 0, angle);                      // Apply angle to new line
    }

    private void SetGraphBGData()
    {
        if (usingBreathRateTracker)
        {
            graphMax = 40f;          // Chart Max
            graphHighMax = 30f;      // High zone Max
            graphHighMin = 25f;      // High zone Min
            graphLowMax = 10f;       // Low zone Max
            graphLowMin = 5f;        // Low zone Min
            graphMin = 0f;           // Chart Min

            heightSegments = 8;      // How many segments should the chart be broken into

            maxZoneBoxStart = 8;    // Start segment from top down
            maxZoneBoxSpan = 2;     // spans for x segments
            highZoneBoxStart = 6;
            highZoneBoxSpan = 1;
            normalZoneBoxStart = 5;
            normalZoneBoxSpan = 2;
            lowZoneBoxStart = 3;
            lowZoneBoxSpan = 1;
            MinZoneBoxStart = 2;
            MinZoneBoxSpan = 2;
        }







        if (usingBloodPressureDiastolicTracker)
        {
            graphMax = 40f;          // Chart Max
            graphHighMax = 30f;      // High zone Max
            graphHighMin = 25f;      // High zone Min
            graphLowMax = 10f;       // Low zone Max
            graphLowMin = 5f;        // Low zone Min
            graphMin = 0f;           // Chart Min
            heightSegments = 8;      // How many segments should the chart be broken into

            //graphMax = 180;
            //graphHigh = 140;
            //graphLow = 60;
            //graphMin = 50;

        }
        if (usingBloodPressureSystolicTracker)
        {
            graphMax = 40f;          // Chart Max
            graphHighMax = 30f;      // High zone Max
            graphHighMin = 25f;      // High zone Min
            graphLowMax = 10f;       // Low zone Max
            graphLowMin = 5f;        // Low zone Min
            graphMin = 0f;           // Chart Min
            heightSegments = 8;      // How many segments should the chart be broken into

            //graphMax = 200;
            //graphHigh = 160;
            //graphLow = 110;
            //graphMin = 80;


        }
        if (usingOxygenTracker)
        {
            graphMax = 40f;          // Chart Max
            graphHighMax = 30f;      // High zone Max
            graphHighMin = 25f;      // High zone Min
            graphLowMax = 10f;       // Low zone Max
            graphLowMin = 5f;        // Low zone Min
            graphMin = 0f;           // Chart Min
            heightSegments = 8;      // How many segments should the chart be broken into

            //graphMax = 150;
            //graphHigh = 130;
            //graphLow = 60;
            //graphMin = 50;

        }


        if (usingPulseRateTracker)
        {
            graphMax = 40f;          // Chart Max
            graphHighMax = 30f;      // High zone Max
            graphHighMin = 25f;      // High zone Min
            graphLowMax = 10f;       // Low zone Max
            graphLowMin = 5f;        // Low zone Min
            graphMin = 0f;           // Chart Min
            heightSegments = 8;      // How many segments should the chart be broken into

            //graphMax = 200;
            //graphHigh = 150;
            //graphLow = 50;
            //graphMin = 20;

        }
        if (usingCapillaryRefillTracker)
        {
            graphMax = 40f;          // Chart Max
            graphHighMax = 30f;      // High zone Max
            graphHighMin = 25f;      // High zone Min
            graphLowMax = 10f;       // Low zone Max
            graphLowMin = 5f;        // Low zone Min
            graphMin = 0f;           // Chart Min
            heightSegments = 8;      // How many segments should the chart be broken into

            //graphMax = 10;
            //graphHigh = 5;
            //graphLow = 1;
            //graphMin = 0;

        }
        if (usingGlasgowComaScaleTracker)
        {
            graphMax = 40f;          // Chart Max
            graphHighMax = 30f;      // High zone Max
            graphHighMin = 25f;      // High zone Min
            graphLowMax = 10f;       // Low zone Max
            graphLowMin = 5f;        // Low zone Min
            graphMin = 0f;           // Chart Min
            heightSegments = 8;      // How many segments should the chart be broken into

            //graphMax = 30;
            //graphHigh = 20;
            //graphLow = 5;
            //graphMin = 1;

        }
        if (usingPupilReactionTracker)
        {
            graphMax = 40f;          // Chart Max
            graphHighMax = 30f;      // High zone Max
            graphHighMin = 25f;      // High zone Min
            graphLowMax = 10f;       // Low zone Max
            graphLowMin = 5f;        // Low zone Min
            graphMin = 0f;           // Chart Min
            heightSegments = 8;      // How many segments should the chart be broken into

            //graphMax = 10;
            //graphHigh = 8;
            //graphLow = 2;
            //graphMin = 0;

        }
    }
}
