using UnityEngine;
using System.Collections.Generic;

public class CommonKnowledge : MonoBehaviour
{
    public KnownPartnerData leftPartner;
    public KnownPartnerData rightPartner;

}

public struct KnownPartnerData
{
    public Partner partner;
    public List<float> knownHave;
    public List<float> knownWant;
    public KnownPartnerData(Partner _partner)
    {
        partner = _partner;
        knownHave = new List<float>(5);
        knownWant = new List<float>(5);
    }

}

public struct RevealedPartnerStatEntry
{


}