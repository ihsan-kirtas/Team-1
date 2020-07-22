using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GraphPlotter : MonoBehaviour
{

    [SerializeField] private Sprite circleSprite;       // Serialized So you can set in the editor
    public RectTransform graphContainer;

    public Patient_Data patientData;

    // Global
    public List<float> tracker;

    public Text maxValue;
    public Text HighValue;
    public Text LowValue;
    public Text MinValue;

    // Graph limits and zones
    private float graphMax;
    private float graphHigh;
    private float graphLow;
    private float graphMin;


    // Which chart are you using - 1 only
    public bool usingBloodPressureDiastolicTracker;
    public bool usingBloodPressureSystolicTracker;
    public bool usingOxygenTracker;
    public bool usingBreathRateTracker;
    public bool usingPulseRateTracker;
    public bool usingCapillaryRefillTracker;
    public bool usingGlasgowComaScaleTracker;
    public bool usingPupilReactionTracker;


    private void Start()
    {
        // Subscribe to events
        GameEvents.current.event_updatePatientData += UpdateValues;


        // Sets variables for the specific chart.   Max, High, Low, Min & the tracker data to use.
        SetTrackerData();

        // Draws the borders, zones and guide lines.
        DrawBorders();
    }

    private void OnDestroy()
    {
        // Unsubscribe to events
        GameEvents.current.event_updatePatientData -= UpdateValues;
    }

    private void UpdateValues()
    {
        float listLength = tracker.Count;
        float xSpacingPercentage = 0.1f;
        float xSpacing = graphContainer.rect.width * xSpacingPercentage;

        float graphHeight = graphContainer.rect.height;
        float graphYrange = graphMax - graphMin;

        GameObject lastCircleGameObject = null;


        for (int i = 0; i < listLength; i++)
        {
            // Calculate X
            float xPos = i * xSpacing;                                  // TODO issues with > 10 values

            // Calculate Y
            float obValue = tracker[i];                                 // Ob Value
            float yPercent = (obValue - graphMin) / graphYrange;        // percentage of the allowable range
            float yPos = yPercent * graphHeight;                        // apply to graph height

            // Plot point on graph - get the GO it returns
            GameObject circleGameObject =  PlotPoint(new Vector2(xPos, yPos));

            if(lastCircleGameObject != null)
            {
                // Join the previous point to this point with a line - LinkPoints(PosA, PosB)
                LinkPoints(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);

            }
            lastCircleGameObject = circleGameObject;

        }
    }

    private GameObject PlotPoint(Vector2 position)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));                // Create a new game object, Type: Image, name: circle
        gameObject.transform.SetParent(graphContainer, false);                          // Make circle a child of the graph container
        gameObject.GetComponent<Image>().sprite = circleSprite;                         // Set the gameobjects sprite to the circle sptite
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();         // Get the rect transform
        rectTransform.anchoredPosition = position;                                      // Set a new position for that rect transform
        rectTransform.sizeDelta = new Vector2(11, 11);                                  // ?? size delta ??

        rectTransform.anchorMin = new Vector2(0, 0);                                    // Anchor to lower left corner
        rectTransform.anchorMax = new Vector2(0, 0);                                    // Anchor to lower left corner

        return gameObject;                                                              // Returns the game object so we can use it to make the connecting lines.
    }

    private void DrawBorders()
    {

        // Max Limit

        // High Zone

        // Normal Zone

        // Low Zone

        // Min Limit

        // Guide Lines

        // Outside borders
    }

    private void LinkPoints(Vector2 pointPosA, Vector2 pointPosB)
    {
        GameObject gameObject = new GameObject("link", typeof(Image));                  // create new link GO
        gameObject.transform.SetParent(graphContainer, false);                          // Set parent
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, .5f);               // Set line colour
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();         // Get rect transform
        Vector2 dir = (pointPosB - pointPosA).normalized;                               // Line Direction
        float distance = Vector2.Distance(pointPosA, pointPosB);                        // Line Distance
        rectTransform.anchorMin = new Vector2(0, 0);                                    // Set anchor
        rectTransform.anchorMax = new Vector2(0, 0);                                    // Set anchor
        rectTransform.sizeDelta = new Vector2(100, 3f);                                 // Set size delta
        rectTransform.anchoredPosition = pointPosA + dir * distance * .5f;              // Half way between A and B

        Vector2 forward = new Vector2(1, 0);
        float angle = Vector2.Angle(forward, dir);                                      // Get line angle

        rectTransform.localEulerAngles = new Vector3(0, 0, angle);                      // Apply angle to new line
    }

    private void SetTrackerData()
    {

        if (usingBloodPressureDiastolicTracker)
        {

            graphMax = 200;
            graphHigh = 180;
            graphLow = 120;
            graphMin = 100;
            tracker = patientData.bloodPressureDiastolicTracker;
        }
        if (usingBloodPressureSystolicTracker)
        {
            graphMax = 150;
            graphHigh = 120;
            graphLow = 80;
            graphMin = 50;
            tracker = patientData.bloodPressureSystolicTracker;
        }
        if (usingOxygenTracker)
        {
            graphMax = 150;
            graphHigh = 130;
            graphLow = 60;
            graphMin = 50;
            tracker = patientData.oxygenTracker;
        }
        if (usingBreathRateTracker)
        {
            graphMax = 40;
            graphHigh = 30;
            graphLow = 10;
            graphMin = 5;
            tracker = patientData.breathRateTracker;
        }

        if (usingPulseRateTracker)
        {
            graphMax = 200;
            graphHigh = 150;
            graphLow = 50;
            graphMin = 20;
            tracker = patientData.pulseRateTracker;
        }
        if (usingCapillaryRefillTracker)
        {
            graphMax = 10;
            graphHigh = 5;
            graphLow = 1;
            graphMin = 0;
            tracker = patientData.capillaryRefillTracker;
        }
        if (usingGlasgowComaScaleTracker)
        {
            graphMax = 30;
            graphHigh = 20;
            graphLow = 5;
            graphMin = 1;
            tracker = patientData.glasgowComaScaleTracker;
        }
        if (usingPupilReactionTracker)
        {
            graphMax = 10;
            graphHigh = 8;
            graphLow = 2;
            graphMin = 0;
            tracker = patientData.pupilReactionTracker;
        }

        maxValue.text = graphMax.ToString();
        HighValue.text = graphHigh.ToString();
        LowValue.text = graphLow.ToString();
        MinValue.text = graphMin.ToString();
    }
}
