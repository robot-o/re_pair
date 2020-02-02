using UnityEngine;
using System.Collections.Generic;
[ExecuteInEditMode]
public class GameSession : MonoBehaviour
{
    public int maxTherapies = 1;
    public List<TherapySettings> therapySettings;
    public List<Therapy> therapies;

    public void Initialize()
    {
        Initialize(null);
    }

    public void Initialize(List<TherapySettings> ts)
    {
        if (ts == null)
        {
            therapySettings = new List<TherapySettings>(maxTherapies);
            while(therapySettings.Count < maxTherapies)
            {
                therapySettings.Add(ScriptableObject.CreateInstance<TherapySettings>());
            }
        }
        else
        {
            Debug.Log("recieved therapy settings during initialize");
            therapySettings = ts;
            maxTherapies = therapySettings.Count;
        }
    }

    public Therapy GetActiveTherapy()
    {
        return therapies.Count > 0 ? therapies[therapies.Count - 1] : null;
    }

    public bool NextTherapySession()
    {
        if (therapies == null)
            therapies = new List<Therapy>();

        if (therapies.Count >= maxTherapies)
        {
            Debug.Log("Max therapies Reached");
            return false;
        }

        GameObject next = new GameObject($"Therapy{therapies.Count + 1}/{maxTherapies}");
        next.transform.SetParent(transform);

        therapies.Add(next.AddComponent<Therapy>());
        GetActiveTherapy().Initialize(therapySettings[therapies.Count > 0 ? therapies.Count - 1 : 0]);
        return true;
    }

}