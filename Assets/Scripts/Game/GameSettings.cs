using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "CreateGameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Triage Animation")]
    public bool TriageAnimationPlayed;
}
