using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

// Script contributors: James Siebert

public class GraphPlotter : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;

    public RectTransform graphContainer;
    public RectTransform BGContainer;
    public RectTransform pointsContainer;
    public GameObject noDataAvailableMessage;

    public Sprite pointSprite;
    public Font pointFont;

    public float drawDataFrequency = 300f;
    private float frameRecord = 0f;


    private int heightSegments;
    private int widthSegments = 21;

    // Graph limits and zones
    private float graphMax;
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

    public bool wiped = false;


    [Header("Choose Chart - Tick only 1")]
    public bool usingBreathRateTracker;
    public bool usingOxygenTracker;        // o2 saturation
    public bool usingBloodPressure;
    private bool usingBloodPressureSystolicTracker;
    public bool usingPulseRateTracker;
    public bool usingTempTracker;

    [Header("View only")]
    public Patient_Data currentPatientData;
    public List<float> tracker;
    public List<float> tracker2; // for BP only (D) // must be the top value as it will have the label
    public List<GameObject> currentGraphObjects;

    private void Start()
    {
        SetGraphBGData();   // Sets the chart BG and value data (only needed once)
        DrawBackground();   // Draws the Chart BG
    }

    private void Update()
    {

        if (gameManager.GetComponent<CanvasManager>().obsChartPagePanel.activeSelf && player.GetComponent<DialogManager>().currentPatient != null)
        {
            noDataAvailableMessage.SetActive(false);
            // wipe data if havent 
            //if (!wiped)
            //{
            //    WipeData();
            //    wiped = true;
            //}

            // if time has passed for next data refresh
            if(Time.frameCount > frameRecord + drawDataFrequency)
            {
                LinkData();
                
                drawData();                     // Refresh data
                frameRecord = Time.frameCount;  // Record time when this happened
                //Debug.Log("Chart Data Updated");
            }
        }
        else
        {
            noDataAvailableMessage.SetActive(true);
        }
    }

    void WipeData()// Not used anymore
    {
        currentPatientData = player.GetComponent<DialogManager>().currentPatient;

        if (usingBreathRateTracker)
        {
            currentPatientData.breathRateTracker.Clear();
            currentPatientData.breathRateTracker.Add(currentPatientData.breathRateInit);
        }
        else if (usingOxygenTracker)
        {
            currentPatientData.oxygenTracker.Clear();
            currentPatientData.oxygenTracker.Add(currentPatientData.oxygenInit);
        }
        else if (usingBloodPressure)
        {
            currentPatientData.bloodPressureDiastolicTracker.Clear();
            currentPatientData.bloodPressureDiastolicTracker.Add(currentPatientData.bloodPressureDiastolicInit);
            currentPatientData.bloodPressureSystolicTracker.Clear();
            currentPatientData.bloodPressureSystolicTracker.Add(currentPatientData.bloodPressureSystolicInit);
        }
        else if (usingBloodPressureSystolicTracker)
        {
            currentPatientData.bloodPressureSystolicTracker.Clear(); // delete
            currentPatientData.bloodPressureSystolicTracker.Add(currentPatientData.bloodPressureSystolicInit); // delete
        }
        else if (usingPulseRateTracker)
        {
            currentPatientData.pulseRateTracker.Clear();
            currentPatientData.pulseRateTracker.Add(currentPatientData.pulseRateInit);
        }
        else if (usingTempTracker)
        {
            currentPatientData.tempTracker.Clear();
            currentPatientData.tempTracker.Add(currentPatientData.tempInit);
        }
    }

    void LinkData()
    {
        currentPatientData = player.GetComponent<DialogManager>().currentPatient;

        if (usingBreathRateTracker)
        {
            tracker = currentPatientData.breathRateTracker;
            tracker2 = null;
        }
        else if (usingOxygenTracker)
        {
            tracker = currentPatientData.oxygenTracker;
            tracker2 = null;
        }
        else if (usingBloodPressure)
        {
            tracker = currentPatientData.bloodPressureSystolicTracker; //top value (for label)
            tracker2 = currentPatientData.bloodPressureDiastolicTracker;  // bottom value
        }
        else if (usingBloodPressureSystolicTracker)
        {
            tracker = currentPatientData.bloodPressureSystolicTracker;  // delete
            tracker2 = null;
        }
        else if (usingPulseRateTracker)
        {
            tracker = currentPatientData.pulseRateTracker;
            tracker2 = null;
        }
        else if (usingTempTracker)
        {
            tracker = currentPatientData.tempTracker;
            tracker2 = null;
        }
    }

    void DrawBackground()
    {
        //Debug.Log("background called");

        // Setup BG Container properly
        RectTransform bg_rt = BGContainer.GetComponent<RectTransform>();
        bg_rt.anchoredPosition = new Vector2(0, 0);                             
        bg_rt.sizeDelta = new Vector2(graphContainer.sizeDelta.x, graphContainer.sizeDelta.y);
        bg_rt.anchorMin = new Vector2(0, 0);
        bg_rt.anchorMax = new Vector2(0, 0);
        bg_rt.pivot = new Vector2(0, 0);

        // Setup Points Container properly
        RectTransform points_rt = pointsContainer.GetComponent<RectTransform>();
        points_rt.anchoredPosition = new Vector2(0, 0);
        points_rt.sizeDelta = new Vector2(graphContainer.sizeDelta.x, graphContainer.sizeDelta.y);
        points_rt.anchorMin = new Vector2(0, 0);
        points_rt.anchorMax = new Vector2(0, 0);
        points_rt.pivot = new Vector2(0, 0);


        // Build layers in REVERSE ORDER: CreateBox(name, start at segment 8, spans how many segments)
        if(maxZoneBoxSpan != 0)
        {
            CreateBox("maxZoneBox", maxZoneBoxStart, maxZoneBoxSpan);
        }
        if (highZoneBoxSpan != 0)
        {
            CreateBox("highZoneBox", highZoneBoxStart, highZoneBoxSpan);
        }
        if (normalZoneBoxSpan != 0)
        {
            CreateBox("normalZoneBox", normalZoneBoxStart, normalZoneBoxSpan);
        }
        if (lowZoneBoxSpan != 0)
        {
            CreateBox("lowZoneBox", lowZoneBoxStart, lowZoneBoxSpan);
        }
        if (MinZoneBoxSpan != 0)
        {
            CreateBox("MinZoneBox", MinZoneBoxStart, MinZoneBoxSpan);
        }
    }

    // Draw Background Boxes
    GameObject CreateBox(string boxName, int start_seg, int span)
    {
        GameObject box = new GameObject(boxName, typeof(Image));           // Create GO
        box.transform.SetParent(BGContainer, false);                    // Sets parent to this graph GO

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

        float segmentHeight = graphContainer.sizeDelta.y / heightSegments;

        RectTransform box_rt = box.GetComponent<RectTransform>();

        float startPosY = (segmentHeight * start_seg) - (span*segmentHeight);               // Bottom Left of box
        box_rt.anchoredPosition = new Vector2(0,startPosY);                             // Set Position
          
        box_rt.sizeDelta = new Vector2(graphContainer.sizeDelta.x, span*segmentHeight);   // Set size

        box_rt.anchorMin = new Vector2(0, 0);                                           // Set Anchors
        box_rt.anchorMax = new Vector2(0, 0);
        box_rt.pivot = new Vector2(0, 0);

        return box;
    }


    void drawData()
    {
        // Wipes old points ready for refresh
        foreach(GameObject item in currentGraphObjects)
        {
            Destroy(item);
        }
        currentGraphObjects.Clear();


        float index = 0;

        if (tracker2 != null) // If using blood pressure
        {
            for (int i = 0; i < tracker.Count; i++)
            {
                currentGraphObjects.Add(PlotNextPoint(index, tracker[i], tracker2[i], false)); // build point as usual with label
                currentGraphObjects.Add(PlotNextPoint(index, tracker2[i], 0f, true)); // Bottom value
                index++;
            }
        }
        else // not using blood pressure
        {
            foreach (float value in tracker) // top value
            {
                // Create plot point and add it to the cracker so it can be deleted  (index, top, bottom, bottom exists)
                currentGraphObjects.Add(PlotNextPoint(index, value, 0f, false));

                index++;
            }
        }
    }

    GameObject PlotNextPoint(float xSegment, float yValue, float yValue2bot, bool bottom)
    {
        GameObject point = new GameObject("Point", typeof(Image));    // Create GO
        point.GetComponent<Image>().sprite = pointSprite;
        point.transform.SetParent(pointsContainer, false);                    // Sets parent to this graph GO
        Color pointColor = new Color(0f, 0f, 0f, 1f);
        point.GetComponent<Image>().color = pointColor;

        float segmentHeight = graphContainer.sizeDelta.y / heightSegments;
        float segmentWidth = graphContainer.sizeDelta.x / widthSegments;

        RectTransform point_rt = point.GetComponent<RectTransform>();

        float range = graphMax - graphMin;
        float yPercent = (yValue - graphMin) / range;
        float yPos = (yPercent * graphContainer.sizeDelta.y) - (0.5f * segmentHeight);

        float xPos = (xSegment * segmentWidth);

        point_rt.anchoredPosition = new Vector2(xPos, yPos);                             // Set Position

        point_rt.sizeDelta = new Vector2(segmentWidth, segmentHeight);   // Set size
        point_rt.anchorMin = new Vector2(0, 0);                                           // Set Anchors
        point_rt.anchorMax = new Vector2(0, 0);
        point_rt.pivot = new Vector2(0, 0);

        // Data value label
        GameObject label = new GameObject("Label", typeof(RectTransform));
        RectTransform parentPoint = point.GetComponent<RectTransform>();
        label.transform.SetParent(parentPoint, false);

        Text labelText = label.AddComponent<Text>();

        if(xSegment == 0)
        {
            if (bottom)
            {
                float val = Mathf.Round(yValue * 100) / 100;
                labelText.text = "";
            }
            else if (usingBloodPressure)
            {
                float val = Mathf.Round(yValue * 100) / 100; // top
                float val2bot = Mathf.Round(yValue2bot * 100) / 100; // bottom value

                labelText.text = val.ToString() + "/" + val2bot.ToString() + " - Start";
            }
            else
            {
                float val = Mathf.Round(yValue * 100) / 100;
                labelText.text = val.ToString() + " - Start";
            }
        }
        else
        {
            if (bottom)
            {
                float val = Mathf.Round(yValue * 100) / 100;
                labelText.text = "";
            }
            else if (usingBloodPressure)
            {
                float val = Mathf.Round(yValue * 100) / 100; // top
                float val2bot = Mathf.Round(yValue2bot * 100) / 100; // bot

                labelText.text = val.ToString() + "/" + val2bot.ToString();
            }
            else
            {
                float val = Mathf.Round(yValue * 100) / 100;
                labelText.text = val.ToString();
            }

        }
        
        labelText.font = pointFont;
        labelText.color = Color.black;
        labelText.alignment = TextAnchor.MiddleLeft;
        labelText.fontSize = 45;

        RectTransform label_rt = label.GetComponent<RectTransform>();
        label_rt.Rotate(new Vector3(0, 0, 90));
        label_rt.anchoredPosition = new Vector2(segmentWidth,segmentHeight);
        label_rt.sizeDelta = new Vector2(500,segmentWidth);   // Set size
        label_rt.anchorMin = new Vector2(0, 0);                                           // Set Anchors
        label_rt.anchorMax = new Vector2(0, 0);
        label_rt.pivot = new Vector2(0, 0);

        return point;
    }


    void SetGraphBGData()
    {
        if (usingBreathRateTracker)
        {
            graphMax = 40f;          // Chart Max
            graphMin = 0f;           // Chart Min

            heightSegments = 8;      // How many segments should the chart be broken into

            maxZoneBoxStart = 8;    // Start segment from top down
            maxZoneBoxSpan = 2;     // spans for x segments
            highZoneBoxStart = 6;
            highZoneBoxSpan = 1;
            normalZoneBoxStart = 5;
            normalZoneBoxSpan = 3;
            lowZoneBoxStart = 2;
            lowZoneBoxSpan = 1;
            MinZoneBoxStart = 1;
            MinZoneBoxSpan = 2;
        }

        if (usingOxygenTracker)
        {
            graphMax = 240f;          // Chart Max
            graphMin = 80f;           // Chart Min

            heightSegments = 5;      // How many segments should the chart be broken into

            maxZoneBoxStart = 0;    // Start segment from top down
            maxZoneBoxSpan = 0;     // spans for x segments
            highZoneBoxStart = 0;
            highZoneBoxSpan = 0;
            normalZoneBoxStart = 5;
            normalZoneBoxSpan = 2;
            lowZoneBoxStart = 3;
            lowZoneBoxSpan = 1;
            MinZoneBoxStart = 2;
            MinZoneBoxSpan = 2;
        }


        if (usingBloodPressure)
        {
            graphMax = 240f;          // Chart Max
            graphMin = 30f;           // Chart Min

            heightSegments = 21;      // How many segments should the chart be broken into

            maxZoneBoxStart = 21;    // Start segment from top down
            maxZoneBoxSpan = 4;     // spans for x segments
            highZoneBoxStart = 17;
            highZoneBoxSpan = 2;
            normalZoneBoxStart = 15;
            normalZoneBoxSpan = 8;
            lowZoneBoxStart = 7;
            lowZoneBoxSpan = 1;
            MinZoneBoxStart = 6;
            MinZoneBoxSpan = 6;
        }

        if (usingBloodPressureSystolicTracker)
        {
            graphMax = 240f;          // Chart Max
            graphMin = 30f;           // Chart Min

            heightSegments = 21;      // How many segments should the chart be broken into

            maxZoneBoxStart = 21;    // Start segment from top down
            maxZoneBoxSpan = 4;     // spans for x segments
            highZoneBoxStart = 17;
            highZoneBoxSpan = 2;
            normalZoneBoxStart = 15;
            normalZoneBoxSpan = 8;
            lowZoneBoxStart = 7;
            lowZoneBoxSpan = 1;
            MinZoneBoxStart = 6;
            MinZoneBoxSpan = 6;
        }


        if (usingPulseRateTracker)
        {
            graphMax = 170f;          // Chart Max
            graphMin = 30f;           // Chart Min

            heightSegments = 14;      // How many segments should the chart be broken into

            maxZoneBoxStart = 14;    // Start segment from top down
            maxZoneBoxSpan = 3;     // spans for x segments
            highZoneBoxStart = 11;
            highZoneBoxSpan = 2;
            normalZoneBoxStart = 9;
            normalZoneBoxSpan = 7;
            lowZoneBoxStart = 2;
            lowZoneBoxSpan = 1;
            MinZoneBoxStart = 1;
            MinZoneBoxSpan = 1;
        }

        if (usingTempTracker)
        {
            graphMax = 41.5f;          // Chart Max
            graphMin = 33.5f;           // Chart Min

            heightSegments = 16;      // How many segments should the chart be broken into

            maxZoneBoxStart = 0;    // Start segment from top down
            maxZoneBoxSpan = 0;     // spans for x segments
            highZoneBoxStart = 16;
            highZoneBoxSpan = 6;
            normalZoneBoxStart = 10;
            normalZoneBoxSpan = 6;
            lowZoneBoxStart = 4;
            lowZoneBoxSpan = 4;
            MinZoneBoxStart = 0;
            MinZoneBoxSpan = 0;
        }
    }
}
