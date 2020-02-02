using UnityEngine;

[CreateAssetMenu(menuName = "REPAIR/Partner/Partner")]
[System.Serializable]
public class Partner : ScriptableObject
{
    public string displayName;
    
    [Header("Psych Stats")]
    public PartnerStats stats;
    [Header("Settings Template")]
    public PartnerStatsSettings DefaultSettings;

    public void Initialize() 
    {
        if (stats == null)
            stats = ScriptableObject.CreateInstance<PartnerStats>();
        
        if (DefaultSettings != null)
            stats.DefaultSettings = DefaultSettings;
        
        stats.Initialize();
    }
}
