using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "PartnerStats")]
[System.Serializable]
public class PartnerStats : ScriptableObject
{
    [Header("Amount of stats.")]
    [SerializeField]
    private int statCount = 5;
    public int StatCount
    {
        get { return statCount; }
        set
        {
            statCount = value;
            Resize(statCount);
        }
    }

    [SerializeField]
    [Header("Resolution defines the step size between increments and decrements.")]
    public float resolution = 0.2f;

    public List<string> statNames;

    [Header("HAVE, i.e. my stats")]
    public List<PartnerStatEntry> have;

    [Header("WANT, i.e. stats i want in my partner")]
    public List<RangedPartnerStatEntry> want;

    [Header("conflict potential, the difference between own HAVE and partner's WANT")]
    public List<PartnerStatEntry> conflict;

    public PartnerStats()
    {
        Initialize(statCount > 0 ? statCount : 5);
    }

    public void Resize(int _count)
    {
        statNames.ResizeList(statCount);
        have.ResizeList(statCount);
        want.ResizeList(statCount);
        conflict.ResizeList(statCount);
        Sync();
    }

    public void Sync()
    {
        for (int i = 0; i < statNames.Count; i++)
        {
            string sn = statNames[i];
            have[i].statname = sn;
            want[i].statname = sn;
            conflict[i].statname = sn;
        }
    }

    public void Initialize(int _count)
    {
        this.statCount = _count;
        this.statNames = new List<string>(statCount);
        this.have = new List<PartnerStatEntry>(statNames.Count);
        this.want = new List<RangedPartnerStatEntry>(statNames.Count);
        this.conflict = new List<PartnerStatEntry>(statNames.Count);
        Sync();
    }
}


