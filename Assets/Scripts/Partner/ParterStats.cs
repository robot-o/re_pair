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
    [Range(0f, 1f)]
    public float resolution = 0.2f;

    [Header("Random Params: All")]
    public bool randomizeAll = false;
    public float randDeltaAll = 0f;
    [Range(0f, 1f)]
    public float randResolutionAll = 0.2f;
    [Header("Random Params: HAVE")]
    public bool randomizeHave = false;
    public float randDeltaHave = 0f;

    [Range(0f, 1f)]
    public float randResolutionHave = 0.2f;
    [Header("Random Params: WANT")]
    public bool randomizeWant = false;
    public float randDeltaWantMin = 0f;
    public float randDeltaWantMax = 0f;
    [Range(0f, 1f)]
    public float randResolutionWant = 0.2f;

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

    private float Round(float input, float step)
    {
        return ((Mathf.Round(input / step)) * step);
    }

    public void Randomize(bool overrideAll = false, bool overrideHave = false, bool overrideWant = false)
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


