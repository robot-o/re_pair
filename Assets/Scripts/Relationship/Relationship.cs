using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Relationship : ScriptableObject
{
    public Partner partnerA;
    public Partner partnerB;
    public int patience;

    public bool supposedToBe;


    [Header("Conflict of Partner A (DISPLAY ONLY)")]
    public List<PartnerStatEntry> conflictADisplay;

    [Header("Conflict of Partner B (DISPLAY ONLY)")]
    public List<PartnerStatEntry> conflictBDisplay;


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
        conflictADisplay = _partnerA.stats.conflict;
        conflictBDisplay = _partnerB.stats.conflict;
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

}