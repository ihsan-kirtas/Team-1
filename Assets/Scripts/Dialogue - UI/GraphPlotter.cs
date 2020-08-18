using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


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

    private float drawDataFrequency = 300f;
    private float frameRecord = 0f;


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
    private bool usingOxygenTracker;        // o2 saturation


    private bool usingBloodPressureDiastolicTracker;
    private bool usingBloodPressureSystolicTracker;
    
    private bool usingPulseRateTracker;

    private bool usingTempTracker;

    //??? no charts
    private bool usingCapillaryRefillTracker;
    private bool usingGlasgowComaScaleTracker;
    private bool usingPupilReactionTracker;


    [Header("View only")]
    public Patient_Data currentPatientData;
    public List<float> tracker;
    public List<GameObject> currentGraphObjects;

    private void Start()
    {
        // Subscribe to events
        //GameEvents.current.event_updatePatientData += UpdateValues;

        //noDataAvailable.SetActive(true);

        // Draws the borders, zones and guide lines.
        //DrawBorders();


        currentPatientData = player.GetComponent<DialogManager>().currentPatient;

        if (usingBreathRateTracker)
        { tracker = currentPatientData.breathRateTracker; }
        else if (usingOxygenTracker)
        { tracker = currentPatientData.oxygenTracker; }
        else if (usingBloodPressureDiastolicTracker)
        { tracker = currentPatientData.bloodPressureDiastolicTracker; }
        else if (usingBloodPressureSystolicTracker)
        { tracker = currentPatientData.bloodPressureSystolicTracker; }
        else if (usingPulseRateTracker)
        { tracker = currentPatientData.pulseRateTracker; }
        //else if (usingTempTracker)
        //{ tracker = currentPatientData.breathRateTracker; }

        



    SetGraphBGData();   // Sets the chart BG and value data (only needed once)
        DrawBackground();   // Draws the Chart BG
    }

    private void Update()
    {


        if (gameManager.GetComponent<CanvasManager>().obsChartPagePanel.activeSelf)
        {
            // if time has passed for next data refresh
            if(Time.frameCount > frameRecord + drawDataFrequency)
            {
                drawData();                     // Refresh data
                frameRecord = Time.frameCount;  // Record time when this happened
                Debug.Log("Chart Data Updated");
            }
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe to events
        //GameEvents.current.event_updatePatientData -= UpdateValues;
    }


    void DrawBackground()
    {
        Debug.Log("background called");

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
        CreateBox("maxZoneBox", maxZoneBoxStart, maxZoneBoxSpan);
        CreateBox("highZoneBox", highZoneBoxStart, highZoneBoxSpan);
        CreateBox("normalZoneBox", normalZoneBoxStart, normalZoneBoxSpan);
        CreateBox("lowZoneBox", lowZoneBoxStart, lowZoneBoxSpan);
        CreateBox("MinZoneBox", MinZoneBoxStart, MinZoneBoxSpan);
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
        foreach (float value in tracker)
        {
            // Create plot point and add it to the cracker so it can be deleted
            currentGraphObjects.Add(PlotNextPoint(index, value));
            index++;
        }
    }

    GameObject PlotNextPoint(float xSegment, float yValue)
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
            labelText.text = yValue.ToString() + " - Start";
        }
        else
        {
            labelText.text = yValue.ToString();
        }
        
        labelText.font = pointFont;
        labelText.color = Color.black;
        labelText.alignment = TextAnchor.MiddleLeft;
        labelText.fontSize = 55;

        RectTransform label_rt = label.GetComponent<RectTransform>();
        label_rt.Rotate(new Vector3(0, 0, 90));
        label_rt.anchoredPosition = new Vector2(segmentWidth,segmentHeight);
        label_rt.sizeDelta = new Vector2(500,segmentWidth);   // Set size
        label_rt.anchorMin = new Vector2(0, 0);                                           // Set Anchors
        label_rt.anchorMax = new Vector2(0, 0);
        label_rt.pivot = new Vector2(0, 0);



        // Link to previous point if not the first point
        //if(xSegment != 0)
        //{
        //    GameObject link = new GameObject("link", typeof(RectTransform));                  // create new link GO

        //    RectTransform linkParent = point.GetComponent<RectTransform>();

        //    Image linkImage = link.AddComponent<Image>();

        //    link.transform.SetParent(linkParent, false);

        //    linkImage.color = Color.magenta;                            // Set line colour

        //    RectTransform link_rt = link.GetComponent<RectTransform>();         // Get rect transform

        //    GameObject lastPoint = currentGraphObjects.Last();

        //    Vector2 dir = (currentGraphObjects.Last().transform.position - point.transform.position).normalized;                               // Line Direction
        //    //Debug.Log(dir);

        //    float distance = Vector2.Distance(currentGraphObjects.Last().transform.position, point.transform.position);                        // Line Distance
        //    //Debug.Log(distance);

        //    link_rt.anchorMin = new Vector2(0, 0);                                    // Set anchor
        //    link_rt.anchorMax = new Vector2(0, 0);                                    // Set anchor
        //    link_rt.sizeDelta = new Vector2(segmentWidth, 3f);                                 // Set size delta
        //    link_rt.anchoredPosition = new Vector2(-30, 0.5f * segmentHeight);              // Half way between A and B
        //    link_rt.pivot = new Vector2(0, 0);

        //    Vector2 forward = new Vector2(-1, 0);
        //    float angle = Vector2.Angle(forward, dir);                                      // Get line angle
        //    link_rt.localEulerAngles = new Vector3(0, 0, angle);                      // Apply angle to new line
        //}


        return point;
    }


    void SetGraphBGData()
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
