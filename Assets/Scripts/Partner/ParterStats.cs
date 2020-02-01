using UnityEngine;
using Util;

[CreateAssetMenu(menuName = "PartnerStats")]
[System.Serializable]
public class PartnerStats : ScriptableObject
{
    
    [Header("Resolution defines the step size between increments and decrements.")]
    public float resolution = 0.2f;
    
    [Header("HAVE Stats named generic, atm representing O C E A N")]
    public float h1 = 0f;
    public float h2 = 0f;
    public float h3 = 0f;
    public float h4 = 0f;
    public float h5 = 0f;

    [Header("WANT Stat ranges named generic, atm representing O C E A N")]
    public FloatRange w1 = new FloatRange();
    public FloatRange w2 = new FloatRange();
    public FloatRange w3 = new FloatRange();
    public FloatRange w4 = new FloatRange();
    public FloatRange w5 = new FloatRange();
}
