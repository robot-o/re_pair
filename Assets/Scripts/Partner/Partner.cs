using UnityEngine;

public class Partner : MonoBehaviour
{
    [Header("Base Stats")]
    public string firstname = "Firstname";
    public string lastname = "Lastname";

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
