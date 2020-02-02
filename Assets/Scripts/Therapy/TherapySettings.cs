using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "REPAIR/Therapy/Settings", order = 1)]
public class TherapySettings : ScriptableObject
{
    public int budget = 5;
    public RelationshipSettings relationshipSettings;
}