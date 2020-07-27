using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC_PATIENTNAME", menuName = "Create New NPC Data")]
public class Patient_Data : ScriptableObject
{

    [Header("---------- Patient Info ----------")]
    // Patient Details:

    public new string name = "Example: Greg Marhe";         // Example: "Greg Marhe"            - new string overrides the existing name definition
    public int age = 30;                                    // Example: "30"
    public string gender = "Male";                          // Example: "Male"

    public string overallHealth = "Generally healthy";      // Example: Generally healthy past medical history of asthma
    public string additionalNotes = "None";


    // --------------------------------------------------------------------------------------------------------------------

    [Header("---------- Dialog Ambulance Bay ----------")]
    public List<string> ambulanceBayConversation = new List<string>();

    [Header("---------- Dialog - Bed Area ----------")]
    public List<string> bedsAreaConversation = new List<string>();

    [Header("---------- Dialog - Resus Bay ----------")]
    public List<string> resusBayConversation = new List<string>();

    [Header("---------- Dialog - Walk In ----------")]
    public List<string> walkInConversation = new List<string>();

    [Header("---------- Dialog - Other / Hallway ----------")]
    public List<string> otherConversation = new List<string>();


    // --------------------------------------------------------------------------------------------------------------------

    // Triage - ABCDDEF


    // ### A - Airway ###
    [Header("A - Airway")]
    [Header("---------- Triage - ABCDDEF ----------")]

    // If the patient is self-ventilating or assisted ventilation by an Endotracheal Tube.
    public bool selfVentilating = true;


    // ### B - Breathing ###
    // Breathing describes the patient’s oxygen status, rate of breathing and use of accessory muscles.
    [Header("B - Breathing")]

    // Oxygen Status
    public float oxygenInit = 95.0f;                      // Example value "95"
    public float oxygenMod = 0.5f;
    public List<float> oxygenTracker;

    // Breaths per minute
    public float breathRateInit = 15.0f;                  // Example value 15 BPM - (Normal adult 12-20 BPM)
    public float breathRateMod = 0.5f;
    public List<float> breathRateTracker;

    // Using accessory muscles?
    public bool accessoryMuscles = true;



    // ### C - Circulation ###
    [Header("C - Circulation")]

    /*
     * Blood pressure is the measurement of the pressure or force of blood against the walls of your arteries.
     * The first number is called the systolic pressure and measures the pressure in the arteries when the heart beats and pushes blood out to the body. 
     * The second number is called the diastolic pressure and measures the pressure in the arteries when the heart rests between beats.
     * High: 140/90 mm Hg  
     */
    // Blood Pressure - Systolic
    public float bloodPressureSystolicInit = 140.0f;       // Example "140"
    public float bloodPressureSystolicMod = 0.5f;
    public List<float> bloodPressureSystolicTracker;

    // Blood Pressure - Diastolic
    public float bloodPressureDiastolicInit = 90.0f;      // Example "90"
    public float bloodPressureDiastolicMod = 0.5f;
    public List<float> bloodPressureDiastolicTracker;

    // Pulse Rate
    public float pulseRateInit = 70.0f;                   // Example: "70" - (Normal adult 60-80 BPM)
    public float pulseRateMod = 0.5f;
    public List<float> pulseRateTracker;

    // Whole Body Perfusion
    public bool wholeBodyPerfusion = true;

    // Capillary Refill - The time it takes for blood to flow back into a squeezed hand
    public float capillaryRefillInit = 2.0f;
    public float capillaryRefillMod = 0.5f;
    public List<float> capillaryRefillTracker;



    // ### D - Disability ###
    // Disability describes neurological symptoms Glasgow Coma Scale, pupil reaction.
    [Header("D - Disability")]

    // Glasgow Coma Scale
    public float glasgowComaScaleInit = 12.0f;            // Example "12"
    public float glasgowComaScaleMod = 0.5f;
    public List<float> glasgowComaScaleTracker;

    // Pupil Reaction
    public float pupilReactionInit = 4.0f;               // Example "4"
    public float pupilReactionMod = 0.5f;
    public List<float> pupilReactionTracker;

    // Repetitive Questioning
    public bool repetitiveQuestining = true;



    // ### D - Devices / Pain assessment and location of pain ###
    [Header("D - Devices")]

    // Has Internal Devices - pacemaker, cannular etc
    public bool hasInternalDevices = false;

    // Has a Cannular
    public bool hasCannula = false;



    // ### E - Environment ###
    [Header("E - Environment")]

    // Has Fever
    public bool hasFever = false;



    // --------------------------------------------------------------------------------------------------------------------
    // Triage - AMPLE


    // A - Allergies
    [Header("A - Allergies")]
    [Header("---------- Triage - AMPLE ----------")]
    public List<string> allergies;                                                      // Example ["dairy"]

    // M - Medications
    [Header("M - Medications")]
    public List<string> medicationList;                                                 // Example ["Salbutamol", "Alcohol 1-2 standard drinks per day"]

    // P - Past Medical History
    [Header("P - Past Medical History")]
    public List<string> medicalHistoryList;                                             // Example: ["Asthma", "Last asthma attack 4 yrs ago"]

    // L - Last Meal Eaten Time
    [Header("Last Meal Eaten Time")]
    public string lastMealTime = "19:00";                                               // Example "19:00"

    // E - Events leading to the presentation to hospital
    [Header("E - Events leading to the presentation to hospital")]
    public string leadingEvents = "Events leading to the presentation to hospital";     // Example: "Tripped on bowling ball in garage and hit the front right side of head on shelf, loss of consciousnesses for 15 seconds, landed on right leg ?ankle fracture"




    // --------------------------------------------------------------------------------------------------------------------
    // Results
    [Header("---------- Final Results ----------")]

    // Triage Scale
    public int triageScale;

    // for a move to function maybe?
    public string currentLocation;


    [Header("---------- System ----------")]
    public bool patientActive = false;
    public bool initValsAdded = false;

    public GameObject character;


}
