using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Therapy : MonoBehaviour
{
    public TherapySettings DefaultSettings;
    public RelationshipSettings relationshipSettings;
    public Relationship relationship;
    public int budget;

    [SerializeField]
    public List<Session> sessions;

    private GameObject sessionParentGO;

    public Session GetActiveSession()
    {
        return sessions.Count > 0 ? sessions[sessions.Count - 1] : null;
    }

    public bool NextSession()
    {
        if (sessions == null)
            sessions = new List<Session>();

        if (sessions.Count >= budget)
            return false;

        GameObject next = new GameObject($"Session{sessions.Count + 1}/{budget}");
        next.transform.SetParent(sessionParentGO.transform);

        sessions.Add(next.AddComponent<Session>());
        GetActiveSession().Initialize(ref relationship);
        return true;
    }

    public void Initialize()
    {
        Initialize(null);
    }

    public void Initialize(TherapySettings ts)
    {
        if (sessionParentGO == null)
        {
            sessionParentGO = new GameObject("Sessions");
            sessionParentGO.transform.SetParent(transform);
        }
        if (ts == null)
        {
            DefaultSettings = ScriptableObject.CreateInstance<TherapySettings>();
        }
        else
        {
            DefaultSettings = ts;
        }

        relationshipSettings = DefaultSettings.relationshipSettings;
        budget = DefaultSettings.budget;

        if (relationship == null)
        {
            relationship = gameObject.AddComponent<Relationship>();

            if (relationshipSettings == null)
                relationshipSettings = ScriptableObject.CreateInstance<RelationshipSettings>();

            relationship.DefaultSettings = relationshipSettings;

            relationship.Initialize();
        }
    }
}