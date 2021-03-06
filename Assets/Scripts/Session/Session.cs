using UnityEngine;

[System.Serializable]
public class Session : MonoBehaviour
{
    public Relationship relationship;


    public void Initialize(ref Relationship _relationship)
    {
        relationship = _relationship;
    }

    public PartnerStatEntry revealHaveA(string targetStat)
    {
        int idx = relationship.partnerA.stats.have.FindIndex(o => o.statname == targetStat);

        if (idx == -1 || idx > relationship.partnerA.stats.have.Count - 1)
        {
            Debug.LogError($"Couldn't revealA stat \"{targetStat}\", key doesn't exist in {relationship.partnerA.displayName}'s stats.");
            return null;
        }
        else
        {
            relationship.partnerA.stats.have[idx].isRevealed = true;
            return relationship.partnerA.stats.have[idx];
        }
    }
    public RangedPartnerStatEntry revealWantA(string targetStat)
    {
        int idx = relationship.partnerA.stats.want.FindIndex(o => o.statname == targetStat);

        if (idx == -1 || idx > relationship.partnerA.stats.want.Count - 1)
        {
            Debug.LogError($"Couldn't revealA stat \"{targetStat}\", key doesn't exist in {relationship.partnerA.displayName}'s stats.");
            return null;
        }
        else
        {
            relationship.partnerA.stats.want[idx].isRevealed = true;
            return relationship.partnerA.stats.want[idx];
        }
    }
    public PartnerStatEntry revealHaveB(string targetStat)
    {
        int idx = relationship.partnerB.stats.have.FindIndex(o => o.statname == targetStat);

        if (idx == -1 || idx > relationship.partnerB.stats.have.Count - 1)
        {
            Debug.LogError($"Couldn't revealB stat \"{targetStat}\", key doesn't exist in {relationship.partnerB.displayName}'s stats.");
            return null;
        }
        else
        {
            relationship.partnerB.stats.have[idx].isRevealed = true;
            return relationship.partnerB.stats.have[idx];
        }
    }

    public RangedPartnerStatEntry revealWantB(string targetStat)
    {
        int idx = relationship.partnerB.stats.want.FindIndex(o => o.statname == targetStat);

        if (idx == -1 || idx > relationship.partnerB.stats.want.Count - 1)
        {
            Debug.LogError($"Couldn't revealB stat \"{targetStat}\", key doesn't exist in {relationship.partnerB.displayName}'s stats.");
            return null;
        }
        else
        {
            relationship.partnerB.stats.want[idx].isRevealed = true;
            return relationship.partnerB.stats.want[idx];
        }
    }

    public PartnerStatEntry revealHaveA(int idx)
    {
        relationship.partnerA.stats.have[idx].isRevealed = true;
        return relationship.partnerA.stats.have[idx];
    }
    public RangedPartnerStatEntry revealWantA(int idx)
    {
        relationship.partnerA.stats.want[idx].isRevealed = true;
        return relationship.partnerA.stats.want[idx];
    }
    public PartnerStatEntry revealHaveB(int idx)
    {
        relationship.partnerB.stats.have[idx].isRevealed = true;
        return relationship.partnerB.stats.have[idx];
    }
    public RangedPartnerStatEntry revealWantB(int idx)
    {
        relationship.partnerB.stats.want[idx].isRevealed = true;
        return relationship.partnerB.stats.want[idx];
    }

}