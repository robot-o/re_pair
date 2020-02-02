using UnityEngine;
using Util;

[System.Serializable]
public class RangedPartnerStatEntry
{
    [HideInInspector]
    public string statname = "";
    public FloatRange val = new FloatRange();
    public bool isRevealed = false;
}