using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PartnerStats : MonoBehaviour
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
            SyncStatSize(statCount);
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

    public void SyncStatSize()
    {
        SyncStatSize(statCount);
    }
    public void SyncStatSize(int size)
    {
        statNames.ResizeList(size);
        have.ResizeList(size);
        want.ResizeList(size);
        conflict.ResizeList(size);
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
        ApplyRandomize();
    }

    public void Initialize()
    {
        Initialize(DefaultSettings != null ? DefaultSettings : ScriptableObject.CreateInstance<PartnerStatsSettings>());
    }

    public void ApplySettings(PartnerStatsSettings settings)
    {
        if (settings != null)
        {
            statCount = settings.statCount;
            randomizeAll = settings.randomizeAll;
            randDeltaAll = settings.randDeltaAll;
            randResolutionAll = settings.randResolutionAll;
            randomizeHave = settings.randomizeHave;
            randDeltaHave = settings.randDeltaHave;
            randResolutionHave = settings.randResolutionHave;
            randomizeWant = settings.randomizeWant;
            randDeltaWantMin = settings.randDeltaWantMin;
            randDeltaWantMax = settings.randDeltaWantMax;
            randResolutionWant = settings.randResolutionWant;
            statNames = settings.statNames;

            if (have == null)
            {
                have = new List<PartnerStatEntry>(statCount);
                have.InitList(new PartnerStatEntry());

            }
            if (want == null)
            {
                want = new List<RangedPartnerStatEntry>(statCount);
                want.InitList(new RangedPartnerStatEntry());
            }
            if (conflict == null)
            {
                conflict = new List<PartnerStatEntry>(statCount);
                conflict.InitList(new PartnerStatEntry());
            }

            SyncStatSize(statCount);
        }
        else
        {
            Debug.LogError($"Can't apply PartnerStats Settings to {name}, settings is null");
        }
    }
}


