using UnityEngine;
using Util;

[System.Serializable]
public class RangedPartnerStatEntry
{
    public string statname = "";
    public FloatRange val = new FloatRange();
    public bool isRevealed = false;
}