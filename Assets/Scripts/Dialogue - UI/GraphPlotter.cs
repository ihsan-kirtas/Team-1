using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class GraphPlotter : MonoBehaviour
{

    [SerializeField] private Sprite circleSprite;       // Serialized So you can set in the editor
    public RectTransform graphContainer;

    public Patient_Data currentPatientData;

    public List<GameObject> currentGraphObjects;

    public Color lineColor;

    public GameObject noDataAvailable;
    public GameObject dataOwner;





    // Global
    public List<float> tracker;

    public Text maxValue;
    public Text HighValue;
    public Text LowValue;
    public Text MinValue;

    private string chartName;

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




        noDataAvailable.SetActive(true);

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


        noDataAvailable.SetActive(false);
        dataOwner.SetActive(false);



        if (currentPatientData != null)
        {

            dataOwner.GetComponent<Text>().text = currentPatientData.name;

            // Sets variables for the specific chart.   Max, High, Low, Min & the tracker data to use.
            SetTrackerData();

            float listLength = tracker.Count;
            float xSpacingPercentage = 0.1f;
            float xSpacing = graphContainer.rect.width * xSpacingPercentage;

            float graphHeight = graphContainer.rect.height;
            float graphYrange = graphMax - graphMin;

            GameObject lastCircleGameObject = null;


            string currentValue = tracker.Last().ToString();

            dataOwner.GetComponent<Text>().text = chartName + " | " + GameObject.Find("Player").GetComponent<DialogManager>().currentPatient.name + " | " + currentValue;
            dataOwner.SetActive(true);



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

            noDataAvailable.SetActive(true);

        }
    }

    private GameObject PlotPoint(Vector2 position)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));                // Create a new game object, Type: Image, name: circle
        currentGraphObjects.Add(gameObject);                                            // Add new object to list so they can all be deleted on refresh
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

    private void SetTrackerData()
    {

        if (usingBloodPressureDiastolicTracker)
        {

            graphMax = 200;
            graphHigh = 180;
            graphLow = 120;
            graphMin = 100;
            tracker = currentPatientData.bloodPressureDiastolicTracker;
            chartName = "Blood Pressure Diastolic";
        }
        if (usingBloodPressureSystolicTracker)
        {
            graphMax = 150;
            graphHigh = 120;
            graphLow = 80;
            graphMin = 50;
            tracker = currentPatientData.bloodPressureSystolicTracker;
            chartName = "Blood Pressure Systolic";
        }
        if (usingOxygenTracker)
        {
            graphMax = 150;
            graphHigh = 130;
            graphLow = 60;
            graphMin = 50;
            tracker = currentPatientData.oxygenTracker;
            chartName = "Oxygen";
        }
        if (usingBreathRateTracker)
        {
            graphMax = 40;
            graphHigh = 30;
            graphLow = 10;
            graphMin = 5;
            tracker = currentPatientData.breathRateTracker;
            chartName = "Breath Rate";
        }

        if (usingPulseRateTracker)
        {
            graphMax = 200;
            graphHigh = 150;
            graphLow = 50;
            graphMin = 20;
            tracker = currentPatientData.pulseRateTracker;
            chartName = "Pulse Rate";
        }
        if (usingCapillaryRefillTracker)
        {
            graphMax = 10;
            graphHigh = 5;
            graphLow = 1;
            graphMin = 0;
            tracker = currentPatientData.capillaryRefillTracker;
            chartName = "Capillary Refill";
        }
        if (usingGlasgowComaScaleTracker)
        {
            graphMax = 30;
            graphHigh = 20;
            graphLow = 5;
            graphMin = 1;
            tracker = currentPatientData.glasgowComaScaleTracker;
            chartName = "Glasgow Coma Scale";
        }
        if (usingPupilReactionTracker)
        {
            graphMax = 10;
            graphHigh = 8;
            graphLow = 2;
            graphMin = 0;
            tracker = currentPatientData.pupilReactionTracker;
            chartName = "Pupil Reaction";
        }

        maxValue.text = graphMax.ToString();
        HighValue.text = graphHigh.ToString();
        LowValue.text = graphLow.ToString();
        MinValue.text = graphMin.ToString();
    }
}
