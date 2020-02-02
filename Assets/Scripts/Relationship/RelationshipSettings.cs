using UnityEngine;

[CreateAssetMenu(menuName = "REPAIR/Relationship/Settings", order = 2)]
[System.Serializable]
public class RelationshipSettings : ScriptableObject
{
    public bool generatePartnerA = false;
    public bool generatePartnerB = false;

    public PartnerStatsSettings partnerSettingsA;
    public PartnerStatsSettings partnerSettingsB;
    
    public float destinyTresholdPercentage = 0.8f;
}