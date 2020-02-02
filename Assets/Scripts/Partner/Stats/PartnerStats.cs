using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "REPAIR/Partner/Stats")]
[System.Serializable]
public class PartnerStats : ScriptableObject
{
    [Header("Settings Template")]
    public PartnerStatsSettings DefaultSettings;

    [Header("Amount of stats.")]
    [SerializeField]
    private int statCount;
    public int StatCount
    {
        get { return statCount; }
        set
        {
            statCount = value;
            Resize(statCount);
        }
    }

    [Header("Random Params: All")]
    public bool randomizeAll;
    public float randDeltaAll;
    [Range(0f, 1f)]
    public float randResolutionAll;
    [Header("Random Params: HAVE")]
    public bool randomizeHave;
    public float randDeltaHave;

    [Range(0f, 1f)]
    public float randResolutionHave;
    [Header("Random Params: WANT")]
    public bool randomizeWant;
    public float randDeltaWantMin;
    public float randDeltaWantMax;
    [Range(0f, 1f)]
    public float randResolutionWant;

    public List<string> statNames;

    [Header("HAVE, i.e. my stats")]
    public List<PartnerStatEntry> have;

    [Header("WANT, i.e. stats i want in my partner")]
    public List<RangedPartnerStatEntry> want;

    [Header("conflict potential, the difference between own HAVE and partner's WANT")]
    public List<PartnerStatEntry> conflict;
    public float conflictPercentage = 0f;

    public void Resize(int _count)
    {
        statNames.ResizeList(statCount);
        have.ResizeList(statCount);
        want.ResizeList(statCount);
        conflict.ResizeList(statCount);
        SyncStatNames();
    }

    public void SyncStatNames()
    {
        for (int i = 0; i < statNames.Count; i++)
        {
            string sn = statNames[i];
            have[i].statname = sn;
            want[i].statname = sn;
            conflict[i].statname = sn;
        }
    }

    private float Round(float input, float step)
    {
        return ((Mathf.Round(input / step)) * step);
    }

    public void ApplyRandomize(bool overrideAll = false, bool overrideHave = false, bool overrideWant = false)
    {

        for (int i = 0; i < statNames.Count; i++)
        {
            if (overrideAll || randomizeAll)
            {
                have[i].val = Round(Random.Range(0f, 1f), randResolutionAll);
                want[i].val.min = Round(Random.Range(0f, 1f), randResolutionAll);
                want[i].val.max = Round(Random.Range(want[i].val.min, 1f), randResolutionAll);
            }
            else
            {
                if (overrideHave || randomizeHave)
                {
                    have[i].val = Round(Random.Range(0f, 1f), randResolutionHave);
                }
                if (overrideWant || randomizeWant)
                {
                    want[i].val.min = Round(Random.Range(0f, 1f), randResolutionWant);
                    want[i].val.max = Round(Random.Range(want[i].val.min, 1f), randResolutionWant);
                }
            }
        }
    }

    public void Initialize(PartnerStatsSettings settings)
    {
        ApplySettings(settings);
        SyncStatNames();
        ApplyRandomize();
    }

    public void Initialize()
    {
        Initialize(DefaultSettings != null ? DefaultSettings : CreateInstance<PartnerStatsSettings>());
    }

    public void ApplySettings(PartnerStatsSettings settings)
    {
        if (settings != null)
        {
            this.statCount = settings.statCount;
            this.randomizeAll = settings.randomizeAll;
            this.randDeltaAll = settings.randDeltaAll;
            this.randResolutionAll = settings.randResolutionAll;
            this.randomizeHave = settings.randomizeHave;
            this.randDeltaHave = settings.randDeltaHave;
            this.randResolutionHave = settings.randResolutionHave;
            this.randomizeWant = settings.randomizeWant;
            this.randDeltaWantMin = settings.randDeltaWantMin;
            this.randDeltaWantMax = settings.randDeltaWantMax;
            this.randResolutionWant = settings.randResolutionWant;
            this.statNames = settings.statNames;
        }
        else
        {
            Debug.LogError($"Can't apply PartnerStats Settings to {name}, settings is null");
        }
    }
}


