using UnityEngine;
using System.Collections.Generic;

public class CommonKnowledge : MonoBehaviour
{
    
}

public struct KnownPartnerData
{
    public Partner partner;
    public List<float> knownHave;
    public List<float> knownwant;
    public KnownPartnerData(Partner _partner)
    {
        partner = _partner;
        knownHave = new List<float>(); 
        knownWant = new List<float>(); 
    }

}