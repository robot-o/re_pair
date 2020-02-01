using UnityEngine;

[System.Serializable]
public class PartnerStatEntry
{
    public string statname = "";

    [Range(0f,1f)]
    public float val = 0f;
    public bool isRevealed = false;
}