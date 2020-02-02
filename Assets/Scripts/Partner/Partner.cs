using UnityEngine;

[System.Serializable]
public class Partner : MonoBehaviour
{
    public string displayName;

    public PartnerNames availableNames;
    
    [Header("Psych Stats")]
    public PartnerStats stats;
    [Header("Settings Template")]
    public PartnerStatsSettings DefaultSettings;

    public void Initialize() 
    {
        RandomizeDisplayName();

        if (stats == null)
            stats = gameObject.AddComponent<PartnerStats>();
        
        if (DefaultSettings != null)
            stats.DefaultSettings = DefaultSettings;
        
        stats.Initialize();
    }

    public void RandomizeDisplayName()
    {
        if (availableNames == null)
        {
            availableNames = ScriptableObject.CreateInstance<PartnerNames>();
        }

        displayName = availableNames.names[Random.Range(0, availableNames.names.Length)];
        name = $"{displayName}";
    }
}
