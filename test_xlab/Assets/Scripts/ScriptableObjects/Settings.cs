using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Setting", menuName = "ScriptableObjects/SceneSetting", order = 1)]
public class Settings : ScriptableObject
{
    [Header("Settings")]
    public float stoneEnableButtonTimer;
    public float toolEnableButtonTimer;
    public float rainEnableButtonTimer;

    public float outlineWidth;
    public int CountWorkerToEnd;
}
