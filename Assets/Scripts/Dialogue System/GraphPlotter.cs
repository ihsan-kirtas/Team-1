using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GraphPlotter : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    public RectTransform graphContainer;

    public Patient_Data patientData;

    // Global
    public List<float> tracker;

    public Text maxValue;
    private float graphMax;

    public Text HighValue;
    private float graphHigh;

    public Text LowValue;
    private float graphLow;

    public Text MinValue;
    private float graphMin;


    // Hacky
    // Pick 1 only
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

        // HACKY QUICK FIX
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


        // Repeat Function - (FunctionName, Start Delay, Repeat every)
        InvokeRepeating("UpdateValues", 0.0f, 0.5f);
    }


    private void UpdateValues()
    {
        float listLength = tracker.Count;
        float xSpacingPercentage = 0.1f;
        float xSpacing = graphContainer.rect.width * xSpacingPercentage;

        float graphHeight = graphContainer.rect.height;
        float graphYrange = graphMax - graphMin;


        for (int i = 0; i < listLength; i++)
        {
            // Calculate X
            // Will have issues when > 10
            float xPos = i * xSpacing;

            // Calculate Y
            float obValue = tracker[i];                                 // Ob Value
            float yPercent = (obValue - graphMin) / graphYrange;        // percentage of the allowable range
            float yPos = yPercent * graphHeight;                        // apply to graph height

            // Plot point on graph
            PlotPoint(new Vector2(xPos, yPos));

            //Debug.Log(obValue.ToString());
            //Debug.Log(yPercent.ToString());
            //Debug.Log(xPos.ToString());
        }
    }

    public void PlotPoint(Vector2 position)
    {
        GameObject gameobject = new GameObject("circle", typeof(Image));

        // Make circle a child of the graph container
        gameobject.transform.SetParent(graphContainer, false);

        // Set the sprite to the circle sptite
        gameobject.GetComponent<Image>().sprite = circleSprite;

        RectTransform rectTransform = gameobject.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = position;

        rectTransform.sizeDelta = new Vector2(11, 11);

        // Anchor to lower left corner
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
    }
}
