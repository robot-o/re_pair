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
        Initialize(null);
    }

    public void Initialize(PartnerStatsSettings ps)
    {

        if (stats == null)
            stats = gameObject.AddComponent<PartnerStats>();

        if (ps != null)
        {
            DefaultSettings = ps;
            stats.DefaultSettings = DefaultSettings;
            if (DefaultSettings.availablePartnerNames != null)
            {
                availableNames = DefaultSettings.availablePartnerNames;
            }
        }

        RandomizeDisplayName();
        stats.Initialize(ps);
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
