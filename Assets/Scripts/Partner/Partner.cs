using UnityEngine;

[CreateAssetMenu(menuName = "REPAIR/Partner/Partner")]
[System.Serializable]
public class Partner : ScriptableObject
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
            stats = ScriptableObject.CreateInstance<PartnerStats>();
        
        if (DefaultSettings != null)
            stats.DefaultSettings = DefaultSettings;
        
        stats.Initialize();
    }

    public void RandomizeDisplayName()
    {
        if (availableNames == null)
        {
            availableNames = CreateInstance<PartnerNames>();
        }

        displayName = availableNames.names[Random.Range(0, availableNames.names.Length)];
        name = $"Partner \"{displayName}\"";
    }
}
