using System;
using UnityEngine;

public class Partner : MonoBehaviour
{
    [Header("Base Stats")]
    public string firstname;
    public string lastname;

    [Header("conflict potential (c),delta between HAVE other WANT.")]
    public float c1;
    public float c2;
    public float c3;
    public float c4;
    public float c5;

    [Header("Psych Stats")]
    public PartnerStats stats;

    [ExecuteInEditMode]
    private void UpdateDisplayName()
    {
        gameObject.name = $"{firstname} {lastname}";
    }

    void Start()
    {
        UpdateDisplayName();
    }
}
