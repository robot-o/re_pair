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

    public Session GetActiveSession()
    {
        return sessions.Count > 0 ? sessions[sessions.Count - 1] : null;
    }

    public bool NextSession()
    {
        if(sessions == null)
            sessions = new List<Session>();

        if(sessions.Count >= budget)
            return false;

        sessions.Add(new Session(ref relationship));
        return true;
    }

    public void Initialize()
    {
        if (DefaultSettings == null)
            DefaultSettings = ScriptableObject.CreateInstance<TherapySettings>();

        this.relationshipSettings = DefaultSettings.relationshipSettings;
        this.budget = DefaultSettings.budget;

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