using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC_DATA_PATIENTNAME", menuName = "Create New NPC Data")]
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
    // Dialog
    [Header("---------- Dialog ----------")]
    public List<string> conversation = new List<string>();


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
    public int oxygen = 95;                      // Example value "95"

    // Breaths per minute
    public int breathRate = 15;                  // Example value 15 BPM - (Normal adult 12-20 BPM)

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
    public int bloodPressureSystolic = 140;       // Example "140"

    // Blood Pressure - Diastolic
    public int bloodPressureDiastolic = 90;      // Example "90"

    // Pulse Rate
    public int pulseRate = 70;                   // Example: "70" - (Normal adult 60-80 BPM)

    // Whole Body Perfusion
    public bool wholeBodyPerfusion = true;

    // Capillary Refill - The time it takes for blood to flow back into a squeezed hand
    public float capillaryRefill = 2.0f;



    // ### D - Disability ###
    // Disability describes neurological symptoms Glasgow Coma Scale, pupil reaction.
    [Header("D - Disability")]

    // Glasgow Coma Scale
    public int glasgowComaScale = 12;            // Example "12"

    // Pupil Reaction
    public int pupilReaction = 4;               // Example "4"

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

}
