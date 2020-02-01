using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "REPAIR/Relationship", order = 2)]
[System.Serializable]
public class Relationship : ScriptableObject
{
    public bool generatePartnerA = false;
    public bool generatePartnerB = false;

    public PartnerStatsSettings partnerSettingsA;
    public PartnerStatsSettings partnerSettingsB;

    public Partner partnerA;
    public Partner partnerB;

    public float destinyTresholdPercentage = 0.8f;
    public bool destiny;


    [Header("Conflict Percentages (DISPLAY ONLY)")]
    public float conflictPercentageDisplayA;
    public float conflictPercentageDisplayB;

    [Header("Conflict of Partner A (DISPLAY ONLY)")]
    public List<PartnerStatEntry> conflictDisplayA;

    [Header("Conflict of Partner B (DISPLAY ONLY)")]
    public List<PartnerStatEntry> conflictDisplayB;

    public void Initialize()
    {
        if (partnerA == null)
        {
            // partnerA = GameObject.Instantiate(new Gam)
        }
    }
    public void calculateConflict()
    {
        calculateConflict(ref partnerA, ref partnerB);
    }

    public void calculateConflict(ref Partner _partnerA, ref Partner _partnerB)
    {
        for (int i = 0; i < _partnerA.stats.StatCount; i++)
        {
            PartnerStatEntry haveA = _partnerA.stats.have[i];
            RangedPartnerStatEntry wantsA = _partnerA.stats.want[i];

            PartnerStatEntry haveB = _partnerB.stats.have[i];
            RangedPartnerStatEntry wantsB = _partnerB.stats.want[i];

            _partnerA.stats.conflict[i].val = getRangeDelta(haveA.val, wantsB.val);
            _partnerB.stats.conflict[i].val = getRangeDelta(haveB.val, wantsA.val);
        }

        _partnerA.stats.conflictPercentage = calculateConflictPercentage(ref _partnerA); _partnerB.stats.conflictPercentage = calculateConflictPercentage(ref _partnerB);

        UpdateConflictDisplay();
    }

    public void UpdateConflictDisplay()
    {
        conflictPercentageDisplayA = partnerA.stats.conflictPercentage;
        conflictPercentageDisplayB = partnerB.stats.conflictPercentage;

        conflictDisplayA = partnerA.stats.conflict;
        conflictDisplayB = partnerB.stats.conflict;
    }

    private float getRangeDelta(float input, Util.FloatRange range)
    {
        if (range.ContainsValue(input))
        {
            return 0;
        }
        else if (input < range.min)
        {
            return input - range.min;
        }
        else
        {
            return input - range.max;
        }
    }

    public void calculateDestiny()
    {
        calculateConflict();
        float destinyValA = calculateConflictPercentage(ref partnerA);
        float destinyValB = calculateConflictPercentage(ref partnerB);
        destiny = (destinyValA < destinyTresholdPercentage) && (destinyValB < destinyTresholdPercentage);
    }

    public float calculateConflictPercentage(ref Partner partner)
    {
        List<PartnerStatEntry> conflict = partner.stats.conflict;

        int max = conflict.Count;
        float cur = 0;

        for (int i = 0; i < max; i++)
        {
            if (conflict[i].val != 0)
            {
                cur++;
            }
        }
        return cur / max;
    }

}