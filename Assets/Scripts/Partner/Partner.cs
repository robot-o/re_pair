using UnityEngine;

public class Partner : MonoBehaviour
{
    [Header("Base Stats")]
    public string firstname;
    public string lastname;

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
