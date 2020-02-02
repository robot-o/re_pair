using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "REPAIR/Partner/StatsSettings")]
[System.Serializable]
public class PartnerStatsSettings : ScriptableObject
{
    [Header("Amount of stats.")]
    public int statCount = 5;

    [Header("Random Params: All")]
    public bool randomizeAll = true;
    public float randDeltaAll = 0f;
    [Range(0f, 1f)]
    public float randResolutionAll = 0.2f;
    [Header("Random Params: HAVE")]
    public bool randomizeHave = false;
    public float randDeltaHave = 0f;

    [Range(0f, 1f)]
    public float randResolutionHave = 0.2f;
    [Header("Random Params: WANT")]
    public bool randomizeWant = false;
    public float randDeltaWantMin = 0f;
    public float randDeltaWantMax = 0f;
    [Range(0f, 1f)]
    public float randResolutionWant = 0.2f;

    public List<string> statNames = new List<string>() {
        "openness",
        "conscientiousness",
        "extraversion",
        "agreeableness",
        "neuroticism"
    };
}