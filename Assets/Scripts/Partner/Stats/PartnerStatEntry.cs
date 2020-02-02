using UnityEngine;

[System.Serializable]
public class PartnerStatEntry
{
    [HideInInspector]
    public string statname = "";

    [Range(0f,1f)]
    public float val = 0f;
    public bool isRevealed = false;
}